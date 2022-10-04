using Moq;
using PrisonersDilemma;

namespace PrisonersDilemmaTest
{
    public class RandomStrategy0To1Test
    {
        private readonly Mock<IRandomProxy> _randomProxy;
        private readonly IStrategy _randomStrategy;

        public RandomStrategy0To1Test()
        {
            _randomProxy = new Mock<IRandomProxy>();
            _randomStrategy = new RandomStrategy0To1(_randomProxy.Object);
        }

        [Theory]
        [InlineData(0, SuspectAction.StaysSilent)]
        [InlineData(1, SuspectAction.Betrays)]
        internal void GenerateRandomAction(int randomResult, SuspectAction actionExpected)
        {
            _randomProxy.Setup(x => x.Next(0, 1)).Returns(randomResult);

            SuspectAction result = _randomStrategy.GetAction(new List<SuspectAction>());

            Assert.Equal(actionExpected, result);
        }

    }
}