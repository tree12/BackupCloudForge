package atom;

import java.util.List;
import java.util.Set;

public class Main {

    public static void main(String[] args) throws Exception {
        //Erstelle Sudoku das gelöst werden muss...
    	Sudoku sudoku = new Sudoku();
        sudoku.set(2,0,2);
        sudoku.set(4,0,1);
        sudoku.set(5,0,7);
        sudoku.set(6,0,4);
        sudoku.set(8,0,3);

        sudoku.set(0,1,7);
        sudoku.set(1,1,8);
        sudoku.set(8,1,1);

        sudoku.set(4,2,8);
        sudoku.set(8,2,9);

        sudoku.set(2,3,9);
        sudoku.set(4,3,7);
        sudoku.set(6,3,8);
        sudoku.set(7,3,1);

        sudoku.set(1,4,6);
        sudoku.set(2,4,3);
        sudoku.set(3,4,8);
        sudoku.set(5,4,2);
        sudoku.set(6,4,5);
        sudoku.set(7,4,4);

        sudoku.set(1,5,7);
        sudoku.set(2,5,8);
        sudoku.set(4,5,4);
        sudoku.set(6,5,9);

        sudoku.set(0,6,3);
        sudoku.set(4,6,5);

        sudoku.set(0,7,2);
        sudoku.set(7,7,7);
        sudoku.set(8,7,4);

        sudoku.set(0,8,8);
        sudoku.set(2,8,6);
        sudoku.set(3,8,7);
        sudoku.set(4,8,3);
        sudoku.set(6,8,2);
        
        Sudoku heavy=new Sudoku();

        heavy.set(0, 2, 6);
        heavy.set(0, 3, 1);
        heavy.set(0, 8, 4);

        heavy.set(1, 0, 7);
//        heavy.set(1, 4, 2);
        heavy.set(1, 7, 5);

        heavy.set(2, 0, 4);
        heavy.set(2, 5, 9);
        heavy.set(2, 7, 8);

        heavy.set(3, 2, 4);
        heavy.set(3, 7, 1);
        heavy.set(3, 8, 5);

        heavy.set(4, 0, 2);
        heavy.set(4, 8, 7);

        heavy.set(5, 0, 3);
        heavy.set(5, 1, 1);
        heavy.set(5, 6, 9);

        heavy.set(6, 1, 2);
        heavy.set(6, 3, 9);
        heavy.set(6, 8, 8);

        heavy.set(7, 1, 4);
        heavy.set(7, 4, 5);
        heavy.set(7, 8, 3);

        heavy.set(8, 0, 9);
        heavy.set(8, 5, 4);
        heavy.set(8, 6, 7);

        Sudoku neu=new Sudoku();

        neu.addDataChangeListener(new DataChangeListener() {
            @Override
            public void dataChanged(int x, int y, int oldValue, int newValue) {
                System.out.println("DataChangeListener: x=" + x + ", y="+y+", oldValue="+oldValue+", newValue="+newValue);
            }
        });
        
        neu.set(0,2, 9);
        neu.set(0, 3, 7);
        neu.set(0, 5, 5);
        neu.set(0, 6, 1);
        neu.set(0, 7, 3);

        neu.set(1, 3, 9);
        neu.set(1, 5, 6);
        neu.set(1, 6, 5);

        neu.set(2, 2, 5);
        neu.set(2, 8, 8);

        neu.set(3, 2, 1);
        neu.set(3, 4, 9);
        neu.set(3, 6, 6);
        neu.set(3, 7, 7);

        neu.set(4, 2, 8);
        neu.set(4, 3, 5);
        neu.set(4, 7, 9);

        neu.set(5, 0, 2);
        neu.set(5, 3, 4);
        neu.set(5, 5, 3);

        neu.set(7, 0, 1);
        neu.set(7, 2, 6);
        neu.set(7, 3, 3);
        neu.set(7, 6, 4);
        neu.set(7, 8, 5);

        neu.set(8, 4, 1);
        neu.set(8, 6, 3);
        neu.set(8, 8, 6);


        System.out.println("Das zu lösende Sudoku:");
        System.out.println(neu);

        SudokuSolver solver = new SudokuSolver(neu);

        List<Sudoku> loesungen = solver.solve();

        System.out.println(loesungen.size() + " Lösungen gefunden...");

        int i=1;
        for (Sudoku loesung:loesungen) {
            System.out.println("Lösung " + i);
            System.out.print(loesung);
            System.out.println("=====================================");
            i++;
        }

    }
}
