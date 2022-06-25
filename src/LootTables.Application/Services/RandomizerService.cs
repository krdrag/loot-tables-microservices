namespace LootTables.Application.Services
{
    public class RandomizerService : IRandomizerService
    {
        public double GetDoubleValue(double max)
        {
            var rnd = new Random();

            return rnd.NextDouble() * max;
        }

        public double GetDoubleValue(double min, double max)
        {
            var rnd = new Random();

            return min + rnd.NextDouble() * (max - min);
        }

        public int GetIntValue(int max)
        {
            var rnd = new Random();

            return rnd.Next(max);
        }

        public int GetIntValue(int min, int max)
        {
            var rnd = new Random();

            return rnd.Next(min, max);
        }

        public IEnumerable<int> RollDice(int dicecount, int sidesperdice)
        {
            var rnd = new Random();

            List<int> rollResults = new List<int>();
            for (int i = 0; i < dicecount; i++)
                rollResults.Add(GetIntValue(1, sidesperdice + 1));

            rollResults.Insert(0, rollResults.Sum());
            return rollResults;
        }

        public bool IsPercentHit(double percent)
        {
            var rnd = new Random();

            return (rnd.NextDouble() < percent);
        }
    }
}
