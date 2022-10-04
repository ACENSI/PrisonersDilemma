namespace PrisonersDilemma
{
    internal class RandomProxy : IRandomProxy
    {
        public int Next(int minValue, int maxValue)
        {
            var random = new Random();
            return random.Next(minValue, maxValue);
        }
    }
}