using System;

class Color : IEquatable<Color>
{
    int R;
    int G;
    int B;

    public Color(int r, int g, int b)
    {
        R = r; 
        G = g; 
        B = b;
    }

    public bool Equals(Color other)
    {
        return (R == other.R && G == other.G && B == other.B);
    }

    public override bool Equals(object obj)
    {
        return 
    }
}