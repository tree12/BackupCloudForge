package logik.Sudoku;

import guiKlassen.SudokuJFrame;

import javax.swing.*;

/**
 * Created by Florian on 21.02.2015.
 */
public class SudokuGui {
    public static void main(String[] args){
        try {
            UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName());
        }catch (Exception e){
            e.printStackTrace();
        }
        SudokuJFrame frame = new SudokuJFrame();


    }
}
