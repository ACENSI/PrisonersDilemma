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
        [InlineData(0, ActionEnum.StaysSilent)]
        [InlineData(1, ActionEnum.Betrays)]
        internal void GenerateRandomAction(int randomResult, ActionEnum actionExpected)
        {
            _randomProxy.Setup(x => x.Next(0, 1)).Returns(randomResult);

            var result = _randomStrategy.GetAction(new List<ActionEnum>());

            Assert.Equal(actionExpected, result);
        }

    }
}