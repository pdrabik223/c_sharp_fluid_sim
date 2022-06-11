using System;
using System.Configuration;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace c_sharp_fluid_sim;

public class Vector2D
{
    public double X;
    public double Y;
    
    public Vector2D(double x, double y)
    {
        X = x;
        Y = y;
    }
    public static Vector2D operator +(Vector2D a, Vector2D b)
        => new Vector2D(a.X + b.X, a.Y + b.Y);

    public static Vector2D operator -(Vector2D a, Vector2D b)
        => new Vector2D(a.X - b.X, a.Y - b.Y);

    public static Vector2D operator -(Vector2D other)
        => new Vector2D(-other.X, -other.Y);
    
    public static Vector2D operator *(Vector2D a, Vector2D b)
        => new Vector2D(a.X * b.X, a.Y * b.Y);

    public static Vector2D operator /(Vector2D a, Vector2D b)
        => new Vector2D(a.X / b.X, a.Y / b.Y);

    public static double Dot(Vector2D a, Vector2D b)
    {
        return a.X * b.X + a.Y * b.Y;
    }

    public double Length()
    {
        return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
    }

    protected bool Equals(Vector2D other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Vector2D) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
        
}

