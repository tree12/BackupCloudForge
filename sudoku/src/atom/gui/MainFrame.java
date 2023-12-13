package atom.gui;

import atom.Main;

import javax.swing.*;
import java.awt.*;
import java.awt.image.BufferedImage;
import java.util.Set;

/**
 * Created by atom on 31.03.2015.
 */
public class MainFrame extends JFrame {

    BufferedImage image;

    public void setImage(BufferedImage image) {
        this.image=image;
        setSize(image.getWidth(), image.getHeight());
        repaint();
    }


    @Override
    public void paint(Graphics g) {
        super.paint(g);
        g.drawImage(image,0,0,image.getWidth(),image.getHeight(),null);
    }
}
