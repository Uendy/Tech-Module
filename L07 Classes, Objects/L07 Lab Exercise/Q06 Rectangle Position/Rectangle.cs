
using System;

public class Rectangle
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Bottom => Math.Abs(Top - Height); // Dont forget math.Abs 83/100 -> 100/100
        public int Right => Math.Abs(Left + Width);

        public bool IsInside(Rectangle firstRectangle, Rectangle secondRectangle)
        {
            return (firstRectangle.Left >= secondRectangle.Left) && (firstRectangle.Right <= secondRectangle.Right) && (firstRectangle.Top <= secondRectangle.Top) && (firstRectangle.Bottom <= secondRectangle.Bottom);
        }
    }

