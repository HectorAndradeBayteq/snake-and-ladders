using Domain.Utils;

namespace Domain.Entities
{
    internal class Board
    {
        /// <summary>
        /// Class for create a board from a set of relationships between squares and the total number of squares in the board.
        /// </summary>
        /// <param name="squaresRelations">Squares relations in the board. 
        /// Each element in squaresRelations represent ladders or snakes that join two squares in the board.</param>
        /// <param name="totalSquares"> Define a total squares in the board.
        /// totalSquares should be a positive integer and greater or equal than relations in squaresRelations.</param>
        /// <exception cref="ArgumentException">Exception for invalid argument </exception>
        public Board(IReadOnlyDictionary<int, int?> squaresRelations, int totalSquares)
        {
            if (totalSquares < squaresRelations.Count)
                throw new ArgumentException("There are more relations than squares.");
            if (totalSquares < 0)
                throw new ArgumentException("totalSquares should be a positive integer.");
            var squareIds = Enumerable.Range(1, totalSquares).ToList();
            squareIds.ForEach(x => Squares.Add(new Square(x, squaresRelations.ContainsKey(x) ? squaresRelations[x] : null)));
        }

        public List<Square> Squares { get; } = new ();
        public Square GetNextSquare(Square currentSquare, int steps)
        {
            var nextPosition = currentSquare.Id + steps;
            if (nextPosition > Squares.Count) nextPosition = currentSquare.Id;
            var possibleNextSquare = nextPosition >= Squares.Count ? Squares.Last() : Squares[nextPosition-1];
            
            switch (possibleNextSquare.Type)
            {
                case SquareType.Snake: 
                case SquareType.Ladder: 
                    return Squares[possibleNextSquare.LinkedSquareId.Value - 1];
                case SquareType.Normal:
                default:
                    return possibleNextSquare;
            }
        }
    }
}
