namespace PrisonersDilemma
{
    internal interface IStrategy
    {
        ActionEnum GetAction(IEnumerable<ActionEnum> actionsOfOtherSuspect);
    }
}