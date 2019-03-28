
#include <iostream>
#include <time.h>
#include <fstream>
#include<filesystem>
using namespace std;
struct Wezel
{
	int key;
	Wezel * lewy = NULL;
	Wezel * prawy = NULL;
	char tab[10];
};
class BST
{
public:

	Wezel* korzen = NULL;
	void NewBST();
	bool DodawanieWezla(Wezel * & root, int k);
	void LosoweDodanie(int k);
	bool szukanie(int key);
	void BST::usuwanieWezla(Wezel* &root, int key);
	Wezel* BST::szukanie(Wezel* prt, int key);
	Wezel* maksymalnyklucz(Wezel* ptr);
	int preorder(Wezel* wezel);
	int inorder(Wezel* wezel);
	int postorder(Wezel* wezel);

};

void BST::NewBST()
{
	cout << "Inicjuje drzewo!" << endl;
	korzen = new Wezel;
	korzen = NULL;
}

bool BST::DodawanieWezla(Wezel * &root, int k)
{
	Wezel * w, *p;
	w = new Wezel;            

	w->lewy = NULL;
	w->prawy = NULL;			// Zerujemy
	w->key = k;                // Wstawiamy k

	p = root;                  // Wyszukujemy miejsce dla

	if (p == NULL)                     // Drzewo 
		root = w;                // Jeœli tak
	else
		while (true)              // Pêtla 
			if (k < p->key)         // W zale¿noœci 
			{                      // prawego syna
				if (!p->lewy)         // Jeœli lewego
				{
					p->lewy = w;       // to wêze³ 
					break;             // Przerywamy
				}
				else p = p->lewy;
			}
			else if (k > p->key)
			{
				if (!p->prawy)        // Jeœli prawego syna nie ma,
				{
					p->prawy = w;      // to wêze³ 
					break;             // Przerywa
				}
				else p = p->prawy;
			}
			else
			{
				delete w;
				return false;
			}
	return true;
}
void BST::LosoweDodanie(int X)
{
	int los;
	for (int i = 0; i < X; i++)
	{
		los = rand() % 20000 - 10000;
		if (DodawanieWezla(korzen, los) == false) i--;
	}
}

bool BST::szukanie(int key)
{
	Wezel* x = korzen;

	while ((x) && (x->key != key))
		x = (key < x->key) ? x->lewy : x->prawy;

	if (x) { cout << "Znaleziono wezel " << key << endl; return 1; }
	else { cout << "Nie znalzeziono wezla" << key << endl; return 0; }
}

Wezel* BST::szukanie(Wezel* prt, int key)
{
	while ((prt) && (prt->key != key))
		prt = (key < prt->key) ? prt->lewy : prt->prawy;

	return prt;
}
Wezel* BST::maksymalnyklucz(Wezel* ptr)
{
	while (ptr->prawy != NULL) {
		ptr = ptr->prawy;
	}
	return ptr;
}
void BST::usuwanieWezla(Wezel* &root, int k)
{
	Wezel* x = root;
	Wezel*tym = NULL;
	Wezel*ptr = NULL;
	Wezel*rodzic = NULL;

	ptr = szukanie(korzen, k);

	if (korzen == NULL)
	{
		cout << "Nie mozna dodac elementu, drzewo nie zostalo zainicjalizowane!" << endl;
		return;
	}
	{
		//Przypadek 1: Wezel nie ma dzieci
		if (root->lewy == NULL && root->prawy == NULL)
		{
			//usuwamy z pamieci i ustawiamy korzen na 0
			delete root;
			root = NULL;
		}

		//Przypadek 2: Wezel ma dwojke dzieci
		else if (root->lewy && root->prawy && (ptr == root))
		{
			ptr = root->lewy;
			//szukanie poprzednika
			while (ptr->prawy != NULL)
			{
				rodzic = ptr;
				ptr = ptr->prawy;
			}
			Wezel *poprzednik = ptr;
			//kopiowanie wartosci z poprzednika do obecnego wezla
			root->key = poprzednik->key;
			if (poprzednik->lewy) {
				while (poprzednik->lewy != NULL)
				{
					poprzednik->key = poprzednik->lewy->key;
					tym = poprzednik;
					poprzednik = poprzednik->lewy;
				}
				delete poprzednik;
				tym->lewy = NULL;
				poprzednik = NULL;
			}
			else
			{
				delete poprzednik;
				rodzic->prawy = NULL;
				poprzednik = NULL;
			}
		}

		//Przypadek 3: Wezel ma tylko jedno dziecko
		else
		{
			//szukanie wezla dziecka
			ptr = szukanie(korzen, k);

			//szukanie wezla dziecka
			if (ptr->lewy && ptr->prawy == NULL)
			{
				while (ptr->lewy != NULL)
				{
					ptr->key = ptr->lewy->key;
					tym = ptr;
					ptr = ptr->lewy;
				}
				delete ptr;
				tym->lewy = NULL;
				ptr = NULL;
			}
		}
	}
}
int BST::preorder(Wezel* wezel)
{
	int ilosclewy = 0;
	int iloscprawy = 0;
	if (wezel != NULL)
	{
		cout << wezel->key << " ";
		if (wezel->lewy != NULL)
			ilosclewy = preorder(wezel->lewy);
		if (wezel->prawy != NULL)
			iloscprawy = preorder(wezel->prawy);
	}
	return 1 + ilosclewy + iloscprawy;
}

