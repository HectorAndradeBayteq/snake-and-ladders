using Domain.Utils;

namespace Domain.Entities
{
    public class Square
    {
        public Square(int id, int? linkedSquareId)
        {
            if (linkedSquareId.HasValue && linkedSquareId.Value == id)
            {
                throw new Exception("Square cannot be linked to itself. Square Id: " + id);
            }
            this.Id = id;
            this.LinkedSquareId = linkedSquareId;
        }

        public int Id { get; }
        public int? LinkedSquareId { get; }

        public SquareType Type
        {
            get
            {
                var squareType = SquareType.Normal;
                if (!LinkedSquareId.HasValue)
                    return squareType;
                if (Id > LinkedSquareId.Value)
                    squareType = SquareType.Snake;
                if (Id < LinkedSquareId.Value)
                    squareType = SquareType.Ladder;

                return squareType;
            }
        }
    }
}
