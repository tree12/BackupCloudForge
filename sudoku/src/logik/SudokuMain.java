package logik;

/**
 * Created by Florian on 14.01.2015.
 */
public class SudokuMain {
    public static void main(String[] args) {

/*
ein nachträglich eingefügtes Sudoku ---------WERDE DAS NOCH BESSER LÖSEN
 */
        CreateSudoku sudoku = new CreateSudoku();
        SudokuPrinter printer = new SudokuPrinter(sudoku);
        SudokuKiBeginner flo = new SudokuKiBeginner(sudoku);


        /*
        Inizialiesiert das original von Thomas
         */
            CreateSudoku original = new CreateSudoku();
            SudokuPrinter printy = new SudokuPrinter(original);
            SudokuKiBeginner thomas = new SudokuKiBeginner(original);


             /*
        Inizialiesiert das original von Thomas
         */
            CreateSudoku neu = new CreateSudoku();
            SudokuPrinter newprint = new SudokuPrinter(neu);
            SudokuKiBeginner newflo = new SudokuKiBeginner(neu);


        sudoku.add(0, 2, 6);
        sudoku.add(0, 3, 1);
        sudoku.add(0, 8, 4);

        sudoku.add(1, 0, 7);
//        sudoku.add(1, 4, 2);
        sudoku.add(1, 7, 5);

        sudoku.add(2, 0, 4);
        sudoku.add(2, 5, 9);
        sudoku.add(2, 7, 8);

        sudoku.add(3, 2, 4);
        sudoku.add(3, 7, 1);
        sudoku.add(3, 8, 5);

        sudoku.add(4, 0, 2);
        sudoku.add(4, 8, 7);

        sudoku.add(5, 0, 3);
        sudoku.add(5, 1, 1);
        sudoku.add(5, 6, 9);

        sudoku.add(6, 1, 2);
        sudoku.add(6, 3, 9);
        sudoku.add(6, 8, 8);

        sudoku.add(7, 1, 4);
        sudoku.add(7, 4, 5);
        sudoku.add(7, 8, 3);

        sudoku.add(8, 0, 9);
        sudoku.add(8, 5, 4);
        sudoku.add(8, 6, 7);

        original.add(2, 0, 2);
            original.add(4, 0, 1);
            original.add(5, 0, 7);
            original.add(6, 0, 4);
            original.add(8, 0, 3);

            original.add(0, 1, 7);
            original.add(1, 1, 8);
            original.add(8, 1, 1);

            original.add(4, 2, 8);
            original.add(8, 2, 9);

            original.add(2, 3, 9);
            original.add(4, 3, 7);
            original.add(6, 3, 8);
            original.add(7, 3, 1);

            original.add(1, 4, 6);
            original.add(2, 4, 3);
            original.add(3, 4, 8);
            original.add(5, 4, 2);
            original.add(6, 4, 5);
            original.add(7, 4, 4);

            original.add(1, 5, 7);
            original.add(2, 5, 8);
            original.add(4, 5, 4);
            original.add(6, 5, 9);

            original.add(0, 6, 3);
            original.add(4, 6, 5);

            original.add(0, 7, 2);
            original.add(7, 7, 7);
            original.add(8, 7, 4);

            original.add(0, 8, 8);
            original.add(2, 8, 6);
            original.add(3, 8, 7);
            original.add(4, 8, 3);
            original.add(6,8,2);




            neu.add(0,2, 9);
            neu.add(0, 3, 7);
            neu.add(0, 5, 5);
            neu.add(0, 6, 1);
            neu.add(0, 7, 3);

            neu.add(1, 3, 9);
            neu.add(1, 5, 6);
            neu.add(1, 6, 5);

            neu.add(2, 2, 5);
            neu.add(2, 8, 8);

            neu.add(3, 2, 1);
            neu.add(3, 4, 9);
            neu.add(3, 6, 6);
            neu.add(3, 7, 7);

            neu.add(4, 2, 8);
            neu.add(4, 3, 5);
            neu.add(4, 7, 9);

            neu.add(5, 0, 2);
            neu.add(5, 3, 4);
            neu.add(5, 5, 3);

            neu.add(7, 0, 1);
            neu.add(7, 2, 6);
            neu.add(7, 3, 3);
            neu.add(7, 6, 4);
            neu.add(7, 8, 5);

            neu.add(8, 4, 1);
            neu.add(8, 6, 3);
            neu.add(8, 8, 6);



        System.out.println("____________________________________________________________________________________");
        System.out.println("Sudoku 1: DAS ORIGINAL");
        printy.printArray();
        thomas.expiration();
        printy.printArray();

        System.out.println("____________________________________________________________________________________");
        System.out.println("Sudoku 2:");
        printer.printArray();
        flo.expiration();
        printer.printArray();
        System.out.println("____________________________________________________________________________________");

            System.out.println("____________________________________________________________________________________");
            System.out.println("Sudoku 3: DAS NEUE");
            newprint.printArray();
            newflo.expiration();
            newprint.printArray();




    }
}
