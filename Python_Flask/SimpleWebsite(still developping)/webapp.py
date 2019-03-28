from flask import Flask, render_template, request, escape, session, copy_current_request_context
from vsearch import searchForLetters
from UseDatabase import UseDatabase, ConnectionError, CredentialsError, SQLError
from dekorator import check_logged_in
from threading import Thread
from time import sleep
content = []



app = Flask(__name__)

app.secret_key = 'SuperOpsayianki'
app.config['config'] = {'host' : '127.0.0.1',
						'user' : 'ten',
						'password' : '1234',
						'database' : 'vsearchLogDB', }

@app.route('/vsearch', methods=['POST'])
def search() -> 'html':
	phrase=request.form['phrase']
	letters=request.form['letters']
	title = 'oto twoje wyniki'
	results = str(searchForLetters(phrase, letters))
	@copy_current_request_context
	def log_request(req: 'flask_request',res: str) -> None:
		sleep(15)
		with UseDatabase(app.config['config']) as cursor:
			sql = """insert into log
			(phrase, letters, ip, browser_string, results)
			values
			(%s,%s,%s,%s,%s)"""
			cursor.execute(sql, (req.form['phrase'],
			req.form['letters'],
			req.remote_addr,
			req.user_agent.browser,
			res, ))
	try:
		t = Thread(target=log_request, args=(request, results))
		t.start()
	except Exception as err:
		print('***** wystapil blad logowania: ', str(err))
	return render_template('results.html',
	                    the_title = title,
	                    the_phrase=phrase,
	                    the_letters=letters,
	                    the_results = results,)



@app.route('/')
@app.route('/entry')
def entry_page() -> 'html':
    return render_template('entry.html',
                           the_title='Witaj na stronie ')


	

#funkcja escape do usuwania znacznikow htmla


@app.route('/viewlog')
@check_logged_in
def view_the_log()-> 'html':
	try:
		with UseDatabase(app.config['config']) as cursor:
			sql = """select phrase , letters, ip, browser_string, results from log"""
			cursor.execute(sql)
			content = cursor.fetchall()
		titles=('phrase', 'letters', 'Adres Klienta', 'Agent uzytkownika', 'Wynik')
		return render_template('viewlog.html',
				the_title='twoje lugi',
				the_row_titles=titles,
				the_data=content,)
	except ConnectionError as err:
		print('brak polaczenia :', str(err))
	except CredentialsError as err:
		print('bledne dane logowania: ', str(err))
	except SQLError as err:
		print('czy zapytanie jest ok?:', str(err))
	except Exception as err:
		print('cos poszlo nie tak', str(err))
	return 'blad'
@app.route('/log_in')
def do_login() -> str:
	session['logged_in'] = True
	return 'Logowanie sie powiodło! witaj '

@app.route('/logout')
def do_logout() -> str:
	session.pop('logged_in')
	return 'jestes wylogowany'

if __name__ == '__main__':
	app.run(debug=True)


