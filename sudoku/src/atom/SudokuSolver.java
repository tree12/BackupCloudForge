package atom;

import java.util.ArrayList;
import java.util.List;
import java.util.Set;

/**
 * Created by atom on 22.12.14.
 */
public class SudokuSolver {

    int maxSolutions=100000;

    Sudoku sudoku;

    List<Sudoku> solutions = new ArrayList<Sudoku>();

    SudokuSolver(Sudoku sudoku) {
        this.sudoku=sudoku;
    }

    List<Sudoku> solve() throws Exception{
        //wir geben das zu lösende sudoku in die Liste der Möglichen Lösungen da es der Ausgangspunkt ist...
        solutions.add((Sudoku) sudoku.clone());

        //Alle Zeilen durchgehen, solange noch mögliche Lösungswege existieren...
        for (int y = 0; y < 9  && solutions.size()>0; y++)
            //Alle Spalten durchgehen, solange noch mögliche Lösungswege existieren...
            for (int x = 0; x < 9 && solutions.size()>0; x++) {

                //Wenn in einer der Lösungen dieses Feld schon gesetzt ist dann zum nächsten Feld übergehen! (Ist das Feld in einer Lösung schon gesetzt ist es in alle gesetzt...
                if (solutions.get(0).getValue(x,y)!=0) continue;

                //Eine Liste anlegen in die neue Lösungswege eingetragen werden können.
                ArrayList<Sudoku> newSolutions = null;

                int i=0;
                //Alle bisherigen Lösungswege durchgehen (Lösungswege weitergehen in diesem Fall)
                while (i<solutions.size()) {
                    Sudoku aktSolution = solutions.get(i);
                    Set<Integer> freeNumbers = aktSolution.getFreeNumbersForXY(x,y);

                    //Gibt es keine freie Nummer für dieses Feld mehr dann diesen Lösungsweg verwerfen
                    if (freeNumbers.size()==0) {
                        solutions.remove(i);
                        continue;
                    }

                    int j=0;
                    for (Integer freeNumber:freeNumbers) {
                        //Für die erste Lösung wird das bestehende
                        if (j>0) {
                            //Hier legen wir neue Lösungswege an, denn es wurden mehr als eine Freie Nummer gefunden...
                            if (newSolutions==null) newSolutions=new ArrayList<Sudoku>();
                            if (solutions.size()+newSolutions.size()<maxSolutions) {
                                //Neue Lösung anlegen und in die Liste der neuen Lösungen einfügen.
                                //ausserdem die neue Lösung zum aktuell bearbeiteten Lösungsweg machen.
                                aktSolution = (Sudoku) aktSolution.clone();
                                newSolutions.add(aktSolution);
                            } else {
                                //Würden wir nicht abfragen ob die Anzahl der Lösungen zu groß ist würden wir ev. den ganzen Speicher aufbrauchen...
                                System.out.println("MAX Solutions reached... skipping other possibilities");
                            }
                        }
                        //Die Nummer in den aktuellen Lösungsweg einfügen
                        aktSolution.set(x,y,freeNumber.intValue());
                        j++;
                    }
                    i++;
                }
                //Die neuen Lösungswege an die gesamten Lösungswege anhängen.
                if (newSolutions!=null)
                    solutions.addAll(newSolutions);
            }
        return solutions;
    }
}
