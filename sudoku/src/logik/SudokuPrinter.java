package logik;

/**
 * Created by Florian on 14.01.2015.
 */
public class SudokuPrinter {
    private int x = 0;
    private int y = 0;
    private int z = 0;
    int[][] sudoku = new int[9][9];

    public void printArray() {
        for (int x = 0; x < sudoku.length; x++) {
            System.out.println(" ");
            if (x % 3 == 0) {
                System.out.println("-------------------------");
            }
            for (int y = 0; y < sudoku.length; y++) {

                if (y % 3 == 0) {
                    System.out.print(" |");
                }
                System.out.print(" " + sudoku[x][y]);
            }
        }
        System.out.println("");
        System.out.println("-------------------------");
    }

    public SudokuPrinter(CreateSudoku sudoku1) {
        this.sudoku = sudoku1.array();

    }
}
