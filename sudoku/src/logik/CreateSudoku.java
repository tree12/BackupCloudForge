package logik;


import logik.Sudoku.sudokuDataChangeListener;

import java.io.Serializable;
import java.util.ArrayList;



/**
 * Created by Florian on 14.01.2015.
 */
public class CreateSudoku implements Serializable {
    private int[][] sudoku = new int[9][9];
    private int wert = 0;
    private int freeField = 0;
    static final int X_INDEX = 0;
    static final int Y_INDEX = 1;
    static  final int EMPTYFIELD = 0;
    // transient : speichert die Serialisierung der Liste nicht mit
    transient ArrayList<sudokuDataChangeListener> dataChangeListeners = new ArrayList<sudokuDataChangeListener>();


    public void add(int x, int y, int zahl) {

        if (sudoku[x][y] == 0) {
            sudoku[x][y] = zahl;
            fireDataChanged(posNumber(x,y),EMPTYFIELD,zahl);
        }
    }

    public void delete(int x, int y){
        int wert = sudoku[x][y];
        sudoku[x][y] = 0;
        fireDataChanged(posNumber(x,y),wert,EMPTYFIELD);
    }


    public void newSudoku(){
        sudoku = new int[9][9];
                fireDataChangedOnLoad(sudoku);


            }



    public int getWert(int pos) {
        if (pos != 0) {
            int[] position = posBackToCoordinates(pos);
            wert = sudoku[position[Y_INDEX]][position[X_INDEX]];
        }
        return wert;
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
    private int posNumber(int x, int y) {
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

    public int[][] array() {
        return sudoku;
    }

    public void setArray(int [][] array){

        sudoku = array;
        fireDataChangedOnLoad(sudoku);
    }

    public int freeFields() {
        freeField = 0;
        for (int x = 0; x < sudoku.length; x++) {
            for (int y = 0; y< sudoku.length; y++) {
                int pos = posNumber(x,y);
                if (getWert(pos) == 0) {
                    freeField++;
                }
            }
        }
        System.out.println("Es sind noch " + freeField + " Felder frei!");
        return freeField;
    }

    public CreateSudoku() {

    }
    private void fireDataChanged(int pos, int oldValue, int newValue) {
        for (sudokuDataChangeListener listener:dataChangeListeners) {
            listener.dataChanged(pos,oldValue,newValue);
        }
    }
    public void fireDataChangedOnLoad(int [][] array){
        sudoku = array;
        if (dataChangeListeners == null) {
            this.dataChangeListeners = new ArrayList<sudokuDataChangeListener>();
        }
        for (int x = 0; x < sudoku.length; x++){
            for(int y = 0; y< sudoku.length; y++){
                fireDataChanged(posNumber(x, y),EMPTYFIELD,sudoku[x][y]);
            }
        }

    }

    public void addSudokuDataChangeListener(sudokuDataChangeListener listener) {
        dataChangeListeners.add(listener);
    }
}
