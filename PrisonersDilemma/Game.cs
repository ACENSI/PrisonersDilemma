namespace PrisonersDilemma
{
    internal class Game : IGame
    {
        private readonly IConfrontationManager _confrontationManager;
        private readonly IRuler _ruler;
        private readonly IDisplayer _displayer;

        public Game(IConfrontationManager confrontationManager, IRuler ruler, IDisplayer displayer)
        {
            _confrontationManager = confrontationManager;
            _ruler = ruler;
            _displayer = displayer;
        }

        public void Play()
        {
            var suspectOneHistory = new List<SuspectAction>();
            var suspectTwoHistory = new List<SuspectAction>();
            var scoreHistory = new List<(int Suspect1, int Suspect2)>();
            for (int round = 1; round <= 6; round++)
            {
                var suspectOneAction = _confrontationManager.GetResultForSuspectAndRound(Suspect.One, round, suspectTwoHistory);
                var suspectTwoAction = _confrontationManager.GetResultForSuspectAndRound(Suspect.Two, round, suspectOneHistory);

                var score = _ruler.CalculateSentence((suspectOneAction, suspectTwoAction));

                scoreHistory.Add(score);
                suspectOneHistory.Add(suspectOneAction);
                suspectTwoHistory.Add(suspectTwoAction);
            }
            var winner = _ruler.GetWinner(scoreHistory);
            _displayer.DisplaySuspectsActions(suspectOneHistory,suspectTwoHistory);
            _displayer.DisplaySuspectsScores(scoreHistory);
            _displayer.DisplayWinner(winner);
        }
    }
}