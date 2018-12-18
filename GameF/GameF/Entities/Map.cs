namespace GameF.Entities
{
    public class Board
    {
        public int Size { get; set; }

        public int[,] Grid { get; set; }

        public Board(int size)
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