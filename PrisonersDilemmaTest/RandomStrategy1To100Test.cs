using Moq;
using PrisonersDilemma;

namespace PrisonersDilemmaTest
{
    public class RandomStrategy1To100Test
    {
        private readonly Mock<IRandomProxy> _randomProxy;
        private readonly IStrategy _randomStrategy;

        public RandomStrategy1To100Test()
        {
            _randomProxy = new Mock<IRandomProxy>();
            _randomStrategy = new RandomStrategy1To100(_randomProxy.Object);
        }

        [Theory]
        [InlineData(1, SuspectAction.StaysSilent)]
        [InlineData(50, SuspectAction.StaysSilent)]
        [InlineData(51, SuspectAction.Betrays)]
        [InlineData(100, SuspectAction.Betrays)]
        internal void GenerateRandomAction(int randomResult, SuspectAction actionExpected)
        {
            _randomProxy.Setup(x => x.Next(1, 100)).Returns(randomResult);

            SuspectAction result = _randomStrategy.GetAction(new List<SuspectAction>());

            Assert.Equal(actionExpected, result);
        }

    }
}