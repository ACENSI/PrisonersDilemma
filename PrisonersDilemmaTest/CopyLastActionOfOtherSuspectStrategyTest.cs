using PrisonersDilemma;

namespace PrisonersDilemmaTest
{
    public class CopyLastActionOfOtherSuspectStrategyTest
    {
        private IStrategy _Strategy;

        public CopyLastActionOfOtherSuspectStrategyTest()
        {
            _Strategy = new CopyLastActionOfOtherSuspectStrategy();
        }

        [Theory]
        [InlineData(SuspectAction.Betrays)]
        [InlineData(SuspectAction.StaysSilent)]
        internal void GenerateActionWithLastActionOfOtherSuspectIs(SuspectAction expectedResult)
        {
            var actionsOfOtherSuspect = new List<SuspectAction> { SuspectAction.StaysSilent, expectedResult };
            var result = _Strategy.GetAction(actionsOfOtherSuspect);

            Assert.Equal(expectedResult, result);
        }
    }
}