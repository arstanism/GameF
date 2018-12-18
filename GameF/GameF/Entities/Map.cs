namespace GameF.Entities
{
    public class Map
    {
        public int Size { get; set; }

        public int[,] Grid { get; set; }

        public Map(int size)
        {
            this.Size = size;
            this.Grid = new int[size, size];
        }

        public int this[int x, int y]
        {
            get { return this.Grid[x, y]; }
            set { this.Grid[x, y] = value; }
        }
    }
}
