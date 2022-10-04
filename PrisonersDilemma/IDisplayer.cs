namespace PrisonersDilemma
{
    internal interface IDisplayer
    {
        void DisplaySuspectsActions(IEnumerable<SuspectAction> suspectOneHistory, IEnumerable<SuspectAction> suspectTwoHistory);
        void DisplaySuspectsScores(IEnumerable<(int Suspect1, int Suspect2)> scoreHistory);
        void DisplayWinner(Winner winner);
    }
}