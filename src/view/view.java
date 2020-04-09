package view;
import Model.Dyrektor;
import Model.Handlowiec;
import Model.Pracownik;
import controller.controller;
import java.util.HashMap;
import java.util.List;
import Model.listaPracownikow;

public class view {
    private controller controller = new controller();
    private listaPracownikow lista;
    private String[] errorMessages = {
            "please press [q] or [Enter].",
            "the PESEL has to be unique!",
            "Please enter correct PESEL",
            "lista jest pusta!!! należy pierw dodać pracowników by mieć kogo usunąć",
            "please press from 1-4 to choose any option",
            "file not found!!!",
            "there is no list created!",
            "PESEL has to contains 11 characters"
    };

    public void correctMessage()
    {
        System.out.println("the PESEL is correct");
    }

    public void init()
    {
        System.out.print("MENU \n" +
                "\t1.\tlista pracowników \n" +
                "\t2.\tDodaj pracownika\n" +
                "\t3.\tUsuń pracownika\n" +
                "\t4.\tKopia Zapasowa \n\n" +
                "Wybór> ");
    }
    public void viewList(int position)
    {

        //HashMap<String, Pracownik> lista = controller.getList();
        if(lista.LISTA_PRACOWNIKOW.isEmpty()){
            System.out.println("lista jest pusta :< , press q to quit and add some employess ");
            return;}
        Object[] list =  lista.LISTA_PRACOWNIKOW.getEmployeesArray();
        if(position<list.length){

            if (list[position] instanceof Dyrektor) {
                Dyrektor obj= (Dyrektor)list[position];
                System.out.println(" 1. Lista pracowników\n");
                System.out.println("\tidentyfikator PESEL\t\t  :\t" + obj.getPesel());
                System.out.println("\tImię\t\t\t\t\t  :\t" + obj.getName());
                System.out.println("\tNazwisko\t\t\t\t  :\t" + obj.getNazwisko());
                System.out.println("\tStanowisko\t\t\t\t  :\t" + obj.getStanowisko());
                System.out.println("\tWynagrodzenie(zł)\t\t  :\t" + obj.getWynagrodzenie());
                System.out.println("\tTelefon służbowy numer \t  :\t" + obj.getTelefon());
                System.out.println("\tDodatek służbowy(zł) \t  :\t" + obj.getDodatekSluzbowy());
                System.out.println("\tKarta służbowa numer \t  :\t" + obj.getKarta());
                System.out.println("\tLimit kosztów/miesiąc(zł) :\t" + obj.getLimit());
                position+=1;
                System.out.println("\t\t\t\t\t\t\t\t\t\t[Pozycja: " + position+"/"+list.length+"]");
                System.out.println(" [Enter] – nastepny \n [Q] – powrot");
            }else{
                Handlowiec obj= (Handlowiec) list[position];
                System.out.println(" 1. Lista pracowników\n");
                System.out.println("\tidentyfikator PESEL\t\t  :\t" + obj.getPesel());
                System.out.println("\tImię\t\t\t\t\t  :\t" + obj.getName());
                System.out.println("\tNazwisko\t\t\t\t  :\t" + obj.getNazwisko());
                System.out.println("\tStanowisko\t\t\t\t  :\t" + obj.getStanowisko());
                System.out.println("\tWynagrodzenie(zł)\t\t  :\t" + obj.getWynagrodzenie());
                System.out.println("\tTelefon służbowy numer \t  :\t" + obj.getTelefon());
                System.out.println("\tProwizja(%) \t\t\t  :\t" + obj.getProwizja());
                System.out.println("\tLimit kosztów/miesiąc(zł) :\t" + obj.getLimit());
                position+=1;
                System.out.println("\t\t\t\t\t\t\t\t\t\t[Pozycja: " + position+"/"+list.length+"]");
                System.out.println(" [Enter] – nastepny \n [Q] – powrot");
            }}else if(position == list.length)
                System.out.println("there is no more saved employees!, please press q to quit view list mode.");
    }

