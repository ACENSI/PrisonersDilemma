using PrisonersDilemma;

namespace PrisonersDilemmaTest
{
    public class MajorityActionOfOtherSuspectStrategyTest
    {
        private readonly IStrategy _strategy;

        public MajorityActionOfOtherSuspectStrategyTest()
        {
            _strategy = new MajorityActionOfOtherSuspectStrategy();
        }

        [Fact]
        public void GenerateWithMajorityOfStaysSilent()
        {
            List<SuspectAction> actionsOfOtherSuspect = new List<SuspectAction> { SuspectAction.StaysSilent, SuspectAction.StaysSilent, SuspectAction.Betrays };
            SuspectAction result = _strategy.GetAction(actionsOfOtherSuspect);

            Assert.Equal(SuspectAction.StaysSilent, result);
        }

        [Fact]
        public void GenerateWithMajorityOfBetrays()
        {
            List<SuspectAction> actionsOfOtherSuspect = new List<SuspectAction> { SuspectAction.Betrays, SuspectAction.Betrays, SuspectAction.StaysSilent };
            SuspectAction result = _strategy.GetAction(actionsOfOtherSuspect);

            Assert.Equal(SuspectAction.Betrays, result);
        }

        [Fact]
        public void GenerateWithEquality()
        {
            List<SuspectAction> actionsOfOtherSuspect = new List<SuspectAction> { SuspectAction.Betrays, SuspectAction.StaysSilent, SuspectAction.StaysSilent, SuspectAction.Betrays };
            SuspectAction result = _strategy.GetAction(actionsOfOtherSuspect);

            Assert.Equal(SuspectAction.StaysSilent, result);
        }
    }
}