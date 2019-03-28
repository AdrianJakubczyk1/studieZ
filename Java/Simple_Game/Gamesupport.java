import java.io.*;
public class Gamesupport{
  public String Pola(String napis)
  {
    String wierszWej=null;
    System.out.print(napis + " ");
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
  }

