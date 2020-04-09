package Model;

import java.math.BigDecimal;

public class Handlowiec extends Pracownik {
    private BigDecimal Prowizja;
    private double limit;
    public Handlowiec(String Pesel, String name, String nazwisko,int Wynagrodzenie,String Telefon,BigDecimal Prowizja,
                    double limit){

        super(Pesel,name,nazwisko,Wynagrodzenie,Telefon);
        this.setStanowisko("Handlowiec");

        this.limit=limit;
        this.Prowizja=Prowizja;

    }
    public void setProwizja(BigDecimal prowizja) {
        Prowizja = prowizja;
    }

    public BigDecimal getProwizja() {
        return Prowizja;
    }

    public void setLimit(double limit) {
        this.limit = limit;
    }

    public double getLimit() {
        return limit;
    }
}
