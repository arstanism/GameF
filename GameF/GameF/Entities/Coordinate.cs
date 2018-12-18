namespace GameF.Entities
{
    public class Coordinate
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Coordinate() { }

        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Coordinate(int size) => this.X = this.Y = size - 1;

        public override bool Equals(object obj)
        {
            return obj is Coordinate coordinate &&
                   this.GetHashCode() == coordinate.GetHashCode() &&
                   this.X == coordinate.X &&
                   this.Y == coordinate.Y;
        }

        public override int GetHashCode() => this.X ^ this.Y;
    }
}
