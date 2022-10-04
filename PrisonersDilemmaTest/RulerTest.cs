using PrisonersDilemma;

namespace PrisonersDilemmaTest
{
    public class RulerTest
    {
        private readonly IRuler _ruler;

        public RulerTest()
        {
            _ruler = new Ruler();
        }

        [Fact]
        public void BothSuspectStaysSilent()
        {
            (SuspectAction Suspect1, SuspectAction Suspect2) interrogatoryResult = (SuspectAction.StaysSilent, SuspectAction.StaysSilent);
            (int Suspect1, int Suspect2) sentence = _ruler.CalculateSentence(interrogatoryResult);

            Assert.Equal(-1, sentence.Suspect1);
            Assert.Equal(-1, sentence.Suspect2);
        }
        [Fact]
        public void Suspect1BetraysButSuspect2StaysSilent()
        {
            (SuspectAction Suspect1, SuspectAction Suspect2) interrogatoryResult = (SuspectAction.Betrays, SuspectAction.StaysSilent);
            (int Suspect1, int Suspect2) sentence = _ruler.CalculateSentence(interrogatoryResult);

            Assert.Equal(0, sentence.Suspect1);
            Assert.Equal(-10, sentence.Suspect2);
        }

        [Fact]
        public void Suspect2BetraysButSuspect1SayNothing()
        {
            (SuspectAction Suspect1, SuspectAction Suspect2) interrogatoryResult = (SuspectAction.StaysSilent, SuspectAction.Betrays);
            (int Suspect1, int Suspect2) sentence = _ruler.CalculateSentence(interrogatoryResult);

            Assert.Equal(-10, sentence.Suspect1);
            Assert.Equal(0, sentence.Suspect2);
        }

        [Fact]
        public void BothSuspectBetrays()
        {
            (SuspectAction Suspect1, SuspectAction Suspect2) interrogatoryResult = (SuspectAction.Betrays, SuspectAction.Betrays);
            (int Suspect1, int Suspect2) sentence = _ruler.CalculateSentence(interrogatoryResult);

            Assert.Equal(-5, sentence.Suspect1);
            Assert.Equal(-5, sentence.Suspect2);
        }


        [Fact]
        public void WinnerOne()
        {
            List<(int Suspect1, int suspect2)> scoreHistory = new List<(int Suspect1, int suspect2)>()
            {
                (0,-10),
                (-10,0),
                (-5,-5),
                (-1,-1),
                (-1,-1),
                (0,-10),
            };
            Winner winner = _ruler.GetWinner(scoreHistory);

            Assert.Equal(Winner.One, winner);
        }
        [Fact]
        public void WinnerTwo()
        {
            List<(int Suspect1, int suspect2)> scoreHistory = new List<(int Suspect1, int suspect2)>()
            {
                (0,-10),
                (-10,0),
                (-5,-5),
                (-1,-1),
                (-1,-1),
                (-10,0),
            };
            Winner winner = _ruler.GetWinner(scoreHistory);

            Assert.Equal(Winner.Two, winner);
        }
        [Fact]
        public void WinnerNull()
        {
            List<(int Suspect1, int suspect2)> scoreHistory = new List<(int Suspect1, int suspect2)>()
            {
                (0,-10),
                (-10,0),
                (-5,-5),
                (-1,-1),
                (-1,-1),
                (-1,-1),
            };
            Winner winner = _ruler.GetWinner(scoreHistory);

            Assert.Equal(Winner.Null, winner);
        }
    }
}