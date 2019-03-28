import java.util.ArrayList;
class Gra{
public static void main(String []args)
{
  int iloscRuchow = 0;
  Gamesupport pomoc = new Gamesupport();
  ProstyPortal portal = new ProstyPortal();
int random = (int) (Math.random()*5);
private ArrayList<Int> tablica;
tablica.add(random);
tablica.add(random+1);
tablica.add(random+1);
portal.SetPolozenia(tablica);
Boolean czyIstnieje = true;
while(czyIstnieje == true)
{
  String typy = pomoc.Pola("podaj swoje typy");
  String wynik = portal.sprawdz(typy);
  iloscRuchow++;
  if(wynik.equals("Zatopiony")){
    czyIstnieje = false;
    System.out.println("twoja ilosc ruchow : "+iloscRuchow);
  }

}
}
}
