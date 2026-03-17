using System;
using System.Collections.Generic;

Console.WriteLine("=== 동등성 비교 ===");
Color color1 = new(255, 0, 0);
Color color2 = new(255, 0, 0);
Color color3 = new(0, 0, 255);
Console.WriteLine($"RGB(255, 0, 0) == RGB(255, 0, 0): {color1.Equals(color2)}");
Console.WriteLine($"RGB(255, 0, 0) == RGB(0, 0, 255): {color1.Equals(color3)}");

Console.WriteLine("\n=== 유사 색상 판정 ===");
Color color4 = new(250, 5, 3);
Color color5 = new(200, 50, 50);
Console.WriteLine($"RGB(255, 0, 0)과 RGB(250, 5, 3)은 유사한가 (임계값 10): {color1.IsSimilar(color4, 10)}");
Console.WriteLine($"RGB(255, 0, 0)과 RGB(200, 50, 50)은 유사한가 (임계값 10): {color1.IsSimilar(color5, 10)}");

Console.WriteLine("\n=== HashSet 중복 제거 ===");
HashSet<Color> colors = new() { color1, color1, new Color(0, 255, 0), color3 };
Console.WriteLine("팔레트에 추가된 색상: ");
foreach (Color color in colors) Console.WriteLine(color);
Console.WriteLine($"색상 수: {colors.Count}");

Console.WriteLine($"\nRGB(255, 0, 0) 포함 여부: {colors.Contains(new Color(255, 0, 0))}");

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

    public override string ToString() => $"RGB({R}, {G}, {B})";

    public bool IsSimilar(Color other, int threshold)
    {
        if (Math.Abs(R - other.R) <= threshold 
            && Math.Abs(G - other.G) <= threshold
            && Math.Abs(B - other.B) <= threshold) return true;

        return false;
    }

    public bool Equals(Color other)
    {
        return R == other.R && G == other.G && B == other.B;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Color);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(R, G, B);
    }
}