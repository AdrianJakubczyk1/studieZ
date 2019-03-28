import java.util.ArrayList;
class ProstyPortal
{
private ArrayList<String> polaPolozenia;
int iloscTrafien;

public void SetPolozenia(ArrayList<String> ppol)
{
  polaPolozenia = ppol;
}
public String sprawdz(String stringPole)
{
  int indeks = polaPolozenia.indexOf(stringPole);
  String wynik = "pudlo";
    if(indeks >= 0)
    {
      polaPolozenia.remove(indeks);
  //kuniec petli
  if(polaPolozenia.isEmpty())
  {
    wynik = "Zatopiony";
  }
  else
  {
    wynik = "trafiony";
  }
  
  

}//koniec metody
return wynik;
}//koniec klasy
}
