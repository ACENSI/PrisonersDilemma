namespace PrisonersDilemma
{
    internal class AlwaysStaySilentStrategy : IStrategy
    {
        public SuspectAction GetAction(IEnumerable<SuspectAction> actionsOfOtherSuspect)
        {
            return SuspectAction.StaysSilent;
        }
    }
}