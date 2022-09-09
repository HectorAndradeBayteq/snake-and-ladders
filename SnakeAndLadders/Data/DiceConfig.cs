using Domain.Ports.Output.Interfaces;

namespace Data
{
    public class DiceConfig : IDiceConfig
    {
        /// <summary>
        /// Dice config
        /// </summary>
        /// <param name="firstFaceValue">Initial value of the dice</param>
        /// <param name="quantityOfFaces">Quantity of faces in the dice</param>
        public DiceConfig(int firstFaceValue, int quantityOfFaces)
        {
            FirstFaceValue = firstFaceValue;
            QuantityOfFaces = quantityOfFaces;
        }

        public int FirstFaceValue { get; }
        public int QuantityOfFaces { get; }

        public IEnumerable<int>? SimulationSequence { get; } = null;
    }
}
