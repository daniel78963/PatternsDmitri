namespace ConsolePatternsNETFramework
{
    public class Rectangle
    {
        public Rectangle(int width, int heigth)
        {
            Width = width;
            Heigth = heigth;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Heigth)}: {Heigth}";
        }

        public int Width { get; }
        public int Heigth { get; }
    }
}
