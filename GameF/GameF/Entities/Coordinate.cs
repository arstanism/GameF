namespace GameF.Entities
{
    public class Coordinate
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Coordinate(int size)
        {
            this.X = size - 1;
            this.Y = size - 1;
        }

        public override bool Equals(object obj)
        {
            return obj != null &&
                   obj is Coordinate &&
                   this.GetType() == obj.GetType() &&
                   this.GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return this.X ^ this.Y;
        }
    }
}
