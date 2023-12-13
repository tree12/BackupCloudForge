package logik;

/**
 * Created by Florian on 05.02.2015.
 */
public class Arrayequalizer {
    /*
    Diese Klasse soll 2 Arrays auf deren Inhalt überprüfen ob sie gleich sind....
    @THOMAS..... habe die Klasse extends Objekt gemacht, wollte dann die EqualsMethode überschreiben.
    Da hat mir irgendwann das Programm gesagt das das kein Overriding der Super Klasse ist ?!
    Warum geht das so nicht? Was hab ich falsch gemacht...?
     */
/*
TODO es muss sichergestellt werden, dass auch wirklich nur 2 gleich grosse Arrays verwendet werden können
 */
    static final int HIT_EMPTY_FIELD = 0;
    static final int HIT_NUMBER = 1;
    static final int NO_HIT_NUMBER = 2;
    private  int counterHitNumber = 0;
    private int counterNonHitNumber= 0;
    private int []toTestingArray = new int[]{};
    private int []sameNumbers;

    private void setHitCounter(){
        counterHitNumber ++;
    }
    public int getHitCounter(){
        return counterHitNumber;
    }
    private void setNonHitCounter(){
        counterNonHitNumber ++;
    }
    public int getNonHitCounter(){
        return counterNonHitNumber;
    }
    public int[] getEqualNumberArray(){
        return sameNumbers;
    }

    public boolean equals(int [] array){
        int[] vergleichsArray = array;
        int wert = 0;
        int vergleichstWert = 0;
        boolean isEqual  = false;
        sameNumbers = new int[array.length];

        for (int i = 0; i < array.length ; i++) {
          wert = toTestingArray[i];
            vergleichstWert = vergleichsArray[i];
            if(wert != 0 && vergleichstWert != 0 && wert == vergleichstWert){
                sameNumbers[i] = HIT_NUMBER;
                setHitCounter();
            }
             if(wert == 0 && vergleichstWert != 0 ){
                sameNumbers[i] = NO_HIT_NUMBER;
                setNonHitCounter();
             }
            if ( wert != 0 && vergleichstWert == 0) {
                sameNumbers[i] = NO_HIT_NUMBER;
                setNonHitCounter();
            }
             if ( wert != 0 && vergleichstWert != 0 && wert != vergleichstWert) {
                sameNumbers[i] = NO_HIT_NUMBER;
                setNonHitCounter();
            }
             if(wert == 0 && vergleichstWert == 0){
                sameNumbers[i]= HIT_EMPTY_FIELD;
            }
        }
        if(getNonHitCounter() == 0) {
           isEqual = true;
        }else{
            isEqual = false;
        }
        return isEqual;
    }

    public Arrayequalizer(int[]array){
        this.toTestingArray = array;

    }
}
