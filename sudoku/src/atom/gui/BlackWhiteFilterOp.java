package atom.gui;

import java.awt.*;
import java.awt.geom.Point2D;
import java.awt.geom.Rectangle2D;
import java.awt.image.BufferedImage;
import java.awt.image.BufferedImageOp;
import java.awt.image.ColorModel;

/**
 * Created by atom on 31.03.2015.
 */
public class BlackWhiteFilterOp implements BufferedImageOp {
    @Override
    public BufferedImage filter(BufferedImage src, BufferedImage dest) {
        if (dest==null) dest=createCompatibleDestImage(src,null);

        int middleGrayValue=0;
        for (int x=0;x<src.getWidth();x++)
            for(int y=0;y<src.getHeight();y++) {
                middleGrayValue+=getGrayValue(src.getRGB(x,y));
            }
        middleGrayValue=middleGrayValue/(src.getWidth()*src.getWidth());

        for (int x=0;x<src.getWidth();x++)
            for(int y=0;y<src.getHeight();y++) {
                int grayValue = getGrayValue(src.getRGB(x,y));
                dest.setRGB(x,y,grayValue<middleGrayValue?0x0:0xFFFFFF);
            }

        return dest;
    }

    private int getGrayValue(int rgb) {
        int r = (rgb >> 16) & 0xFF;
        int g = (rgb >> 8) & 0xFF;
        int b = rgb & 0xFF;
        return (r+b+g)/3;
    }

    @Override
    public Rectangle2D getBounds2D(BufferedImage src) {
        return new Rectangle(0,0,src.getWidth(),src.getHeight()).getBounds2D();
    }

    @Override
    public BufferedImage createCompatibleDestImage(BufferedImage src, ColorModel destCM) {
        BufferedImage image = new BufferedImage(src.getWidth(),src.getHeight(), src.getType());
        return image;
    }

    @Override
    public Point2D getPoint2D(Point2D srcPt, Point2D dstPt) {
        if (dstPt!=null) dstPt=srcPt;
        return srcPt;
    }

    @Override
    public RenderingHints getRenderingHints() {
        return null;
    }
}
