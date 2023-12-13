package guiKlassen;


import logik.CreateSudoku;
import logik.SudokuKiBeginner;
import logik.SudokuPrinter;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.io.*;
import java.util.HashMap;
import java.util.Set;

/**
 * Created by Florian on 23.02.2015.
 */
public class SudokuJFrame extends JFrame {

    private JLabel labSudokuHead;
    private JProgressBar progSudoku;
    private JPanel panCenterField;
    private SudokuJPanel panCenterNew;
    private SudokuJPanel panCenterSolved;
    private JPanel panLeftSide;
    private JPanel panLeftUP;
    private JPanel panRightSide;
    private JButton butCalculate;
    private JButton butEnd;
    private JButton butOk;
    private JComboBox cboxChooser;
    private JLabel labAction;
    private JLabel labEmpty1;
    private JLabel labEmpty2;
    private JLabel labEmpty3;
    private SudokuKiBeginner sudokuKi;
    private CreateSudoku sudoku;
    private JLabel labDatenTyp;
    private JTextField fldDateiName;
    private JComboBox cBoxFileChooser;
    private JLabel labDatei;
    private HashMap<String, int[][]> fileList;
    private ObjectOutputStream outputStream = null;
    private ObjectInputStream inputStream = null;
    private Object[] listItems;



    public SudokuJFrame() {
        sudoku = new CreateSudoku();
        sudokuKi = new SudokuKiBeginner(sudoku);
        fileList = new HashMap<String, int[][]>();
        setTitle("SUDOKU");
        setDefaultCloseOperation(JFrame.DO_NOTHING_ON_CLOSE);
        setLocation(650, 100);
        setVisible(true);
        createWidgets();
        addWidgets();
        handleInteractions();
        pack();
       loadGame();
        WindowListener sudokuWindowListener = new WindowAdapter() {
            @Override
            public void windowClosing(WindowEvent e) {
               saveGame();
                System.out.println("WILLST DU WIRKLICH BEENDEN?");
                System.exit(0);

            }
        };
        addWindowListener(sudokuWindowListener);


    }

    private void saveGame(){
        try {
            outputStream = new ObjectOutputStream(new FileOutputStream("sudokuList.dat"));
            outputStream.writeObject(fileList);
        } catch (IOException e1) {
            e1.printStackTrace();
            System.out.println("WAS WILLST DU VON MIR ICH BIN DEIN STACKTRACE?");
        }
    }

    private void saveSudokuArray(){

        if(fldDateiName.getText() != null) {
            fileList.put(fldDateiName.getText(), sudoku.array());
            cBoxFileChooser.addItem(fldDateiName.getText());
        }else{
System.out.println("DATEINAME EINGEBEN SONST GEHT DA NIX!");
            //TODO Messagebox muss programmiert werden
        }
    }


    private void loadGame(){
        Set<String> keyset;
        try {

            inputStream = new ObjectInputStream(new FileInputStream("sudokuList.dat"));
            fileList = (HashMap<String, int[][]>) inputStream.readObject();
            System.out.println(fileList.keySet());
            keyset = fileList.keySet();
            listItems = new Object[fileList.size()];
            listItems = keyset.toArray();
            for (int i = 0; i < listItems.length; i++) {
                System.out.println(listItems[i]);
                cBoxFileChooser.addItem(listItems[i]);
            }

        } catch (Exception e) {
            new File("sudokuList.dat");
        }
    }

    private void loadSudokuArray(){
        sudoku.setArray(fileList.get(cBoxFileChooser.getSelectedItem()));
    }

    private void clearSudokuArray(){
        fileList.remove(cBoxFileChooser.getSelectedItem());
        cBoxFileChooser.removeItem(cBoxFileChooser.getSelectedItem());
        sudoku.newSudoku();
    }

    private void addWidgets() {

        getContentPane().setLayout(new BorderLayout(10, 10));
        getContentPane().add(labSudokuHead, BorderLayout.PAGE_START);
        getContentPane().add(progSudoku, BorderLayout.PAGE_END);
        getContentPane().add(panCenterField, BorderLayout.CENTER);
        getContentPane().add(panLeftSide, BorderLayout.LINE_START);
        getContentPane().add(panRightSide, BorderLayout.LINE_END);

        panCenterField.add(panCenterNew);
        panCenterField.add(panCenterSolved);

        panLeftSide.add(panLeftUP);
        panLeftSide.add(Box.createVerticalGlue());
        panLeftSide.add(butEnd);

        panLeftUP.add(labEmpty2);
        panLeftUP.add(butCalculate);
        panLeftUP.add(labAction);
        panLeftUP.add(cboxChooser);
        panLeftUP.add(fldDateiName);
        panLeftUP.add(labDatenTyp);
        panLeftUP.add(labDatei);
        panLeftUP.add(cBoxFileChooser);
        panLeftUP.add(labEmpty1);
        panLeftUP.add(butOk);

        panLeftUP.add(Box.createVerticalGlue());
        panLeftUP.setAlignmentX(LEFT_ALIGNMENT);
        panLeftUP.setMaximumSize(panLeftSide.getPreferredSize());
    }

    private void handleInteractions() {
        butEnd.addActionListener(new SudokuActionEndListener());
        butOk.addActionListener(new SudokuActionBestaetigeListener());
        butCalculate.addActionListener(new SudokuActionBerechneListener());
        cboxChooser.addActionListener(new SudokuComponentHideListener());

    }

