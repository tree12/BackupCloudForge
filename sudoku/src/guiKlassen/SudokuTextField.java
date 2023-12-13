package guiKlassen;

import javax.swing.*;

/**
 * Created by Florian on 11.03.2015.
 */
public class SudokuTextField extends JTextField {

    private int position;

    public SudokuTextField(int pos) {
        this.position = pos;
    }

    public int getPosition() {
        return position;
    }

    public void setText(int position, String string) {
        this.position = position;
        setText(string);
    }


}
