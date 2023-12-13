package guiKlassen;

import logik.CreateSudoku;
import logik.Sudoku.sudokuDataChangeListener;
import logik.SudokuKiBeginner;

import javax.swing.*;
import javax.swing.event.MouseInputListener;
import java.awt.*;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.awt.event.MouseEvent;
import java.util.HashMap;

/**
 * Created by Florian on 26.02.2015.
 */
@SuppressWarnings("ALL")
public class SudokuJPanel extends JPanel {

    final static int CUBEINTERN = 7;
    final static int CUBEEND = 17;
    static final int X_INDEX = 0;
    static final int Y_INDEX = 1;
    private SudokuTextField tblSudoku;
    private JPanel panSmall;
    private HashMap<Integer, JTextField> sudokuTextFieldList = new HashMap<Integer, JTextField>();
    private CreateSudoku sudoku;
    private SudokuKiBeginner ki;


    public SudokuJPanel(CreateSudoku sudoku1, SudokuKiBeginner sudokuKiBeginner) {
        buildWidgets();
        this.ki = sudokuKiBeginner;
        sudoku = sudoku1;
        ki.fillAllFreeNumbers();
        sudoku.addSudokuDataChangeListener(new sudokuDataChangeListener() {
            @Override
            public void dataChanged(int pos, int oldValue, int newValue) {
                setText(pos, newValue);
            }
        });
    }

    /*
    Veränderrt die größe der Schrift mit.
     */
    @Override
    protected void paintComponent(Graphics g) {
        for (int index = 0; index < 81; index++) {
            JTextField txt = sudokuTextFieldList.get(index);
            txt.setFont(tblSudoku.getFont().deriveFont(Font.ITALIC, tblSudoku.getHeight() - 3));
        }

    }

    public void setText(int pos, int value) {
        if (value != 0) {
            sudokuTextFieldList.get(pos).setText(Integer.toString(value));
        }
        if (value == 0){
            sudokuTextFieldList.get(pos).setText(null);
        }
    }


    /*
    Zeichnet das Sudoku auf dem Panel und speichert die einzelnen Textfelder in einem Hashtable.
     */
    private void buildWidgets() {
        int indexCounter = 0;
        int gridCount = 0;
        int cubeCount = 0;
        setLayout(new GridLayout(3, 3, 6, 6));
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                panSmall = new JPanel();
                panSmall.setLayout(new GridLayout(3, 3));
                panSmall.setBorder(BorderFactory.createLineBorder(Color.BLACK, 3));
                add(panSmall);
                for (int x = 0; x < 3; x++) {
                    for (int y = 0; y < 3; y++) {
                        tblSudoku = new SudokuTextField(indexCounter);
                        panSmall.add(tblSudoku);
                        tblSudoku.setBorder(BorderFactory.createLineBorder(Color.DARK_GRAY, 1));
                        sudokuTextFieldList.put(indexCounter, tblSudoku);
                        tblSudoku.setHorizontalAlignment(SwingConstants.CENTER);
                        tblSudoku.setPreferredSize(new Dimension(35, 35));
                        gridCount++;
                        if (gridCount == 3 || gridCount == 6) {
                            indexCounter = indexCounter + CUBEINTERN;

                        } else if (gridCount == 9 && cubeCount != 2) {
                            indexCounter = indexCounter - CUBEEND;
                            cubeCount++;
                            gridCount = 0;

                        } else if (gridCount == 9 && cubeCount == 2) {
                            cubeCount = 0;
                            gridCount = 0;
                            indexCounter++;
                        } else {
                            indexCounter++;
                        }
                        tblSudoku.addKeyListener(new SudokuTextListener(tblSudoku));
                        tblSudoku.addMouseListener(new SudokuMousePosition(tblSudoku));

                    }

                }

            }
        }
    }


    @Override
    public void setEnabled(boolean enabled) {
        super.setEnabled(enabled);

        for (int index = 0; index < 81; index++) {
            JTextField txt = sudokuTextFieldList.get(index);
            txt.setEnabled(enabled);

        }

    }

    private class SudokuMousePosition implements MouseInputListener {
        SudokuTextField textField;


        private SudokuMousePosition(SudokuTextField textField) {
            this.textField = textField;
        }

        @Override
        public void mouseClicked(MouseEvent e) {


        }

        @Override
        public void mousePressed(MouseEvent e) {

        }

        @Override
        public void mouseReleased(MouseEvent e) {

        }

        @Override
        public void mouseEntered(MouseEvent e) {
            textField.setToolTipText(ki.getFreenumberString(textField.getPosition()));
//            ki.freeNumberPrinter(mouseX,mouseY);
//            System.out.println("Feld: "+textField.getPosition());
//            System.out.println("X: "+ mouseX + "     Y: "+mouseY);

        }

        @Override
        public void mouseExited(MouseEvent e) {

        }

        @Override
        public void mouseDragged(MouseEvent e) {

        }

        @Override
        public void mouseMoved(MouseEvent e) {

        }
    }

    private class SudokuTextListener implements KeyListener {

        SudokuTextField sudokuTxtField;

        private SudokuTextListener(SudokuTextField txtField) {
            sudokuTxtField = txtField;
        }


        @Override
        public void keyTyped(KeyEvent e) {

        }

        @Override
        public void keyPressed(KeyEvent e) {

        }

        @Override
        public void keyReleased(KeyEvent e) {
            sudokuTxtField.setText(String.valueOf(e.getKeyChar()));
            ki.freeNumberPrinter(sudokuTxtField.getPosition());
            int[] coordinates = ki.posBackToCoordinates(sudokuTxtField.getPosition());
            int x = coordinates[X_INDEX];
            int y = coordinates[Y_INDEX];

            int zahl = 0;
            try {
                zahl = Integer.parseInt(sudokuTxtField.getText());
//                System.out.println("X: " + mouseX + "| Y: " + mouseY + "| Zahl: " + Integer.parseInt(sudokuTxtField.getText()));
            } catch (NumberFormatException ex) {
            }
            if (zahl > 0 && zahl < 10) {
                sudoku.add(x, y, zahl);
                ki.fillAllFreeNumbers();

            } else {
                sudokuTxtField.setText("");
                sudoku.delete(x, y);
                ki.fillAllFreeNumbers();
            }
        }

    }


}
