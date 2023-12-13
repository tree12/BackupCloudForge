package atom.gui;

import java.awt.*;
import java.util.HashSet;
import java.util.Set;
import java.util.Vector;

/**
 * Created by atom on 31.03.2015.
 */
public class Circle {
    int x,y,r;
    public Circle(int x, int y, int r) {
        this.x=x;
        this.y=y;
        this.r=r;
    }

    public Set<Point> getPointsAroundCircle(){
        return getPointsAroundCircle(r);
    }

    private Set<Point> getPointsAroundCircle(int r){
        int steps = (int) ((2*Math.PI*r)/4);
        double radianStep = (Math.PI/2)/steps;
        HashSet<Point>points=new HashSet<Point>(steps*4);
        for (int i=0;i<steps;i++) {
            double radians=i*radianStep;
            int addX=(int)(Math.cos(radians)*r);
            int addY=(int)(Math.sin(radians)*r);
            points.add(new Point(x-addX,y+addY));
            points.add(new Point(x+addX,y+addY));
            points.add(new Point(x+addX,y-addY));
            points.add(new Point(x-addX,y-addY));
        }
        return points;
    }

    /*
    public Set<Point> getPointsInCircle() {
        HashSet<Point>points=new HashSet<Point>((int)(Math.PI*r*r+r));
        points.add(new Point(x,y));
        for (int r1=1;r1<=r;r1++) {
            points.addAll(getPointsAroundCircle(r1));
        }
        return points;
    }
    */

    public Set<Point> getPointsInCircle() {
        HashSet<Point>points=new HashSet<Point>();
        for (int addX=0;addX<=r;addX++)
            for (int addY=0;addY<=r;addY++) {
                if (Math.sqrt(addX*addX+addY*addY)<=r) {
                    points.add(new Point(x-addX,y+addY));
                    points.add(new Point(x+addX,y+addY));
                    points.add(new Point(x+addX,y-addY));
                    points.add(new Point(x-addX,y-addY));
                }
            }
        return points;
    }

    public boolean isPointInRadius(Point point) {
        int addX=(int) Math.abs(x-point.getX());
        int addY=(int) Math.abs(y-point.getY());
        return Math.sqrt(addX*addX+addY*addY)<=r;
    }
}
