using Moq;
using PrisonersDilemma;

namespace PrisonersDilemmaTest
{
    public class GameTest
    {
        private readonly Mock<IConfrontationManager> _confrontationManager;
        private readonly Mock<IRuler> _ruler;
        private readonly Mock<IDisplayer> _displayer;
        private readonly IGame _game;

        public GameTest()
        {
            _confrontationManager = new Mock<IConfrontationManager>();
            _ruler = new Mock<IRuler>();
            _displayer = new Mock<IDisplayer>();
            _game = new Game(_confrontationManager.Object, _ruler.Object, _displayer.Object);
        }

        [Fact]
        public void Play()
        {
            _game.Play();

            _confrontationManager.Verify(x => x.GetResultForSuspectAndRound(Suspect.One, It.IsAny<int>(), It.IsAny<IEnumerable<SuspectAction>>()), Times.Exactly(6));
            _confrontationManager.Verify(x => x.GetResultForSuspectAndRound(Suspect.Two, It.IsAny<int>(), It.IsAny<IEnumerable<SuspectAction>>()), Times.Exactly(6));
            _ruler.Verify(x => x.CalculateSentence(It.IsAny<(SuspectAction Suspect1, SuspectAction Suspect2)>()), Times.Exactly(6));
            _ruler.Verify(x => x.GetWinner(It.IsAny<IEnumerable<(int Suspect1, int Suspect2)>>()), Times.Once);
            _displayer.Verify(x => x.DisplaySuspectsActions(It.IsAny<IEnumerable<SuspectAction>>(), It.IsAny<IEnumerable<SuspectAction>>()), Times.Once);
            _displayer.Verify(x => x.DisplaySuspectsScores(It.IsAny<IEnumerable<(int Suspect1, int Suspect2)>>()), Times.Once);
            _displayer.Verify(x => x.DisplayWinner(It.IsAny<Winner>()), Times.Once);
        }
    }
}