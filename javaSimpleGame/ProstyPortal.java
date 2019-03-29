import java.util.ArrayList;
public class ProstyPortal
{
private ArrayList<String> polaPolozenia;
private String name;

public void SetPolozenia(ArrayList<String> ppol)//save portal placement
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
  //end of the loop
  if(polaPolozenia.isEmpty())
  {
    wynik = "Zatopiony";//if portal is destroyed with this shoot print this
  }
  else
  {
    wynik = "trafiony";//if hit
  }
  
  

}//koniec metody
return wynik;
}//koniec klasy

public void setName(String name)
{
  this.name = name;
}

}
