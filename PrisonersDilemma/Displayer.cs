namespace PrisonersDilemma
{
    internal class Displayer : IDisplayer
    {
        private IWriterProxy _writer;

        public Displayer(IWriterProxy writer)
        {
            _writer = writer;
        }

        public void DisplaySuspectsActions(IEnumerable<SuspectAction> suspectOneHistory, IEnumerable<SuspectAction> suspectTwoHistory)
        {
            var suspectOneHistoryFormated = string.Join(", ", suspectOneHistory);
            var suspectTwoHistoryFormated = string.Join(", ", suspectTwoHistory);
            _writer.WriteLine($"Actions :");
            _writer.WriteLine($"Suspect1 : [{suspectOneHistoryFormated}]");
            _writer.WriteLine($"Suspect2 : [{suspectTwoHistoryFormated}]");
        }

        public void DisplaySuspectsScores(IEnumerable<(int Suspect1, int Suspect2)> scoreHistory)
        {
            var suspectOneScoresFormated = string.Join(", ", scoreHistory.Select(x => x.Suspect1));
            var suspectTwoScoresFormated = string.Join(", ", scoreHistory.Select(x => x.Suspect2));
            _writer.WriteLine($"Scores :");
            _writer.WriteLine($"Suspect1 : [{suspectOneScoresFormated}]");
            _writer.WriteLine($"Suspect2 : [{suspectTwoScoresFormated}]");
        }

        public void DisplayWinner(Winner winner)
        {
            switch (winner)
            {
                case Winner.One:
                    _writer.WriteLine($"Winner is Suspect One");
                    break;
                case Winner.Two:
                    _writer.WriteLine($"Winner is Suspect Two");
                    break;
                case Winner.Null:
                    _writer.WriteLine($"Winner is Null");
                    break;
                default:
                    throw new ArgumentException($"This Display Winner is not managed yet. [{winner}]", nameof(winner));
            }
        }
    }
}