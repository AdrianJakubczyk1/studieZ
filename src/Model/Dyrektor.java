package Model;

import java.math.BigDecimal;

public class Dyrektor extends Pracownik {
    private BigDecimal dodatekSluzbowy;
    private double limit;
    private String Karta;

    public Dyrektor(String Pesel, String name, String nazwisko,int Wynagrodzenie,String Telefon,BigDecimal dodatekSluzbowy,
    double limit, String Karta){

        super(Pesel,name,nazwisko,Wynagrodzenie,Telefon);
        this.setStanowisko("Dyrektor");
        this.dodatekSluzbowy=dodatekSluzbowy;
        this.limit=limit;
        this.Karta=Karta;

    }

    public double getLimit() {
        return limit;
    }

    public void setLimit(double limit) {
        this.limit = limit;
    }

    public BigDecimal getDodatekSluzbowy() {
        return dodatekSluzbowy;
    }

    public void setDodatekSluzbowy(BigDecimal dodatekSluzbowy) {
        this.dodatekSluzbowy = dodatekSluzbowy;
    }

    public String getKarta() {
        return Karta;
    }

    public void setKarta(String karta) {
        Karta = karta;
    }
}


