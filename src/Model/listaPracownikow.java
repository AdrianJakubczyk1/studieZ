package Model;

import com.sun.deploy.security.SelectableSecurityManager;

import java.io.*;
import java.util.HashMap;
import java.util.zip.*;

public class listaPracownikow {
    private static HashMap<String, Pracownik> listaPracowników=null;
    public static final listaPracownikow    LISTA_PRACOWNIKOW= new listaPracownikow();
    //constructor
    private listaPracownikow(){
        listaPracowników = new HashMap<String, Pracownik>();
    }
    //get specific employee
    public Pracownik getPracownika(String pesel)
    {
        return listaPracowników.get(pesel);
    }
    //add employee
    public void dodajPracownika(String key, Pracownik pracownik) {
        listaPracowników.put(key,pracownik);
    }


//    public static listaPracownikow getInstance()
//    {
//        if (listaPracowników== null)
//            listaPracowników= new listaPracownikow();
//
//        return listaPracowników;
//    }
//}
    public Boolean isEmpty()
    {
        if(listaPracowników.isEmpty())
            return true;
        else return false;
    }
    public Boolean checkUnique(String toCheck) {
        for (String temporary : listaPracowników.keySet()) {
            //check if its Dyrektor
            Boolean result;
            if (temporary.equals(toCheck)) {

             result = false;
                return result;
            }else
                 result = true;
                return result;
        }
        return false;
    }

    public Pracownik getEmployee(String key)
    {
        Pracownik result =listaPracowników.get(key);
        return result;

    }

    public Boolean removeEmployee(String key)
    {
        if(!listaPracowników.get(key).equals(null)){
           listaPracowników.remove(key);
        return true;}
        else
            return false;

    }

    public Object[] getEmployeesArray()
    {
        return listaPracowników.values().toArray();
    }

    public Boolean checkKey(String key)
    {
        return listaPracowników.containsKey(key);
    }
    public void WriteObjectToFile(String filename) {
        try {
            FileOutputStream fileOut = new FileOutputStream(filename);
            ObjectOutputStream objectOut = new ObjectOutputStream(fileOut);
            objectOut.writeObject(listaPracowników);
            objectOut.close();
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }

    public void setValues( HashMap<String, Pracownik> decompressedList)
    {
        for(Pracownik pracownik : decompressedList.values())
        {
            dodajPracownika(pracownik.getPesel(),pracownik);
        }
    }

    public void gzip(String filename, String gzipname) {
        byte[] buffer = new byte[1024];
        try {
            GZIPOutputStream gzos =
                    new GZIPOutputStream(new FileOutputStream("./" + gzipname + ".gz"));
            FileInputStream in =
                    new FileInputStream(filename);
            int len;
            while ((len = in.read(buffer)) > 0) {
                gzos.write(buffer, 0, len);
            }
            in.close();
            gzos.finish();
            gzos.close();

        } catch (IOException ex) {
            ex.printStackTrace();
        }
    }

    public void unGunzipFile(String compressedFile) {
        byte[] buffer = new byte[1024];
        try {
            FileInputStream fileIn = new FileInputStream(compressedFile);
            GZIPInputStream gZIPInputStream = new GZIPInputStream(fileIn);
            String replaced = compressedFile.replace(".gz", ".log");
            String replaced2 = "./" + replaced;
            System.out.println(replaced2);
            FileOutputStream fileOutputStream = new FileOutputStream(replaced2);
            int bytes_read;

            while ((bytes_read = gZIPInputStream.read(buffer)) > 0) {

                fileOutputStream.write(buffer, 0, bytes_read);
            }
            gZIPInputStream.close();
            fileOutputStream.close();

        } catch (IOException ex) {
            ex.printStackTrace();
        }
    }

    public  void zipFile(String filename, String zipname) {
        byte[] buffer = new byte[1024];
        try {
            FileOutputStream fos = new FileOutputStream("./" + zipname + ".zip");
            ZipOutputStream zos = new ZipOutputStream(fos);
            ZipEntry ze = new ZipEntry(filename);
            zos.putNextEntry(ze);
            FileInputStream in = new FileInputStream(filename);
            int len;
            while ((len = in.read(buffer)) > 0) {
                zos.write(buffer, 0, len);
            }
            in.close();
            zos.closeEntry();
            zos.close();
        } catch (IOException ex) {
            ex.printStackTrace();
        }
    }

    public void unzip(String zipFilePath) throws FileNotFoundException {
        byte[] buffer = new byte[1024];
        String replaced = zipFilePath.replace(".zip", ".log");
        String replaced2 = "./" + replaced;
        try {
            FileInputStream fis = new FileInputStream(zipFilePath);
            ZipInputStream zis = new ZipInputStream(fis);
            ZipEntry ze = zis.getNextEntry();

            while (ze != null) {
                String fileName = ze.getName();
                File newFile = new File(replaced2);
                System.out.println("Unzipping to " + newFile.getAbsolutePath());
                //create directories for sub directories in zip
                new File(newFile.getParent()).mkdirs();
                FileOutputStream fos = new FileOutputStream(newFile);
                int len;
                while ((len = zis.read(buffer)) > 0) {
                    fos.write(buffer, 0, len);
                }
                fos.close();
                //close this ZipEntry
                zis.closeEntry();
                ze = zis.getNextEntry();
            }
            //close last ZipEntry
            zis.closeEntry();
            zis.close();
            fis.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}


