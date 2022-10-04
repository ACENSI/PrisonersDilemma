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
        [InlineData(ActionEnum.Betrays)]
        [InlineData(ActionEnum.StaysSilent)]
        internal void GenerateActionWithLastActionOfOtherSuspectIs(ActionEnum expectedResult)
        {
            var actionsOfOtherSuspect = new List<ActionEnum> { ActionEnum.StaysSilent, expectedResult };
            var result = _Strategy.GetAction(actionsOfOtherSuspect);

            Assert.Equal(expectedResult, result);
        }
    }
}