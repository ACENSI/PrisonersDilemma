using PrisonersDilemma;

namespace PrisonersDilemma
{
    internal class RandomStrategy : IStrategy
    {
        private IRandomProxy _random;

        public RandomStrategy(IRandomProxy randomProxy)
        {
            _random = randomProxy;
        }

        public ActionEnum GetAction(IEnumerable<ActionEnum> actionsOfOtherSuspect)
        {
            if (_random.Next(0,1) == 0)
            {
                return ActionEnum.StaysSilent;
            }
            return ActionEnum.Betrays;
        }
    }
}