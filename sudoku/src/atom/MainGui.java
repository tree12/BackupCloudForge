package atom;

import atom.gui.BlackWhiteFilterOp;
import atom.gui.Circle;
import atom.gui.MainFrame;

import javax.imageio.ImageIO;
import java.awt.*;
import java.awt.image.BufferedImage;
import java.awt.image.BufferedImageFilter;
import java.io.File;
import java.io.IOException;
import java.util.Set;
import java.util.Vector;

/**
 * Created by atom on 31.03.2015.
 */
public class MainGui {
    public static void main(String[] args) throws IOException{

        BufferedImage image = ImageIO.read(new File("image1.jpg"));

        MainFrame frame = new MainFrame();
        frame.setImage(image);
        frame.setVisible(true);

        BlackWhiteFilterOp blackWhiteFilterOp = new BlackWhiteFilterOp();
        BufferedImage resultImage = blackWhiteFilterOp.filter(image, null);
        frame.setImage(resultImage);

        Circle c = new Circle(100,100,50);
        Set<Point> points = c.getPointsInCircle();
        for (Point p:points) {
            resultImage.setRGB((int) p.getX(),(int) p.getY(),0xFF0000);
        }


        /*
        HoughTransform ht= new HoughTransform(resultImage.getWidth(),resultImage.getHeight());
        ht.addPoints(resultImage);
        Vector<HoughLine> lines = ht.getLines(1);
        for (HoughLine line:lines) {
            line.draw(resultImage,0xff0000);
        }*/
        frame.repaint();
    }


}
