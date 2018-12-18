using System;
using GameF.Entities;
using GameF.Helpers;

namespace GameF.Logic
{
    public class Game
    {
        private int Size { get; set; }

        public int Steps { get; private set; }

        private Board Board { get; set; }

        private Coordinate EmptyCoord { get; set; }

        public Game(int size)
        {
            this.Size = size;
            this.Board = new Board(size);
        }

        public void Start(int seed)
        {
            this.EmptyCoord = new Coordinate(this.Size);
            int digit = 0;
            foreach(var coord in new Coordinate().GetCoordinates(this.Size))
            {
                this.Board.SetCoordinate(coord, ++digit);
            }
            
            if(seed > 0)
            {
                Shuffle(seed);
            }

            this.Steps = 0;
        }

        public int PressAt(int x, int y)
        {
            return this.PressAt(new Coordinate(x, y));
        }

        public int PressAt(Coordinate coord)
        {
            if(this.EmptyCoord.Equals(coord))
            {
                return 0;
            }

            if(coord.X != this.EmptyCoord.X &&
               coord.Y != this.EmptyCoord.Y)
            {
                return 0;
            }

            int steps = Math.Abs(coord.X - this.EmptyCoord.X) + Math.Abs(coord.Y - this.EmptyCoord.Y);
            while(coord.X != this.EmptyCoord.X)
            {
                this.Shift(Math.Sign(coord.X - this.EmptyCoord.X), 0);
            }

            while(coord.Y != this.EmptyCoord.Y)
            {
                this.Shift(0, Math.Sign(coord.Y - this.EmptyCoord.Y));
            }

            this.Steps += steps;
            return steps;
        }

        public int GetDigitAt(int x, int y)
        {
            return this.GetDigitAt(new Coordinate(x, y));
        }

        public int GetDigitAt(Coordinate coord)
        {
            int result = 0;
            if(!this.EmptyCoord.Equals(coord))
            {
                result = this.Board.GetCoordinate(coord);
            }

            return result;
        }

        public bool IsSolved()
        {
            if(!this.EmptyCoord.Equals(new Coordinate(this.Size)))
            {
                return false;
            }

            int digit = 0;
            foreach(var coord in new Coordinate().GetCoordinates(this.Size))
            {
                if(this.Board.GetCoordinate(coord) != ++digit)
                {
                    return this.EmptyCoord.Equals(coord);
                }
            }

            return true;
        }

        #region Privates methods
        private void Shift(int sx, int sy)
        {
            var nextCoord = this.EmptyCoord.Add(sx, sy);
            this.Board.Copy(nextCoord, this.EmptyCoord);
            this.EmptyCoord = nextCoord;
        }

        private void Shuffle(int seed)
        {
            var random = new Random(seed);
            for(int i = 0; i < seed; i++)
            {
                this.PressAt(random.Next(this.Size), random.Next(this.Size));
            }
        }
        #endregion
    }
}