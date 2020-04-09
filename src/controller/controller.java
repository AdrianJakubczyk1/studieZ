package controller;
import Model.Dyrektor;
import Model.Handlowiec;
import Model.Pracownik;
import Model.listaPracownikow;
import view.view;
import java.io.*;
import java.math.BigDecimal;
import java.util.HashMap;
import java.util.Scanner;
import java.util.zip.*;
public class controller<T extends Pracownik> {
    private static view Menu;
    private static controller controller = new controller();
    private static listaPracownikow lista = listaPracownikow.LISTA_PRACOWNIKOW;

    public static void init() throws IOException, ClassNotFoundException {
        Menu = new view();
        String choice = "";
        Boolean end = true;
        do {
            Menu.init();

                Scanner scan = new Scanner(System.in);
                choice = scan.nextLine();
            if (choice.equals("1")) {
                controller.option1();
            } else if (choice.equals("2"))//Add Employer Screen
            {
                controller.option2();
            } else if (choice.equals("3")) {
                controller.option3();
            } else if (choice.equals("4"))
                controller.option4();
            else
                Menu.getError(4);
        } while (end);
    }

    //opcja 1
    public void option1() {
        Scanner scan = new Scanner(System.in);
        boolean pass = true;
        int counter = 0;
        while (pass) {
            Menu.viewList(counter);
            String continuation = scan.nextLine();
            if (continuation.equals("q")) {
                pass = false;
            } else if (continuation.isEmpty()) {
                counter++;
            } else {
                Menu.getError(0);
            }
        }
    }


    public void option2() {
        Handlowiec handlowiec;
        Dyrektor dyrektor;
        String tmp = "";
        String name = "";
        String Nazwisko = "";
        String Wynagrodzenie = "";
        String Telefon;
        String Dodatek;
        String Karta;
        String limit;
        Boolean ifContinue;
        Scanner scan = new Scanner(System.in);
        Menu.getAddHeader();
        //what Employee Wants to add user.
        String whichType = scan.nextLine();
        if (whichType.equals("D")) {
         //   dyrektor = new Dyrektor();
            Menu.addEmployee(whichType, 1);
            ifContinue=true;
            while (ifContinue) {
                Boolean result = true;
                tmp = scan.nextLine();
                //check length of PESEL
                if (tmp.length() != 11) {
                    Menu.getError(7);
                    //if its wrong PESEL then reset.
                    continue;
                }
                //check if employerlist is empty
                /*changed*/
                if (lista.isEmpty());

                    //dyrektor.setPesel(tmp);
                    //if not then check if given PESEL is unique
               else {
                    //if its not unique reset the loop.
                    if (!lista.checkUnique(tmp)){Menu.getError(1); continue;}
                }
                Menu.addEmployee(whichType, 2);
                name = scan.nextLine();
                Menu.addEmployee(whichType, 3);
                Nazwisko = scan.nextLine();
                Menu.addEmployee(whichType, 4);
                Wynagrodzenie = scan.nextLine();
                Menu.addEmployee(whichType, 5);
                Telefon = scan.nextLine();
                Menu.addEmployee(whichType, 6);
                Dodatek = scan.nextLine();
                Menu.addEmployee(whichType, 7);
                Karta = scan.nextLine();
                Menu.addEmployee(whichType, 8);
                limit = scan.nextLine();
                Menu.addFooter();
                String res = scan.nextLine();
                if (res.isEmpty()) {
                    dyrektor=new Dyrektor(tmp,name,Nazwisko,Integer.parseInt(Wynagrodzenie),Telefon,new BigDecimal(Dodatek),
                            Double.parseDouble(limit),Karta);
                    lista.dodajPracownika(tmp, dyrektor);
                    ifContinue = !ifContinue;
                } else if (res.equals("Q")) {
                    ifContinue = !ifContinue;
                }
                /*changed*/
                if (lista.isEmpty()) ;
            }
        } else if (whichType.equals("H")) {
           // handlowiec = new Handlowiec();
            Menu.addEmployee(whichType, 1);
            ifContinue=true;
            while (ifContinue) {
                Boolean result = true;
                tmp = scan.nextLine();
                if (tmp.length() != 11) {
                    Menu.getError(1);
                    continue;
                }
                if (lista.isEmpty());
                // handlowiec.setPesel(tmp);
               else {
                    //if its not unique reset the loop.
                    if (!lista.checkUnique(tmp)) continue;
               }
                Menu.addEmployee(whichType, 2);
                name = scan.nextLine();
                Menu.addEmployee(whichType, 3);
                Nazwisko = scan.nextLine();
                Menu.addEmployee(whichType, 4);
                Wynagrodzenie = scan.nextLine();
                Menu.addEmployee(whichType, 5);
                Telefon = scan.nextLine();
                Menu.addEmployee(whichType, 6);
                Dodatek = scan.nextLine();
                Menu.addEmployee(whichType, 7);
                limit = scan.nextLine();
                Menu.addFooter();
                String res = scan.nextLine();
                if (res.isEmpty()) {
                    handlowiec=new Handlowiec(tmp,name,Nazwisko,Integer.parseInt(Wynagrodzenie),Telefon,new BigDecimal(Dodatek),Double.parseDouble(limit));
                    lista.dodajPracownika(tmp, handlowiec);
                    System.out.println(res);
                    ifContinue = !ifContinue;
                } else if (res.equals("Q")) {
                    System.out.println(res);
                    ifContinue = !ifContinue;
                }else return;
//                if (getList().isEmpty()) ;
            }
        }
    }

