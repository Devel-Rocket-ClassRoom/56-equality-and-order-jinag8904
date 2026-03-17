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
        throw new NotImplementedException();
    }
}