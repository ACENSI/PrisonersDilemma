namespace PrisonersDilemma
{
    internal interface IConfrontationManager
    {
        SuspectAction GetResultForSuspectAndRound(Suspect suspect, int round, IEnumerable<SuspectAction> actionsOfOtherSuspect);
    }
}