    public void getError(int position)
    {
        System.out.println(errorMessages[position]);
    }
    public void addEmployee(String input,int position)
    {
        if(input.equals("D")){
            if(position == 1)
            {
                System.out.println("------------------------------------------------------------------");
                System.out.print("identyfikator PESEL\t\t\t\t:\t ");

            }
            else if(position == 2)
            {
                System.out.print("Imię\t\t\t\t\t\t    :\t");
            }
            else if(position == 3)
            {
                System.out.print("Nazwisko\t\t\t\t\t    :\t");
            }
            else if(position == 4)
            {
                System.out.print("Wynagrodzenie(zł)\t\t\t    :\t");
            }
            else if(position == 5)
            {
                System.out.print("Telefon służbowy numer \t\t\t:\t");
            }
            else if(position == 6)
            {
                System.out.print("Dodatek służbowy(zł) \t\t    :\t");


            }
            else if(position == 7)
            {
                System.out.print("Karta służbowa numer \t\t    :\t");
            }
            else if(position == 8)
            {
                System.out.print("Limit kosztów/miesiąc(zł)\t\t:\t");
            }
        }
        if(input.equals("H")){
            if(position == 1)
            {
                System.out.println("------------------------------------------------------------------");
                System.out.print("identyfikator PESEL\t\t\t\t:\t ");

            }
            else if(position == 2)
            {
                System.out.print("Imię\t\t\t\t\t\t    :\t");
            }
            else if(position == 3)
            {
                System.out.print("Nazwisko\t\t\t\t\t    :\t");
            }
            else if(position == 4)
            {
                System.out.print("Wynagrodzenie(zł)\t\t\t    :\t");
            }
            else if(position == 5)
            {
                System.out.print("Telefon służbowy numer \t\t\t:\t");
            }
            else if(position == 6)
            {
                System.out.print("Prowizja(%) \t\t\t\t\t:\t");
            }
            else if(position == 7)
            {
                System.out.print("Limit kosztów/miesiąc(zł)\t\t:\t");
            }
        }
    }


    public void getRemovalKey()
    {
        System.out.println("\tPodaj Identyfikator PESEL : ");
        System.out.println("------------------------------------------------------------------");
    }
    public Boolean Removal(String key)
    {
        //HashMap<String, Pracownik> lista = controller.getList();
        if(lista.LISTA_PRACOWNIKOW.checkKey(key)) {
            Object result = lista.LISTA_PRACOWNIKOW.getEmployee(key);
            if (result instanceof Dyrektor) {
                Dyrektor obj = (Dyrektor) result;
                System.out.println(" 3. Usuń pracownika\n");
                System.out.println("\tidentyfikator PESEL\t\t  :\t" + obj.getPesel());
                System.out.println("\tImię\t\t\t\t\t  :\t" + obj.getName());
                System.out.println("\tNazwisko\t\t\t\t  :\t" + obj.getNazwisko());
                System.out.println("\tStanowisko\t\t\t\t  :\t" + obj.getStanowisko());
                System.out.println("\tWynagrodzenie(zł)\t\t  :\t" + obj.getWynagrodzenie());
                System.out.println("\tTelefon służbowy numer \t  :\t" + obj.getTelefon());
                System.out.println("\tDodatek służbowy(zł) \t  :\t" + obj.getDodatekSluzbowy());
                System.out.println("\tKarta służbowa numer \t  :\t" + obj.getKarta());
                System.out.println("\tLimit kosztów/miesiąc(zł) :\t" + obj.getLimit());

                return true;
            } else {
                Handlowiec obj = (Handlowiec) result;
                System.out.println(" 3. Usuń pracownika\n");
                System.out.println("\tidentyfikator PESEL\t\t  :\t" + obj.getPesel());
                System.out.println("\tImię\t\t\t\t\t  :\t" + obj.getName());
                System.out.println("\tNazwisko\t\t\t\t  :\t" + obj.getNazwisko());
                System.out.println("\tStanowisko\t\t\t\t  :\t" + obj.getStanowisko());
                System.out.println("\tWynagrodzenie(zł)\t\t  :\t" + obj.getWynagrodzenie());
                System.out.println("\tTelefon służbowy numer \t  :\t" + obj.getTelefon());
                System.out.println("\tProwizja(%) \t\t\t  :\t" + obj.getProwizja());
                System.out.println("\tLimit kosztów/miesiąc(zł) :\t" + obj.getLimit());
                return true;
            }
        }else System.out.println("proszę podać poprawny PESEL pracownika");
        return false;
    }

    public void getAddHeader()
    {
        System.out.println("\t2.\tDodaj pracownika \n");
        System.out.print("[D]yrektor/[H]andlowiec:\t\t");

    }
    public void addFooter()
    {
        System.out.println("------------------------------------------------------------------");
        System.out.println(" [Enter] – zapisz \n [Q] – porzuć");
    }

    public void headerOption4()
    {
        System.out.println("\t4 Kopia zapasowa\n");
        System.out.print("[Z]achowaj/[O]dtwórz\t:\t\t");

    }
    public void midOfOption4(int part){
        if(part == 0){
            System.out.println("------------------------------------------------------------------");
            System.out.print("Kompresja [G]zip/[Z]ip\t:\t\t");}else if(part==1){
            System.out.print("nazwa pliku\t:\t\t");
        }
    }

}


