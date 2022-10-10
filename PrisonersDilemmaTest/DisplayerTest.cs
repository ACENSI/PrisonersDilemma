using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Extensions;
using Moq;
using PrisonersDilemma;
using System.Reflection;
using System.Text;

namespace PrisonersDilemmaTest
{
    public class DisplayerTest
    {
        private readonly IDisplayer _displayer;
        private readonly Mock<IWriterProxy> _writerProxy;
        private readonly StringBuilder _message;

        public DisplayerTest()
        {
            //fixed:linux/windows 
            _message = new StringBuilder();
            _writerProxy = new Mock<IWriterProxy>();
            _writerProxy.Setup(x => x.WriteLine(It.IsAny<string>())).Callback<string>((x) => _message.AppendLine(x));
            _displayer = new Displayer(_writerProxy.Object);
        }

        [Fact]
        public void DisplaySuspectsActions()
        {
            //fixed:linux/windows
            string messageExpected = new StringBuilder().AppendLine(@"Actions :").
                AppendLine(@"Suspect1 : [StaysSilent, Betrays, StaysSilent, StaysSilent, Betrays, StaysSilent]").
                AppendLine("Suspect2 : [StaysSilent, Betrays, Betrays, StaysSilent, StaysSilent, StaysSilent]").ToString();

            var suspectOneHistory = new List<SuspectAction>
            {
                SuspectAction.StaysSilent,
                SuspectAction.Betrays,
                SuspectAction.StaysSilent,
                SuspectAction.StaysSilent,
                SuspectAction.Betrays,
                SuspectAction.StaysSilent
            };
            var suspectTwoHistory = new List<SuspectAction>
            {
                SuspectAction.StaysSilent,
                SuspectAction.Betrays,
                SuspectAction.Betrays,
                SuspectAction.StaysSilent,
                SuspectAction.StaysSilent,
                SuspectAction.StaysSilent
            };
            _displayer.DisplaySuspectsActions(suspectOneHistory, suspectTwoHistory);
            Assert.Equal(messageExpected, _message.ToString());
        }

        [Fact]
        public void DisplaySuspectsScores()
        {
            //fixed:linux/windows
            string messageExpected = new StringBuilder().AppendLine(@"Scores :").
                AppendLine(@"Suspect1 : [-1, -5, -10, 0, -5, -1]").
                AppendLine(@"Suspect2 : [-1, -5, 0, -10, -5, -1]").ToString();

            var scoreHistory = new List<(int Suspect1, int Suspect2)>
            {
                (-1,-1),
                (-5,-5),
                (-10,0),
                (0,-10),
                (-5,-5),
                (-1,-1)
            };
            _displayer.DisplaySuspectsScores(scoreHistory);
            Assert.Equal(messageExpected, _message.ToString());
        }

        [Fact]
        public void DisplayWinnerNull()
        {
            //fixed:linux/windows
            string messageExpected = new StringBuilder().AppendLine(@"Winner is Null").ToString();

            _displayer.DisplayWinner(Winner.Null);
            Assert.Equal(messageExpected, _message.ToString());
        }

        [Fact]
        public void DisplayWinnerOne()
        {
            //fixed:linux/windows
            string messageExpected = new StringBuilder().AppendLine(@"Winner is Suspect One").ToString();

            _displayer.DisplayWinner(Winner.One);
            Assert.Equal(messageExpected, _message.ToString());
        }

        [Fact]
        public void DisplayWinnerTwo()
        {
            //fixed:linux/windows
            string messageExpected = new StringBuilder().AppendLine(@"Winner is Suspect Two").ToString();

            _displayer.DisplayWinner(Winner.Two);
            Assert.Equal(messageExpected, _message.ToString());
        }
    }
}
