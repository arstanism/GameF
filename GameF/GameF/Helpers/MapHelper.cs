using GameF.Entities;

namespace GameF.Helpers
{
    public static class MapHelper
    {
        public static void SetCoordinate(this Board board, Coordinate coord, int value)
        {
            if(coord.IsOnBoard(board.Size))
            {
                board[coord.X, coord.Y] = value;
            }
        }
        
        public static int GetCoordinate(this Board board, Coordinate coord)
        {
            int value = 0;
            if(coord.IsOnBoard(board.Size))
            {
                value = board[coord.X, coord.Y];
            }
        
            return value;
        }
        
        public static void Copy(this Board board, Coordinate fromCoord, Coordinate toCoord)
        {
            int value = board.GetCoordinate(fromCoord);
            board.SetCoordinate(toCoord, value);
        }
    }
}