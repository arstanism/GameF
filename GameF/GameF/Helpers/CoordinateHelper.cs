using GameF.Entities;
using System.Collections.Generic;

namespace GameF.Helpers
{
    public static class CoordinateHelper
    {
        public static bool IsOnBoard(this Coordinate coord, int size)
        {
            bool result = true;
            if(coord.X < 0 || coord.X > size - 1)
            {
                result = false;
            }
            else if(coord.Y < 0 || coord.Y > size - 1)
            {
                result = false;
            }

            return result;
        }

        public static IEnumerable<Coordinate> GetCoordinates(this Coordinate coord, int size)
        {
            for(coord.Y = 0; coord.Y < size; coord.Y++)
            {
                for(coord.X = 0; coord.X < size;coord.X++)
                {
                    yield return coord;
                }
            }
        }

        public static Coordinate Add(this Coordinate coord, int sx, int sy)
        {
            return new Coordinate(coord.X + sx, coord.Y + sy);
        }
    }
}