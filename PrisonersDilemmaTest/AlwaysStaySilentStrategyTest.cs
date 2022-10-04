using PrisonersDilemma;

namespace PrisonersDilemmaTest
{
    public class AlwaysStaySilentStrategyTest
    {
        private readonly IStrategy _strategy;

        public AlwaysStaySilentStrategyTest()
        {
            _strategy = new AlwaysStaySilentStrategy();
        }

        [Fact]
        public void GenerateAction()
        {

            SuspectAction result = _strategy.GetAction(new List<SuspectAction>());

            Assert.Equal(SuspectAction.StaysSilent, result);
        }
    }
}