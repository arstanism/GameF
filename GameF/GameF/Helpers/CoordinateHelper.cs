using GameF.Entities;

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

        public static Coordinate Add(this Coordinate coord, int additingX, int additingY)
        {
            return new Coordinate(coord.X + additingX, coord.Y + additingY);
        }
    }
}