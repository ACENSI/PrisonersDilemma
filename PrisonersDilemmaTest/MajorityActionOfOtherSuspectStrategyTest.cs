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
            var actionsOfOtherSuspect = new List<ActionEnum> { ActionEnum.StaysSilent, ActionEnum.StaysSilent, ActionEnum.Betrays };
            var result = _Strategy.GetAction(actionsOfOtherSuspect);

            Assert.Equal(ActionEnum.StaysSilent, result);
        }

        [Fact]
        public void GenerateWithMajorityOfBetrays()
        {
            var actionsOfOtherSuspect = new List<ActionEnum> { ActionEnum.Betrays, ActionEnum.Betrays, ActionEnum.StaysSilent };
            var result = _Strategy.GetAction(actionsOfOtherSuspect);

            Assert.Equal(ActionEnum.Betrays, result);
        }

        [Fact]
        public void GenerateWithEquality()
        {
            var actionsOfOtherSuspect = new List<ActionEnum> { ActionEnum.Betrays, ActionEnum.StaysSilent, ActionEnum.StaysSilent, ActionEnum.Betrays };
            var result = _Strategy.GetAction(actionsOfOtherSuspect);

            Assert.Equal(ActionEnum.StaysSilent, result);
        }
    }
}