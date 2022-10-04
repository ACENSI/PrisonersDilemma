namespace PrisonersDilemma
{
    internal class MajorityActionOfOtherSuspectStrategy : IStrategy
    {
        public SuspectAction GetAction(IEnumerable<SuspectAction> actionsOfOtherSuspect)
        {
            int betraysCount = actionsOfOtherSuspect.Count(x => x == SuspectAction.Betrays);
            int staysSilentCount = actionsOfOtherSuspect.Count() - betraysCount;

            if (betraysCount > staysSilentCount)
            {
                return SuspectAction.Betrays;
            }
            if (betraysCount < staysSilentCount)
            {
                return SuspectAction.StaysSilent;
            }
            return SuspectAction.StaysSilent;
        }
    }
}