    public void option3() {
        if (lista.isEmpty()) {
            Menu.getError(3);
            return;
        }
        Menu.getRemovalKey();
        Scanner scan = new Scanner(System.in);
        String key = scan.nextLine();
        Boolean result = Menu.Removal(key);
        if (result) {
            Menu.addFooter();
            String choice = scan.nextLine();
            if (choice.equals("q"))
                return;
            else if (choice.isEmpty())
                lista.removeEmployee(key);
            return;
        } else {
            Menu.getError(2);
            return;
        }
    }

    public void option4() throws IOException, ClassNotFoundException {
        Menu.headerOption4();
        Scanner scan = new Scanner(System.in);
        String choice = scan.nextLine();
        if (choice.equals("Z")) {
            Menu.midOfOption4(0);
            String compression = scan.nextLine();
            if (compression.equals("G")) {
                Menu.midOfOption4(1);
                String filename = scan.nextLine();
                String filename1 = "./" + filename + ".dat";
                File file = new File(filename1);
                lista.WriteObjectToFile(filename1);
               lista.gzip(filename1, filename);
            } else if (compression.equals("Z")) {
                Menu.midOfOption4(1);
                String filename = scan.nextLine();
                String filename1 = "./" + filename + ".dat";
                File file = new File(filename1);
                lista.WriteObjectToFile(filename1);
                lista.zipFile(filename1, filename);
            }
        } else if (choice.equals("O")) {
            Menu.midOfOption4(1);
            String filename = scan.nextLine();
            char[] ch = filename.toCharArray();
            if (ch[ch.length - 3] == '.') {
                lista.unGunzipFile(filename);
                try {
                    // Reading the object from a file
                    String replaced = filename.replace(".gz", ".log");
                    FileInputStream file = new FileInputStream
                            (replaced);
                    System.out.println(filename);
                    ObjectInputStream in = new ObjectInputStream
                            (file);
                    // Method for deserialization of object
                    HashMap<String, Pracownik> decompressedList = (HashMap<String, Pracownik>) in.readObject();
                    lista.setValues(decompressedList);
                    in.close();
                    file.close();
                } catch (IOException ex) {
                    Menu.getError(5);
                } catch (ClassNotFoundException ex) {
                    Menu.getError(6);
                }
            } else if (ch[ch.length - 3] == 'z') {
                // Reading the object from a file
                try {
                    lista.unzip(filename);
                    String replaced = filename.replace(".zip", ".log");
                    FileInputStream file = new FileInputStream
                            (replaced);
                    ObjectInputStream in = new ObjectInputStream
                            (file);
                    HashMap<String, Pracownik> decompressedList = (HashMap<String, Pracownik>) in.readObject();
                    lista.setValues(decompressedList);
                    in.close();
                    file.close();
                } catch (IOException e) {
                    Menu.getError(5);
                }
            } else {
                return;
            }
        } else return;
    }
}


