namespace PrisonersDilemma
{
    internal class RandomStrategy1To100 : IStrategy
    {
        private readonly IRandomProxy _random;

        public RandomStrategy1To100(IRandomProxy randomProxy)
        {
            _random = randomProxy;
        }

        public SuspectAction GetAction(IEnumerable<SuspectAction> actionsOfOtherSuspect)
        {
            if (_random.Next(1, 100) <= 50)
            {
                return SuspectAction.StaysSilent;
            }
            return SuspectAction.Betrays;
        }
    }
}