package logik;

/**
 * Created by Florian on 05.02.2015.
 */
public class TestProgramm {
    public static void main(String[] args){
        int [] a1 = new int[]{1,1,0,0,1,0,0,0,1};
        int [] a2 = new int []{1,1,0,0,1,0,0,0,1};
        int counter = 1;


        Arrayequalizer equalizer = new Arrayequalizer(a1);
       System.out.println(equalizer.equals(a2)) ;
       System.out.println(equalizer.getHitCounter());
        int []  array = equalizer.getEqualNumberArray();
        for (int x = 0; x < array.length; x++) {
            System.out.println("NUMMER "+counter + ": " + array[x]);
            counter++;
        }


    }
}
