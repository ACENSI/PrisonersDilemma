namespace PrisonersDilemma
{
    internal class CopyLastActionOfOtherSuspectStrategy : IStrategy
    {
        public SuspectAction GetAction(IEnumerable<SuspectAction> actionsOfOtherSuspect)
        {
            return actionsOfOtherSuspect.LastOrDefault();
        }
    }
}