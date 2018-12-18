using GameF.Entities;
using GameF.Helpers;
using System;

namespace GameF.Logic
{
    public class Game
    {
        private int Size { get; set; }

        public int Steps { get; private set; }

        private Map Map { get; set; }

        /// <summary>
        /// This is an empty coordinate to determine the end of game.
        /// </summary>
        private Coordinate Space { get; set; }

        public Game(int size)
        {
            this.Size = size;
            this.Map = new Map(size);
        }

        public void Start(int variants)
        {
            int digit = 0;
            foreach(var coord in new Coordinate(0, 0).GetCoordinates(this.Size))
            {
                this.Map.SetCoordinate(coord, ++digit);
            }

            this.Space = new Coordinate(this.Size);

            if(variants > 0)
            {
                Shuffle(variants);
            }

            this.Steps = 0;
        }

        public int PressAt(Coordinate coord)
        {
            if(this.Space.Equals(coord))
            {
                return 0;
            }
            if(coord.X != this.Space.X &&
               coord.Y != this.Space.Y)
            {
                return 0;
            }

            int steps = Math.Abs(coord.X - this.Space.X) + Math.Abs(coord.Y - this.Space.Y);
            while(coord.X != this.Space.X)
            {
                this.Shift(Math.Sign(coord.X - this.Space.X), 0);
            }

            while(coord.Y != this.Space.Y)
            {
                this.Shift(0, Math.Sign(coord.Y - this.Space.Y));
            }

            this.Steps += steps;
            return steps;
        }

        public int GetDigitAt(Coordinate coord)
        {
            int result = 0;
            if(!this.Space.Equals(coord))
            {
                return this.Map.GetCoordinate(coord);
            }

            return result;
        }

        public bool IsSolved()
        {
            if(!this.Space.Equals(new Coordinate(this.Size)))
            {
                return false;
            }

            int digit = 0;
            foreach(var coord in new Coordinate(0, 0).GetCoordinates(this.Size))
            {
                if(this.Map.GetCoordinate(coord) != ++digit)
                {
                    return this.Space.Equals(coord);
                }
            }

            return true;
        }

        #region Privates methods
        private void Shift(int sx, int sy)
        {
            var nextCoord = this.Space.Add(sx, sy);
            this.Map.CopyTo(nextCoord, this.Space);
            this.Space = nextCoord;
        }

        private void Shuffle(int variants)
        {
            var random = new Random(variants);
            for(int i = 0; i < variants; i++)
            {
                var coord = new Coordinate(random.Next(this.Size), random.Next(this.Size));
                this.PressAt(coord);
            }
        }
        #endregion
    }
}