namespace Domain.Ports.Output.Interfaces
{
    public interface IBoardConfig
    {
        int TotalSquares { get; }
        Dictionary<int, int?> SquaresRelations { get; }
    }
}