int BST::inorder(Wezel* wezel)
{
	int ilosclewy = 0;
	int iloscprawy = 0;
	if (wezel != NULL)
	{
		if (wezel->lewy != NULL)
			ilosclewy = inorder(wezel->lewy);
		cout << wezel->key << " ";
		if (wezel->prawy != NULL)
			iloscprawy = inorder(wezel->prawy);
	}
	return 1 + ilosclewy + iloscprawy;
}
int BST::postorder(Wezel* wezel)
{
	int ilosclewy = 0;
	int iloscprawy = 0;
	if (wezel != NULL)
	{
		if (wezel->lewy != NULL)
			ilosclewy = postorder(wezel->lewy);
		if (wezel->prawy != NULL)
			iloscprawy = postorder(wezel->prawy);
		cout << wezel->key << " ";
	}
	return 1 + ilosclewy + iloscprawy;
}
int main()
{
	cout << "podaj nazwe pliku z danymi";
	string filename;
	srand(time(NULL));
	int X, k1, k2, k3, k4;
	fstream file;
	file.open(filename);
	if (file.is_open()) {
		file >> X;
		file >> k1;
		file >> k2;
		file >> k3;
		file >> k4;
		file.close();
	}
	else {
		cout << "Nie mozna otworzyc pliku!!!" << endl;
		system("pause");
		return 0;
	}
	clock_t start, stop;
	double Czas;
	start = clock();

	BST BST;
	BST.NewBST();


	cout << endl << "Usuwanie elementu klucza o wartosci: " << k1 << endl;
	BST.usuwanieWezla(BST.korzen, k1);
	cout << endl;

	cout << endl << "Wstawianie elementu o wartosci klucza: " << k1 << endl;
	BST.DodawanieWezla(BST.korzen, k1);
	cout << endl;

	cout << endl << "Wstawianie X= " << X << " elementow do drzewa" << endl;
	BST.LosoweDodanie(X);
	cout << endl;

	cout << endl << "Wyswietlanie wszystkich kluczy w trybie inorder:" << endl;
	cout << BST.inorder(BST.korzen);
	cout << endl;

	cout << endl << "Wyswietlanie wszystkich kluczy w trybie preorder: " << endl;
	cout << BST.preorder(BST.korzen);
	cout << endl;

	cout << endl << "Wstawianie elementu o wartosci klucza: " << k2 << endl;
	BST.DodawanieWezla(BST.korzen, k2);
	cout << endl;

	cout << endl << "Wyswietlanie wszystkich kluczy w trybie inorder:" << endl;
	cout << BST.inorder(BST.korzen);
	cout << endl;

	cout << endl << "Wstawianie elementu o wartosci klucza: " << k3 << endl;
	BST.DodawanieWezla(BST.korzen, k3);
	cout << endl;

	cout << endl << "Wstawianie elementu o wartosci klucza: " << k4 << endl;
	BST.DodawanieWezla(BST.korzen, k4);
	cout << endl;

	cout << endl << "Wyswietlanie wszystkich kluczy w trybie preorder:" << endl;
	cout << BST.preorder(BST.korzen);
	cout << endl;

	cout << endl << "Usuwanie elementu klucza o wartosci: " << k1 << endl;
	BST.usuwanieWezla(BST.korzen, k1);
	cout << endl;

	cout << endl << "Wyswietlanie wszystkich kluczy w trybie preorder:" << endl;
	cout << BST.preorder(BST.korzen);
	cout << endl;

	cout << endl << "Wyszukiwanie elementu klucza o wartosci: " << k1 << endl;
	BST.szukanie(k1);
	cout << endl;

	cout << endl << "Usuwanie elementu klucza o wartosci: " << k2 << endl;
	BST.usuwanieWezla(BST.korzen, k2);
	cout << endl;

	cout << endl << "Wyswietlanie wszystkich kluczy w trybie inorder:" << endl;
	cout << BST.inorder(BST.korzen);
	cout << endl;

	cout << endl << "Usuwanie elementu klucza o wartosci: " << k3 << endl;
	BST.usuwanieWezla(BST.korzen, k3);
	cout << endl;

	cout << endl << "Usuwanie elementu klucza o wartosci: " << k4 << endl;
	BST.usuwanieWezla(BST.korzen, k4);
	cout << endl;

	stop = clock();
	Czas = (double)(stop - start) / CLOCKS_PER_SEC;
	cout << Czas << endl;
	system("pause");


}