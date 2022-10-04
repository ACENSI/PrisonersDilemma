using Moq;
using PrisonersDilemma;

namespace PrisonersDilemmaTest
{
    public class ConfrontationManagerTest
    {
        private readonly Mock<IStrategy> _randomStrategy;
        private readonly Mock<IStrategy> _majorityActionOfOtherSuspectStrategy;
        private readonly Mock<IStrategy> _copyLastActionOfOtherSuspectStrategy;
        private readonly Mock<IStrategy> _alwaysStaySilentStrategy;
        private readonly IConfrontationManager _confrontationManager;

        public ConfrontationManagerTest()
        {
            _randomStrategy = new Mock<IStrategy>();
            _randomStrategy.Setup(x => x.GetAction(It.IsAny<IEnumerable<SuspectAction>>())).Returns(SuspectAction.StaysSilent);
            _majorityActionOfOtherSuspectStrategy = new Mock<IStrategy>();
            _majorityActionOfOtherSuspectStrategy.Setup(x => x.GetAction(It.IsAny<IEnumerable<SuspectAction>>())).Returns(SuspectAction.StaysSilent);
            _copyLastActionOfOtherSuspectStrategy = new Mock<IStrategy>();
            _copyLastActionOfOtherSuspectStrategy.Setup(x => x.GetAction(It.IsAny<IEnumerable<SuspectAction>>())).Returns(SuspectAction.StaysSilent);
            _alwaysStaySilentStrategy = new Mock<IStrategy>();
            _alwaysStaySilentStrategy.Setup(x => x.GetAction(It.IsAny<IEnumerable<SuspectAction>>())).Returns(SuspectAction.StaysSilent);

            _confrontationManager = new ConfrontationManager(_randomStrategy.Object, _majorityActionOfOtherSuspectStrategy.Object, _copyLastActionOfOtherSuspectStrategy.Object, _alwaysStaySilentStrategy.Object);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void SuspectOneIsRandomForRound(int round)
        {

            SuspectAction result = _confrontationManager.GetResultForSuspectAndRound(Suspect.One, round, new List<SuspectAction>());

            Assert.Equal(SuspectAction.StaysSilent, result);

            _randomStrategy.Verify(x => x.GetAction(It.IsAny<IEnumerable<SuspectAction>>()), Times.Once);
            _majorityActionOfOtherSuspectStrategy.Verify(x => x.GetAction(It.IsAny<IEnumerable<SuspectAction>>()), Times.Never);
            _copyLastActionOfOtherSuspectStrategy.Verify(x => x.GetAction(It.IsAny<IEnumerable<SuspectAction>>()), Times.Never);
            _alwaysStaySilentStrategy.Verify(x => x.GetAction(It.IsAny<IEnumerable<SuspectAction>>()), Times.Never);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void SuspectOneIsCopyLastForRound(int round)
        {

            SuspectAction result = _confrontationManager.GetResultForSuspectAndRound(Suspect.One, round, new List<SuspectAction>());

            Assert.Equal(SuspectAction.StaysSilent, result);

            _randomStrategy.Verify(x => x.GetAction(It.IsAny<IEnumerable<SuspectAction>>()), Times.Never);
            _majorityActionOfOtherSuspectStrategy.Verify(x => x.GetAction(It.IsAny<IEnumerable<SuspectAction>>()), Times.Never);
            _copyLastActionOfOtherSuspectStrategy.Verify(x => x.GetAction(It.IsAny<IEnumerable<SuspectAction>>()), Times.Once);
            _alwaysStaySilentStrategy.Verify(x => x.GetAction(It.IsAny<IEnumerable<SuspectAction>>()), Times.Never);
        }

        [Fact]
        public void SuspectTwoIsStaySilentForRound1()
        {

            SuspectAction result = _confrontationManager.GetResultForSuspectAndRound(Suspect.Two, 1, new List<SuspectAction>());

            Assert.Equal(SuspectAction.StaysSilent, result);

            _randomStrategy.Verify(x => x.GetAction(It.IsAny<IEnumerable<SuspectAction>>()), Times.Never);
            _majorityActionOfOtherSuspectStrategy.Verify(x => x.GetAction(It.IsAny<IEnumerable<SuspectAction>>()), Times.Never);
            _copyLastActionOfOtherSuspectStrategy.Verify(x => x.GetAction(It.IsAny<IEnumerable<SuspectAction>>()), Times.Never);
            _alwaysStaySilentStrategy.Verify(x => x.GetAction(It.IsAny<IEnumerable<SuspectAction>>()), Times.Once);
        }

        [Fact]
        public void SuspectTwoIsRandomForRound2()
        {

            SuspectAction result = _confrontationManager.GetResultForSuspectAndRound(Suspect.Two, 2, new List<SuspectAction>());

            Assert.Equal(SuspectAction.StaysSilent, result);

            _randomStrategy.Verify(x => x.GetAction(It.IsAny<IEnumerable<SuspectAction>>()), Times.Once);
            _majorityActionOfOtherSuspectStrategy.Verify(x => x.GetAction(It.IsAny<IEnumerable<SuspectAction>>()), Times.Never);
            _copyLastActionOfOtherSuspectStrategy.Verify(x => x.GetAction(It.IsAny<IEnumerable<SuspectAction>>()), Times.Never);
            _alwaysStaySilentStrategy.Verify(x => x.GetAction(It.IsAny<IEnumerable<SuspectAction>>()), Times.Never);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void SuspectTwoIsMajorityForRound(int round)
        {

            SuspectAction result = _confrontationManager.GetResultForSuspectAndRound(Suspect.Two, round, new List<SuspectAction>());

            Assert.Equal(SuspectAction.StaysSilent, result);

            _randomStrategy.Verify(x => x.GetAction(It.IsAny<IEnumerable<SuspectAction>>()), Times.Never);
            _majorityActionOfOtherSuspectStrategy.Verify(x => x.GetAction(It.IsAny<IEnumerable<SuspectAction>>()), Times.Once);
            _copyLastActionOfOtherSuspectStrategy.Verify(x => x.GetAction(It.IsAny<IEnumerable<SuspectAction>>()), Times.Never);
            _alwaysStaySilentStrategy.Verify(x => x.GetAction(It.IsAny<IEnumerable<SuspectAction>>()), Times.Never);
        }
    }
}