namespace PrisonersDilemma
{
    public static class Program
    {
        public static void Main()
        {
            //var randomStrategy = new RandomStrategy0To1(new RandomProxy());
            var randomStrategy = new RandomStrategy1To100(new RandomProxy());
            var majorityActionOfOtherSuspectStrategy = new MajorityActionOfOtherSuspectStrategy();
            var copyLastActionOfOtherSuspectStrategy = new CopyLastActionOfOtherSuspectStrategy();
            var alwaysStaySilentStrategy = new AlwaysStaySilentStrategy();
            var confrontationManager = new ConfrontationManager(randomStrategy, majorityActionOfOtherSuspectStrategy, copyLastActionOfOtherSuspectStrategy, alwaysStaySilentStrategy);
            var ruler = new Ruler();
            var displayer = new Displayer(new WriterProxy());
            var game = new Game(confrontationManager, ruler, displayer);
            for (int i = 0; i < 10; i++)
            {
                game.Play(); 
            }
        }
    }
}