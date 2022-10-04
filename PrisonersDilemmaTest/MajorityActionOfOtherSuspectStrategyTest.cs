using PrisonersDilemma;

namespace PrisonersDilemmaTest
{
    public class MajorityActionOfOtherSuspectStrategyTest
    {
        private IStrategy _Strategy;

        public MajorityActionOfOtherSuspectStrategyTest()
        {
            _Strategy = new MajorityActionOfOtherSuspectStrategy();
        }

        [Fact]
        public void GenerateWithMajorityOfStaysSilent()
        {
            var actionsOfOtherSuspect = new List<SuspectAction> { SuspectAction.StaysSilent, SuspectAction.StaysSilent, SuspectAction.Betrays };
            var result = _Strategy.GetAction(actionsOfOtherSuspect);

            Assert.Equal(SuspectAction.StaysSilent, result);
        }

        [Fact]
        public void GenerateWithMajorityOfBetrays()
        {
            var actionsOfOtherSuspect = new List<SuspectAction> { SuspectAction.Betrays, SuspectAction.Betrays, SuspectAction.StaysSilent };
            var result = _Strategy.GetAction(actionsOfOtherSuspect);

            Assert.Equal(SuspectAction.Betrays, result);
        }

        [Fact]
        public void GenerateWithEquality()
        {
            var actionsOfOtherSuspect = new List<SuspectAction> { SuspectAction.Betrays, SuspectAction.StaysSilent, SuspectAction.StaysSilent, SuspectAction.Betrays };
            var result = _Strategy.GetAction(actionsOfOtherSuspect);

            Assert.Equal(SuspectAction.StaysSilent, result);
        }
    }
}