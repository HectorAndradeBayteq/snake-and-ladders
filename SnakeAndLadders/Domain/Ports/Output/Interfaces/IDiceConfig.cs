namespace Domain.Ports.Output.Interfaces
{
    public interface IDiceConfig
    {
        IEnumerable<int>? SimulationSequence { get; }
        int FirstFaceValue { get; }
        int QuantityOfFaces { get; }
    }
}
