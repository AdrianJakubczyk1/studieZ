import java.io.*;
import java.util.*;
public class GameSupport{

    private static final String alphabet = "abcdefg";
    private int planeLength = 7;
    private int planeSize = 49;
    private int [] plane = new int[planeSize];
    private int numberOfPortlas = 0;


 public String Pola(String comm)
  {
    String wierszWej=null;
    System.out.print(comm + " ");
    try{
    	BufferedReader sw = new BufferedReader(new InputStreamReader(System.in));
    	wierszWej = sw.readLine();
    	if(wierszWej.length() == 0) return null;}
    	catch(IOException e)
    	{
    		System.out.println("IOException" + e);
    	}
    	return wierszWej;
    }

    public ArrayList<String> setThePortals(int sizeOfThePortal)
    {
        ArrayList<String>takenPools = new ArrayList<String>();//coordinates in the game type example=f6
        String[] coordinates = new String[sizeOfThePortal];
        String help = null;
        int [] coordinatess = new int[sizeOfThePortal];
        int count=0;
        boolean sucess = false;
        int placement = 0;

        numberOfPortlas++;
        int incr = 1;
        if((numberOfPortlas % 2) == 1)
        {
            incr = planeLength;//upright incr
        }

        while(!sucess & count++ < 200)//main loop of looking
        {
            placement = (int) (Math.random() * planeSize);//random start point
            System.out.println(" check" + placement);
            int x = 0;
            sucess = true;
            while(sucess && x<sizeOfThePortal)
            {
                if(plane[placement] == 0)//if not taken
                {
                    coordinatess[x++] = placement;
                    placement += incr;
                    if(placement >= planeSize)
                    {
                        sucess = false;//out of range
                    }
                    if(x>0 & (placement % planeLength == 0)){
                        sucess = false; // out of range
                    }
                }
                else
                {
                    System.out.println(" already taken " + placement);
                    sucess = false;
                }
            }
        }
        int x = 0;
        int row = 0;
        int column = 0;

        while(x < sizeOfThePortal)
        {
            plane[coordinatess[x]] = 1;//pool is taken
            row = (int) (coordinatess[x] / planeLength);//set the row
            column = coordinatess[x] % planeLength; //get number of column
            help = String.valueOf(alphabet.charAt(column));//conversion to alphanumeric 
            takenPools.add(help.concat(Integer.toString(row)));
            x++;
            System.out.print( "wspolrzedne " +x+" = " + takenPools.get(x-1));
        }
        System.out.println("\n");
        return takenPools;
    }
  }


