package atom.gui;

import java.awt.*;
import java.awt.image.BufferedImage;
import java.util.Set;
import java.util.Vector;

/**
 * Created by atom on 31.03.2015.
 */
public class EdgeTransform {

    private int minR = 3;
    private int maxR = 10;

    Vector<Point> points = new Vector<Point>(100);

    public EdgeTransform() {
    }

    /**
     * Find junktion points of possible lines in a black-white image (no grayscale!)
     *
     * @param image
     * @return
     */
    public Vector<Point> findPoints(BufferedImage image) {
        for (int x = minR; x < image.getWidth() - minR; x += minR)
            imageLoop:for (int y = minR; y < image.getHeight() - minR; y += minR) {
                for (int r = minR; r <= maxR; r++) {
                    if (isPointInRadius(x, y, r)) continue imageLoop;
                }
            }
        return points;
    }

    private boolean isPointInRadius(int x, int y, int r) {
        Circle circle = new Circle(x, y, r);

        for (Point p : points) {
            if (circle.isPointInRadius(p)) return true;
        }
        return false;
    }
}
