package guiKlassen;

import javax.swing.border.AbstractBorder;
import java.awt.*;
import java.awt.geom.Path2D;
import java.awt.geom.Rectangle2D;


/**
 * Created by Florian on 02.03.2015.
 */
public class SudokuLineBorder extends AbstractBorder {

    protected Color color;
    protected boolean isMyBorder;
    protected int widthOffSet;
    protected int heightOffSet;


    public SudokuLineBorder(Color color, boolean isMyBorder) {
        this.color = color;
        this.isMyBorder = isMyBorder;
    }

    public int getHeightOffSet() {
        return heightOffSet;
    }

    public void setHeightOffSet(int heightOffSet) {
        this.heightOffSet = heightOffSet;
    }


    public int getWidthOffSet() {
        return widthOffSet;
    }

    public void setWidthOffSet(int widthOffSet) {
        this.widthOffSet = widthOffSet;
    }


    private boolean isMyBorder() {
        return isMyBorder;
    }


    @Override
    public void paintBorder(Component c, Graphics g, int x, int y, int width, int height) {
//        super.paintBorder(c, g, x, y, width, height);
        Graphics2D g2d = (Graphics2D) g;
        g2d.setColor(color);
        Shape outlines;
        Shape innlines;


        int widthOffSet = 0;
        int heightOffSet = 0;


        if (height > width) {
            heightOffSet = (height - width + 10) / 2;
            widthOffSet = 10;
        }
        if (height < width) {
            heightOffSet = 10;
            widthOffSet = (width - height + 10) / 2;

        }
        int xSize = widthOffSet + widthOffSet;
        int ySize = heightOffSet + heightOffSet;

        outlines = new Rectangle2D.Float(x, y, width, height);
        innlines = new Rectangle2D.Float(x + widthOffSet, y + heightOffSet, width - xSize, height - ySize);

        Path2D path = new Path2D.Float(Path2D.WIND_EVEN_ODD);

        path.append(outlines, false);
        path.append(innlines, false);
        g2d.setColor(color);
        g2d.fill(path);

    }

    @Override
    public Insets getBorderInsets(Component c, Insets insets) {
        int widthOffSet = 0;
        int heightOffSet = 0;

        int height = c.getHeight();
        int width = c.getWidth();

        if (height > width) {
            heightOffSet = (height - width + 10) / 2;
            widthOffSet = 10;
        }
        if (height < width) {
            heightOffSet = 10;
            widthOffSet = (width - height + 10) / 2;

        }
        insets.right = insets.left = widthOffSet;
        insets.top = insets.bottom = heightOffSet;

        return insets;
    }

}






