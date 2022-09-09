using Domain.Ports.Output.Interfaces;

namespace Data
{
    public class DiceSimulatedConfig: IDiceConfig
    {
        public DiceSimulatedConfig(IEnumerable<int> simulationSequence)
        {
            SimulationSequence = simulationSequence;
            FirstFaceValue = 0;
            QuantityOfFaces = 0;
        }

        public int FirstFaceValue { get; }
        public int QuantityOfFaces { get; }

        public IEnumerable<int>? SimulationSequence { get; }
    }
}
