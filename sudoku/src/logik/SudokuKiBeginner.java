package logik;

import java.util.HashMap;

/**
 * Created by Florian on 15.01.2015.
 */
public class SudokuKiBeginner {
    static final int X_INDEX = 0;
    static final int Y_INDEX = 1;
    private CreateSudoku sudoku = new CreateSudoku();
    private HashMap<Integer, int[]> freeNumbers = new HashMap<Integer, int[]>();
    private static String stringFreeNumbers;


    public void expiration() {

        /*
        Hier befindet sich der Ablauf
         */
        int counter = 0;
        while (sudoku.freeFields()!=0 && counter <  50 ) {
            counter++;
            fillAllFreeNumbers();
            checkForSingleFreeNumbers(freeNumbers);
        }
        System.out.println("Das Sudoku wurde in : "+counter+" Spielzügen gelöst");
    }


    public int posNumber(int x, int y) {
        int positionNumber = 0;
        /*
        Diese Methode dient zum erstellen des Schlüssels für die Hashmap
        z.b sudoku[0][0] = 0
            sudoku[8][8] = 80
         */
        int[][] posArray = new int[9][9];
        int number = 0;

        for (int xx = 0; xx < posArray.length; xx++) {
            for (int yy = 0; yy < posArray.length; yy++) {
                posArray[xx][yy] = number;
                number++;
            }
        }
        positionNumber = posArray[x][y];
        return positionNumber;
    }

    public int[] posBackToCoordinates(int pos) {
        /*
        Wandelt den Schlüssel wieder in Koordinaten um
         */
        int[] coordinates = new int[2];
        {
            int xx = (pos)/9;
            int yy = (pos)%9;
            coordinates[X_INDEX] = xx;
            coordinates[Y_INDEX] = yy;
        }
        return coordinates;

    }

    public void fillAllFreeNumbers() {
        /*
        Diese Methode wurde am 31.01.15 erstellt
        Diese Methode schreibt alle freien Zahlen in eine Liste und verwendet zum ermitteln der einzelnen freien Zahlen die Methode:
        public void findFreeNumbersForSingleValue(int x, int y)
         */
        for (int x = 0; x < sudoku.array().length; x++) {
            for (int y = 0; y < sudoku.array().length; y++) {
                findFreeNumbersForSingleValue(x, y);
            }
        }
    }

    private void checkForSingleFreeNumbers(HashMap list ) {
       /*
        erstellt am 31.01.15 Hier wird die Haschmap auf alleinstehende freie Nummern geprüft und diese werden in das Sudoku eingetragen und dann aus
        der Hashmap gelöscht!!
         */
        HashMap<Integer, int[]>  freeNumberList = list;
        int[] array;
        int counter = 0;
        int numberToSet = 0;

        for (int i = 0; i < 81; i++) {
            /*
            TODO @THOMAS BITTE BEANTWORTEN
            warum kann ich in dieser Schleife anstatt der 81 nicht auf die freeNumberList.size() Methode der Liste zugreifen ?????
            funktioniert verliere aber Werte......
             */
            array = freeNumberList.get(i);
            int[] coordinates = posBackToCoordinates(i);
            singlePossibleValues(freeNumberList,coordinates[X_INDEX],coordinates[Y_INDEX]);
            fillAllFreeNumbers();
            if (array != null) {
                for (int x = 0; x < array.length; x++) {
                    if (array[x] == 1) {
                        counter = counter + 1;
                        numberToSet = x + 1;
                    }
                }
                if (counter == 1) {
                    sudoku.add(coordinates[X_INDEX],coordinates[Y_INDEX],numberToSet);
                    freeNumberList.remove(i);
                    counter = 0;
                    fillAllFreeNumbers();

                } else {
                    counter = 0;

                }
            }
        }
    }

    private void ceckForDoubles(HashMap hashmap){
        /*
        TODO
        Diese Methode soll die freien Zahlen durchforsten ob in einer Zeile/Spalte oder Quadranten Felder sind wo 2 oder 3 gleiche möglichkeiten sind.
        Dazu wird das Ausschlussverfahren verwendet.
        Die Arrays können mit der Equalsmethode  vom  Arrayequalizer verglichen und ausgewertet werden...
         */
        HashMap<Integer, int[]> freeNumberList = new HashMap();
        int []posArray = new int[9];
        int []paragonateArray = new int[9];
        for (int i = 0; i <9 ; i++) {
            posArray[i] = 1;
            paragonateArray[i]= 1;
        }
    }

