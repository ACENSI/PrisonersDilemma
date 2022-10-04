namespace PrisonersDilemma
{
    internal class CopyLastActionOfOtherSuspectStrategy : IStrategy
    {
        public ActionEnum GetAction(IEnumerable<ActionEnum> actionsOfOtherSuspect)
        {
            return actionsOfOtherSuspect.LastOrDefault();
        }
    }
}