using Moq;
using PrisonersDilemma;

namespace PrisonersDilemmaTest
{
    public class RandomStrategyTest
    {
        private Mock<IRandomProxy> _randomProxy;
        private IStrategy _randomStrategy;

        public RandomStrategyTest()
        {
            _randomProxy = new Mock<IRandomProxy>();
            _randomStrategy = new RandomStrategy(_randomProxy.Object);
        }

        [Theory]
        [InlineData(0, SuspectAction.StaysSilent)]
        [InlineData(1, SuspectAction.Betrays)]
        internal void GenerateRandomAction(int randomResult, SuspectAction actionExpected)
        {
            _randomProxy.Setup(x => x.Next(0, 1)).Returns(randomResult);

            var result = _randomStrategy.GetAction(new List<SuspectAction>());

            Assert.Equal(actionExpected, result);
        }

    }
}