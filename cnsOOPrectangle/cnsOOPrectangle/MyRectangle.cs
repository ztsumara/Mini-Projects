namespace cnsOOPrectangle
{
    internal class MyRectangle
    {
        private int length;
        private int width;

        public MyRectangle()
        {
            length = 10;
            width = 10;
        }

        public MyRectangle(int length, int width)
        {
            this.length = length;
            this.width = width;
        }

        internal int GetArea()
        {
            return 123;
        }
    }
}