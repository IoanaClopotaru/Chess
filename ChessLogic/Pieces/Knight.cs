using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Knight : Piece
    {

        public override PieceType Type => PieceType.Knight;
        public override Player Color { get; }

        public Knight(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            Knight copy = new Knight(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
        private static IEnumerable<Position> PotentialToPositions(Position from)
        {
            
            yield return from + Direction.North + Direction.North + Direction.East;
            yield return from + Direction.North + Direction.North + Direction.West;
            yield return from + Direction.South + Direction.South + Direction.East;
            yield return from + Direction.South + Direction.South + Direction.West;

            
            yield return from + Direction.East + Direction.East + Direction.North;
            yield return from + Direction.East + Direction.East + Direction.South;
            yield return from + Direction.West + Direction.West + Direction.North;
            yield return from + Direction.West + Direction.West + Direction.South;
        }

        private IEnumerable<Position> MovePositions(Position from, Board board)
        {
            return PotentialToPositions(from).Where(pos =>  Board.IsInside(pos)  && (board.IsEmpty(pos) || board[pos].Color != Color));
        }
        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovePositions(from, board).Select(to => new NormalMove(from, to));
        }

    }
}
