using PrisonersDilemma;

namespace PrisonersDilemmaTest
{
    public class RulerTest
    {
        private IRuler _ruler;

        public RulerTest()
        {
            _ruler = new Ruler();
        }

        [Fact]
        public void BothSuspectStaysSilent()
        {
            (SuspectAction Suspect1, SuspectAction Suspect2) interrogatoryResult = (SuspectAction.StaysSilent, SuspectAction.StaysSilent);
            var sentence = _ruler.CalculateSentence(interrogatoryResult);

            Assert.Equal(-1, sentence.Suspect1);
            Assert.Equal(-1, sentence.Suspect2);
        }
        [Fact]
        public void Suspect1BetraysButSuspect2StaysSilent()
        {
            (SuspectAction Suspect1, SuspectAction Suspect2) interrogatoryResult = (SuspectAction.Betrays, SuspectAction.StaysSilent);
            var sentence = _ruler.CalculateSentence(interrogatoryResult);

            Assert.Equal(0, sentence.Suspect1);
            Assert.Equal(-10, sentence.Suspect2);
        }

        [Fact]
        public void Suspect2BetraysButSuspect1SayNothing()
        {
            (SuspectAction Suspect1, SuspectAction Suspect2) interrogatoryResult = (SuspectAction.StaysSilent, SuspectAction.Betrays);
            var sentence = _ruler.CalculateSentence(interrogatoryResult);

            Assert.Equal(-10, sentence.Suspect1);
            Assert.Equal(0, sentence.Suspect2);
        }

        [Fact]
        public void BothSuspectBetrays()
        {
            (SuspectAction Suspect1, SuspectAction Suspect2) interrogatoryResult = (SuspectAction.Betrays, SuspectAction.Betrays);
            var sentence = _ruler.CalculateSentence(interrogatoryResult);

            Assert.Equal(-5, sentence.Suspect1);
            Assert.Equal(-5, sentence.Suspect2);
        }
    }
}