namespace PrisonersDilemma
{
    internal interface IStrategy
    {
        SuspectAction GetAction(IEnumerable<SuspectAction> actionsOfOtherSuspect);
    }
}