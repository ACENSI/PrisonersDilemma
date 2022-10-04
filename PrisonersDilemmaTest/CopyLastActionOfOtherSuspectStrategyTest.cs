using PrisonersDilemma;

namespace PrisonersDilemmaTest
{
    public class CopyLastActionOfOtherSuspectStrategyTest
    {
        private readonly IStrategy _strategy;

        public CopyLastActionOfOtherSuspectStrategyTest()
        {
            _strategy = new CopyLastActionOfOtherSuspectStrategy();
        }

        [Theory]
        [InlineData(SuspectAction.Betrays)]
        [InlineData(SuspectAction.StaysSilent)]
        internal void GenerateActionWithLastActionOfOtherSuspectIs(SuspectAction expectedResult)
        {
            List<SuspectAction> actionsOfOtherSuspect = new List<SuspectAction> { SuspectAction.StaysSilent, expectedResult };
            SuspectAction result = _strategy.GetAction(actionsOfOtherSuspect);

            Assert.Equal(expectedResult, result);
        }
    }
}