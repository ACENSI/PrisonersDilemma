using PrisonersDilemma;

namespace PrisonersDilemmaTest
{
    public class AlwaysStaySilentStrategyTest
    {
        private IStrategy _Strategy;

        public AlwaysStaySilentStrategyTest()
        {
            _Strategy = new AlwaysStaySilentStrategy();
        }

        [Fact]
        public void GenerateAction()
        {
            
            var result = _Strategy.GetAction(new List<ActionEnum>());

            Assert.Equal(ActionEnum.StaysSilent, result);
        }
    }
}