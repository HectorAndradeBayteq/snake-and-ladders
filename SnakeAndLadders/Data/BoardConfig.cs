using Domain.Ports.Output.Interfaces;

namespace Data
{
    public class BoardConfig : IBoardConfig
    {
        public BoardConfig(int totalSquares)
        {
            TotalSquares = totalSquares;
            SquaresRelations = new Dictionary<int, int?>() {
              { 99,80 },
              { 95,75 },
              { 92,88 },
              { 89,68 },
              { 87,94 },
              { 78,98 },
              { 74,53 },
              { 71,91 },
              { 64,60 },
              { 62,19 },
              { 51,67 },
              { 49,11 },
              { 46,25 },
              { 36,44 },
              { 28,84 },
              { 21,42 },
              { 16,6  },
              { 15,26 },
              {  8,31 },
              {  7,14 },
              {  2,38 }
            };
        }
        public int TotalSquares { get; }

        public Dictionary<int, int?> SquaresRelations { get; }
    }
}
