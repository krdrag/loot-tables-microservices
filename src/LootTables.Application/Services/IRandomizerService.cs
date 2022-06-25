namespace LootTables.Application.Services
{
    public interface IRandomizerService
    {
        /// <summary>
        /// Get random double 
        /// </summary>
        /// <param name="max">Max value (excl)</param>
        /// <returns>Random value between 0 (incl) to max (excl)</returns>
        double GetDoubleValue(double max);

        /// <summary>
        /// Get random double 
        /// </summary>
        /// <param name="min">Min value (incl)</param>
        /// <param name="max">Max value (excl)</param>
        /// <returns>Random value between min (incl) to max (excl)</returns>
        double GetDoubleValue(double min, double max);

        /// <summary>
        /// Get random int 
        /// </summary>
        /// <param name="max">Max value (excl)</param>
        /// <returns>Random value between 0 (incl) to max (excl)</returns>
        int GetIntValue(int max);

        /// <summary>
        /// Get random int 
        /// </summary>
        /// <param name="min">Min value (incl)</param>
        /// <param name="max">Max value (excl)</param>
        /// <returns>Random value between min (incl) to max (excl)</returns>
        int GetIntValue(int min, int max);

        /// <summary>
        /// Roll X sided dice Y times.
        /// </summary>
        /// <param name="dicecount">How many times to roll the dice</param>
        /// <param name="sidesperdice">How many sides the dice has</param>
        /// <returns>List of roll results. Value on 0th position is sum of all rolls.</returns>
        IEnumerable<int> RollDice(int dicecount, int sidesperdice);

        /// <summary>
        /// Check if with given percent chance action would succeed or fail.
        /// Example: Attack has 80% chance to hit. Check if next attack misses.
        /// </summary>
        /// <param name="percent">Percent chance of action to succeed. Must be between 0.0 and 1.0</param>
        /// <returns>Information if action succeeded.</returns>
        bool IsPercentHit(double percent);
    }
}
