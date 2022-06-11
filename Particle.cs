using System;

namespace c_sharp_fluid_sim;

public class Particle
{
    // position of a particle in x axis (the width of a screen)
    public double X;

    // position of a particle in y axis (the height of a screen)
    public double Y;

    public double radius = 5;
    
    public Vector2D displacementVector;

    public Particle(double x, double y, double radius)
    {

        X = x;
        Y = y;
        this.radius = radius;
        displacementVector = new Vector2D(0, 0);
    }
    
    public double Distance(Particle other)
    {
        return Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
    }

    public void Iterate()
    {
        X += displacementVector.X;
        Y += displacementVector.Y;
    }
}