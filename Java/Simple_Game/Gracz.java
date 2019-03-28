class Gracz{
int liczba = 0;

public int zgaduje()
{
  liczba = (int) (Math.random() * 10);
  return liczba;
}
}
