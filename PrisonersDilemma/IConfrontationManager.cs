namespace PrisonersDilemma
{
    internal interface IConfrontationManager
    {
        SuspectAction GetResultForSuspectAndRound(Suspect one, int round, IEnumerable<SuspectAction> actionsOfOtherSuspect);
    }
}