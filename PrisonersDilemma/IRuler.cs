namespace PrisonersDilemma
{
    internal interface IRuler
    {
        (int Suspect1, int Suspect2) CalculateSentence((SuspectAction Suspect1, SuspectAction Suspect2) interrogatoryResult);
        Winner GetWinner(IEnumerable<(int Suspect1, int Suspect2)> scoreHistory);
    }
}