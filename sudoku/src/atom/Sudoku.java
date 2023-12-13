package atom;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Set;

/**
 * Created by atom on 22.12.14.
 */
public class Sudoku {

    ArrayList<DataChangeListener> dataChangeListeners = new ArrayList<DataChangeListener>();

    int data[][] = new int[9][9];

    public void set(int x, int y, int value) {
        int oldValue=data[x][y];
        data[x][y]=value;
        fireDataChanged(x,y,oldValue,value);
    }

    public int getValue(int x, int y){
        return data[x][y];
    }

    @Override
    public String toString() {
        String str = "--------------------------\n";
        for (int y = 0; y < data.length; y++) {
            str +="| ";
            for (int x = 0; x < data.length; x++) {
                if (data[x][y]!=0)
                    str +=data[x][y];
                else
                    str += " ";
                str += " ";
                if ((x+1)%3==0) str += " | ";
            }
            str+="\n";
            if ((y+1)%3==0) str += "--------------------------\n";
        }
        return str;
    }

    /**
     * Diese Funktion liefert alle freie Zahlen für eine Postion...
     * @param x
     * @param y
     * @return ein Set mit allen freien Nummern
     */
    Set<Integer> getFreeNumbersForXY(int x, int y) {
        //Erstmal ein Set mit allen Nummern erstellen...
        Set<Integer> freeNumbers = new HashSet<Integer>(9);
        for (int i=1;i<=9;i++)
            freeNumbers.add(i);

        //als erstes gehen wir die zeile durch... und nehmen alle Ziffern raus die in der Zeile vorkommen...
        for (int i=0;i<data.length;i++)
            freeNumbers.remove(new Integer(data[i][y]));

        //dann gehen wir die Spalte durch ... wieder alle Ziffern raus die vorkommen
        for (int i=0;i<data.length;i++)
            freeNumbers.remove(new Integer(data[x][i]));

        //dann noch den "Quadranten" ... auch hier alle Ziffern raus die wir finden...
        int offsetX=(x/3)*3;
        int offsetY=(y/3)*3;
        for (int quadY=0;quadY<(data.length/3);quadY++)
            for (int quadX=0;quadX<(data.length/3);quadX++)
                freeNumbers.remove(new Integer(data[offsetX+quadX][offsetY+quadY]));

        return freeNumbers;

    }

    @Override
    protected Object clone() throws CloneNotSupportedException {
        Sudoku cloned = new Sudoku();
        for (int x = 0; x < data.length; x++) {
            System.arraycopy(data[x],0,cloned.data[x],0,data.length);
        }
        return cloned;
    }

    private void fireDataChanged(int x, int y, int oldValue, int newValue) {
        for (DataChangeListener listener:dataChangeListeners) {
            listener.dataChanged(x,y,oldValue,newValue);
        }
    }

    public void addDataChangeListener(DataChangeListener listener) {
        dataChangeListeners.add(listener);
    }
}
