using PrisonersDilemma;

namespace PrisonersDilemmaTest
{
    internal class MajorityActionOfOtherSuspectStrategy : IStrategy
    {
        public ActionEnum GetAction(IEnumerable<ActionEnum> actionsOfOtherSuspect)
        {
            var betraysCount = actionsOfOtherSuspect.Count(x=>x==ActionEnum.Betrays);
            var staysSilentCount = actionsOfOtherSuspect.Count() - betraysCount;

            if (betraysCount > staysSilentCount)
            {
                return ActionEnum.Betrays;
            }
            if (betraysCount < staysSilentCount)
            {
                return ActionEnum.StaysSilent;
            }
            return ActionEnum.StaysSilent;
        }
    }
}