    private void createWidgets() {
        labSudokuHead = new JLabel("SUDOKU");
        labSudokuHead.setFont(labSudokuHead.getFont().deriveFont(Font.BOLD, 30));
        labSudokuHead.setForeground(Color.WHITE);
        labSudokuHead.setBackground(Color.RED);
        labSudokuHead.setOpaque(true);
        labSudokuHead.setHorizontalAlignment(SwingConstants.CENTER);
        labSudokuHead.setBorder(BorderFactory.createLineBorder(Color.BLACK, 3, true));

        progSudoku = new JProgressBar(0, 100);
        progSudoku.setBorder(BorderFactory.createLineBorder(Color.BLACK, 3, true));
        progSudoku.setPreferredSize(new Dimension(0, 30));
        progSudoku.setString(progSudoku.getValue() + "%");

        panCenterField = new JPanel();
        panCenterField.setLayout(new GridLayout(2, 1, 10, 20));
        panCenterNew = new SudokuJPanel(sudoku, sudokuKi);
        panCenterNew.setBorder(new SudokuLineBorder(panCenterField.getBackground(), true));
        panCenterSolved = new SudokuJPanel(sudoku, sudokuKi);
        panCenterSolved.setBorder(new SudokuLineBorder(panCenterField.getBackground(), true));
        panCenterSolved.setEnabled(false);

        panLeftSide = new JPanel();
        panLeftSide.setLayout(new BoxLayout(panLeftSide, BoxLayout.PAGE_AXIS));
        panLeftSide.setBorder(BorderFactory.createLineBorder(panLeftSide.getBackground(), 10));

        panLeftUP = new JPanel();
        panLeftUP.setLayout(new GridLayout(6, 1));

        panRightSide = new JPanel();
        panRightSide.setLayout(new BoxLayout(panRightSide, BoxLayout.PAGE_AXIS));
        panRightSide.setBorder(BorderFactory.createLineBorder(panRightSide.getBackground(), 10));

        labAction = new JLabel("Aktion:");
        labEmpty1 = new JLabel();
        labEmpty2 = new JLabel();
        labEmpty3 = new JLabel();

        butEnd = new JButton("Close");

        butCalculate = new JButton("Berechne");

        butOk = new JButton("Bestätige");
        butOk.setVisible(false);

        cboxChooser = new JComboBox(new Object[]{"", "speichern", "laden", "löschen", "einscannen", "neu"});

        labDatenTyp = new JLabel(" NAME SUDOKU");
        labDatenTyp.setVisible(false);

        fldDateiName = new JTextField();
        fldDateiName.setVisible(false);

        labDatei = new JLabel("DATEI:");
        labDatei.setVisible(false);

        cBoxFileChooser = new JComboBox<String>();
        cBoxFileChooser.setVisible(false);


    }

    private class SudokuActionEndListener implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {

          saveGame();
            System.exit(0);

        }
    }

    private class SudokuActionBestaetigeListener implements ActionListener {
        String operation;

        @Override
        public void actionPerformed(ActionEvent e) {
            operation = (String) cboxChooser.getItemAt(cboxChooser.getSelectedIndex());

            if ("speichern".equals(operation)) {
                saveSudokuArray();
                saveGame();

            } else if ("laden".equals(operation)) {
                loadSudokuArray();

            } else if ("löschen".equals(operation)) {
                clearSudokuArray();


            } else if ("einscannen".equals(operation)) {
                System.out.println("wird eingescannt");
                // TODO

            } else if ("neu".equals(operation)) {
                sudoku.newSudoku();


            } else {
                System.out.println(" Bitte auswählen!!!!!!");
                //TODO es sollte ein Popup erscheinen welches einen daran errinnert dass man etwas auswählen muss...
            }
            butOk.setVisible(false);
            labDatenTyp.setVisible(false);
            labDatei.setVisible(false);
            cBoxFileChooser.setVisible(false);
            fldDateiName.setVisible(false);
        }
    }

    private class SudokuComponentHideListener implements ActionListener {
        String operation;

        @Override
        public void actionPerformed(ActionEvent e) {
            operation = (String) cboxChooser.getItemAt(cboxChooser.getSelectedIndex());
            if ("speichern".equals(operation)) {
                labDatenTyp.setVisible(true);
                fldDateiName.setVisible(true);
                butOk.setVisible(true);
                labDatei.setVisible(false);
                cBoxFileChooser.setVisible(false);
            } else if ("laden".equals(operation)) {
                labDatei.setVisible(true);
                cBoxFileChooser.setVisible(true);
                butOk.setVisible(true);
                labDatenTyp.setVisible(false);
                fldDateiName.setVisible(false);
            } else if ("löschen".equals(operation)) {
                labDatei.setVisible(true);
                cBoxFileChooser.setVisible(true);
                butOk.setVisible(true);
                labDatenTyp.setVisible(false);
                fldDateiName.setVisible(false);
            } else if ("einscannen".equals(operation)) {
                labDatei.setVisible(false);
                cBoxFileChooser.setVisible(false);
                butOk.setVisible(true);
                labDatenTyp.setVisible(false);
                fldDateiName.setVisible(false);
            } else if ("neu".equals(operation)) {
                labDatei.setVisible(false);
                cBoxFileChooser.setVisible(false);
                butOk.setVisible(true);
                labDatenTyp.setVisible(false);
                fldDateiName.setVisible(false);
            } else {
                labDatei.setVisible(false);
                cBoxFileChooser.setVisible(false);
                butOk.setVisible(false);
                labDatenTyp.setVisible(false);
                fldDateiName.setVisible(false);
            }

        }
    }


    private class SudokuActionBerechneListener implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            SudokuPrinter printer = new SudokuPrinter(sudoku);
            System.out.println("____________________________________________________________________________________");
            System.out.println("Sudoku 2:");
            printer.printArray();
            sudokuKi.expiration();
            printer.printArray();
            System.out.println("____________________________________________________________________________________");


        }
    }
}
