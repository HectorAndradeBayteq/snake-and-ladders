namespace Data
{
    public class GameConfig
    {
        public GameConfig()
        {
            DiceConfig = new DiceConfig(firstFaceValue: 1, quantityOfFaces: 6);
            BoardConfig = new BoardConfig(totalSquares: 100);
        }
        
        public DiceConfig DiceConfig { get; set; }

        public BoardConfig BoardConfig { get; set; }

    }
}
