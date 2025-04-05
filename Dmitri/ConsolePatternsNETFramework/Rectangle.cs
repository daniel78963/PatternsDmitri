namespace ConsolePatternsNETFramework
{
    public class Rectangle
    {
        public Rectangle()
        {
                
        }
        public Rectangle(int width, int heigth)
        {
            Width = width;
            Heigth = heigth;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Heigth)}: {Heigth}";
        }

        public virtual int Width { get; set; }
        public virtual int Heigth { get; set; }
    }
}
