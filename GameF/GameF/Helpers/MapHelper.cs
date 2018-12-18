using GameF.Entities;

namespace GameF.Helpers
{
    public static class MapHelper
    {
        public static void SetCoordinate(this Map map, Coordinate coord, int value)
        {
            if(coord.IsOnBoard(map.Size))
            {
                map[coord.X, coord.Y] = value;
            }
        }

        public static int GetCoordinate(this Map map, Coordinate coord)
        {
            int value = 0;
            if(coord.IsOnBoard(map.Size))
            {
                value = map[coord.X, coord.Y];
            }

            return value;
        }

        public static void CopyTo(this Map map, Coordinate from, Coordinate to)
        {
            map.SetCoordinate(to, map.GetCoordinate(from));
        }
    }
}