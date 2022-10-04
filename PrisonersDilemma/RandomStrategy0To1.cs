namespace PrisonersDilemma
{
    internal class RandomStrategy0To1 : IStrategy
    {
        private readonly IRandomProxy _random;

        public RandomStrategy0To1(IRandomProxy randomProxy)
        {
            _random = randomProxy;
        }

        public SuspectAction GetAction(IEnumerable<SuspectAction> actionsOfOtherSuspect)
        {
            if (_random.Next(0, 1) == 0)
            {
                return SuspectAction.StaysSilent;
            }
            return SuspectAction.Betrays;
        }
    }
}