    private void singlePossibleValues(HashMap hashMap, int x, int y) {
        /*
        Diese Methode soll freie Zahlen ermitteln die nur einmal vorkommen aber durch andere Zahlen überschattet werden...
        TODO MUSS NOCH FERTIG GEMACHT WERDEN ES IST NOCH EIN FEHLER VORHANDEN.....
        DIese Methode sollte nicht direkt löschen können fast richtig und doch nicht ganz
         */
        int xX = x;
        int yY = y;

        HashMap<Integer, int[]> xfreeNumbers = hashMap;
        int[] sudokuFreeNumbers = xfreeNumbers.get(posNumber(x, y));
        int[] x_freeNumberCounter = new int[9];
        int[] y_freeNumberCounter = new int[9];
        int[] q_freeNumberCounter = new int[9];
        boolean xIsTrue = false;
        boolean yIsTrue = false;
        boolean qIsTrue = false;
        int xlength = ((x / 3) * 3) + 3;
        int ylength = ((y / 3) * 3) + 3;
        int counterx = 0;
        int countery = 0;
        int counterq = 0;
        for (int line = 0; line < 9; line++) {
            int positionNumberx = posNumber(xX, line);
            int positionNumbery = posNumber(line, yY);
            int[] arrayX = xfreeNumbers.get(positionNumberx);
            int[] arrayY = xfreeNumbers.get(positionNumbery);
            for (int index = 0; index < 9; index++) {
                if (arrayX != null) {
                    if (arrayX[index] == 1) {
                        x_freeNumberCounter[index] = x_freeNumberCounter[index] + 1;
                    }
                }
                if (arrayY != null) {
                    if (arrayY[index] == 1) {
                        y_freeNumberCounter[index] = y_freeNumberCounter[index] + 1;
                    }
                }
            }
        }

        for (int xQuadrant = (x / 3) * 3; xQuadrant < xlength; xQuadrant++) {
            for (int yQuadrant = (y / 3) * 3; yQuadrant < ylength; yQuadrant++) {
                int positionNumberQ = posNumber(xQuadrant, yQuadrant);
                int[] arrayQ = xfreeNumbers.get(positionNumberQ);

                if (arrayQ != null) {
                    for (int i = 0; i < 9; i++) {
                    if (arrayQ[i] == 1) {
                        q_freeNumberCounter[i] = q_freeNumberCounter[i] + 1;
                    }
                    }
                }
            }
        }
        for (int quantity = 0; quantity < 9; quantity++) {
            if (x_freeNumberCounter[quantity] == 1) {
                counterx++;
            }
            if (y_freeNumberCounter[quantity] == 1) {
                countery++;
            }
            if (q_freeNumberCounter[quantity] == 1) {
                counterq++;
            }
            if (counterx == 1) {
                xIsTrue = true;
            }
            if (countery == 1) {
                yIsTrue = true;
            }
            if (counterq == 1) {
                qIsTrue = true;
            }

            if (xIsTrue == true && qIsTrue == true) {
                for (int pos = 0; pos < 9; pos++) {
                    if (x_freeNumberCounter[pos] == 1 && sudoku.array()[x][y] == 0 && sudokuFreeNumbers[pos] == 1) {
                        sudoku.add(x,y,pos + 1);
                        xfreeNumbers.remove(posNumber(x, y));
                    }
                }

            }
            if (yIsTrue == true && qIsTrue == true) {
                for (int pos = 0; pos < 9; pos++) {
                    if (y_freeNumberCounter[pos] == 1 && sudoku.array()[x][y] == 0 && sudokuFreeNumbers[pos] == 1) {
                        sudoku.add(x,y,pos + 1);
                        xfreeNumbers.remove(posNumber(x, y));

                    }
                }

            }
       }
    }

    private void findFreeNumbersForSingleValue(int x, int y) {
    /*
    Diese Methode ermittelt alle freien Zahlen für eine Position und speichert diese mit einem pos. Schlüssel in einer Liste ab
    Methode wurde am 31.01.15 geprüft und ist voll funktionsfähig
     */
        int xAchse = x;
        int yAchse =y;
        int[] numbersSet = new int[9];
        int xlength = ((x / 3) * 3) + 3;
        int ylength = ((y / 3) * 3) + 3;

        if (sudoku.array()[x][y] == 0) {
            for (int xx = 0; xx < sudoku.array().length; xx++) {
                numbersSet[xx] = 1;
            }


        for (int yy = 0; yy < sudoku.array().length; yy++) {
            if (sudoku.array()[x][yy] != 0) {
                int eingetragen = sudoku.array()[x][yy] - 1;
                numbersSet[eingetragen] = 0;
            }
        }
        for (int xx = 0; xx < sudoku.array().length; xx++) {
            if (sudoku.array()[xx][y] != 0) {
                int eingetragen = sudoku.array()[xx][y] - 1;
                numbersSet[eingetragen] = 0;
            }
        }
        for (int xQuadrant = (x / 3) * 3; xQuadrant < xlength; xQuadrant++) {
            for (int yQuadrant = (y / 3) * 3; yQuadrant < ylength; yQuadrant++) {
                if (sudoku.array()[xQuadrant][yQuadrant] != 0) {
                    int eingetragen = sudoku.array()[xQuadrant][yQuadrant] - 1;
                    numbersSet[eingetragen] = 0;
                }
            }
        }

        int positionNumber = posNumber(xAchse, yAchse);

        freeNumbers.put(positionNumber, numbersSet);
    }
        else {
            for (int xx = 0; xx < sudoku.array().length; xx++) {
                numbersSet[xx] = 0;
            }
            int positionNumber = posNumber(xAchse, yAchse);

            freeNumbers.put(positionNumber, numbersSet);
        }
    }

    public void freeNumberPrinter(int number) {
        /*
        Diese Methode dient lediglich zum überprüfen der funktionalität der Methode
        public void findFreeNumbersForSingleValue(int x, int y)
         */
        int[]  array = freeNumbers.get(number);
        System.out.println();
        System.out.println("Das ist die Nr.: " + number + " !!!!!!");
        for (int z = 0; z < array.length; z++) {

            System.out.print("| " + array[z]);
        }
        System.out.println();
    }

    public SudokuKiBeginner(CreateSudoku sudoku) {
        this.sudoku = sudoku;



    }

    public String getFreenumberString( int number){

       int[] array = freeNumbers.get(number);

            stringFreeNumbers = array[0]+","+array[1]+","+array[2]+","+array[3]+","+array[4]+","+array[5]+","+array[6]+","+array[7]+","+array[8];

     return  stringFreeNumbers;
    }

}