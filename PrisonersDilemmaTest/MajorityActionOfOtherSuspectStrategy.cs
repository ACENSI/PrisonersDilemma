using PrisonersDilemma;

namespace PrisonersDilemmaTest
{
    internal class MajorityActionOfOtherSuspectStrategy : IStrategy
    {
        public SuspectAction GetAction(IEnumerable<SuspectAction> actionsOfOtherSuspect)
        {
            var betraysCount = actionsOfOtherSuspect.Count(x=>x==SuspectAction.Betrays);
            var staysSilentCount = actionsOfOtherSuspect.Count() - betraysCount;

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