using PrisonersDilemma;

namespace PrisonersDilemma
{
    internal class RandomStrategy : IStrategy
    {
        private readonly IRandomProxy _random;

        public RandomStrategy(IRandomProxy randomProxy)
        {
            _random = randomProxy;
        }

        public SuspectAction GetAction(IEnumerable<SuspectAction> actionsOfOtherSuspect)
        {
            if (_random.Next(0,1) == 0)
            {
                return SuspectAction.StaysSilent;
            }
            return SuspectAction.Betrays;
        }
    }
}