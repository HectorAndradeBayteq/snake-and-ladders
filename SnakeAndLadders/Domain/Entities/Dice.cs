namespace Domain.Entities
{
    public class Dice
    {
        private readonly IEnumerable<int> _faces;
        private readonly Func<IEnumerable<int>, int> _randomFaceFunction;
        private int _attemps = -1;

        public Dice(int firstFaceValue = 1, int quantityOfFaces = 6)
        {
            _randomFaceFunction = delegate (IEnumerable<int> options)
            {
                var faces = options.ToList();
                return faces[new Random().Next(faces.Count)];
            };
            _faces = Enumerable.Range(firstFaceValue, quantityOfFaces).ToList();
        }

        public Dice(IEnumerable<int> simulationSequence)
        {
            _faces = simulationSequence;
            _randomFaceFunction = delegate (IEnumerable<int> options)
            {
                _attemps++;
                if (_attemps > options.Count() - 1) _attemps = 0;
                return options.ToList()[_attemps];
            };
        }

        public Dice(IEnumerable<int> faces, Func<IEnumerable<int>, int> randomFaceFunction)
        {
            _faces = faces;
            _randomFaceFunction = randomFaceFunction;
        }

        public int Roll()
        {
            return _randomFaceFunction(_faces);
        }
    }
}