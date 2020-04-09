package Model;
import com.sun.istack.internal.NotNull;


import java.io.Serializable;

public abstract class Pracownik implements Serializable {
    private String pesel;
    private String name;
    private String Nazwisko;
    private String stanowisko;
    private int Wynagrodzenie;
    private String Telefon;
    public Pracownik(String Pesel, String name, String nazwisko,int Wynagrodzenie,String Telefon)
    {
        pesel = Pesel;
        this.name=name;
        this.Nazwisko=nazwisko;
        this.Wynagrodzenie=Wynagrodzenie;
        if(Telefon.equals(""))this.Telefon="- brak -";
        this.Telefon=Telefon;
    }

    @Override
    public String toString() {
        return this.name + " " + this.Nazwisko;
    }

    public void setPesel(@NotNull String Pesel)
    {
        this.pesel=Pesel;
    }

    public String getPesel() {
        return pesel;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public void setNazwisko(String nazwisko) {
        Nazwisko = nazwisko;
    }

    public String getNazwisko() {
        return this.Nazwisko;
    }

    public void setWynagrodzenie(int wynagrodzenie) {
        Wynagrodzenie = wynagrodzenie;
    }

    public int getWynagrodzenie() {
        return this.Wynagrodzenie;
    }

    public void setTelefon(String telefon) {
        Telefon = telefon;
    }

    public String getTelefon() {
        return this.Telefon;
    }

    public void setStanowisko(String stanowisko) {
        this.stanowisko = stanowisko;
    }

    public String getStanowisko(){
        return this.stanowisko;
    }
}


