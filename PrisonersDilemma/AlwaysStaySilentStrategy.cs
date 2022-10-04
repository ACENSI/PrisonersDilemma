namespace PrisonersDilemma
{
    internal class AlwaysStaySilentStrategy : IStrategy
    {
        public ActionEnum GetAction(IEnumerable<ActionEnum> actionsOfOtherSuspect)
        {
            return ActionEnum.StaysSilent;
        }
    }
}