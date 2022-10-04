namespace PrisonersDilemma
{
    internal class ConfrontationManager : IConfrontationManager
    {
        private readonly Dictionary<(Suspect suspect, int round), IStrategy> strategyManagment;

        public ConfrontationManager(IStrategy randomStrategy, IStrategy majorityActionOfOtherSuspectStrategy, IStrategy copyLastActionOfOtherSuspectStrategy, IStrategy alwaysStaySilentStrategy)
        {
            strategyManagment = new Dictionary<(Suspect suspect, int round), IStrategy>
            {
                {(Suspect.One, 1), randomStrategy},
                {(Suspect.One, 2), randomStrategy},
                {(Suspect.One, 3), copyLastActionOfOtherSuspectStrategy},
                {(Suspect.One, 4), copyLastActionOfOtherSuspectStrategy},
                {(Suspect.One, 5), copyLastActionOfOtherSuspectStrategy},
                {(Suspect.One, 6), copyLastActionOfOtherSuspectStrategy},
                {(Suspect.Two, 1), alwaysStaySilentStrategy},
                {(Suspect.Two, 2), randomStrategy},
                {(Suspect.Two, 3), majorityActionOfOtherSuspectStrategy},
                {(Suspect.Two, 4), majorityActionOfOtherSuspectStrategy},
                {(Suspect.Two, 5), majorityActionOfOtherSuspectStrategy},
                {(Suspect.Two, 6), majorityActionOfOtherSuspectStrategy},
            };
        }

        public SuspectAction GetResultForSuspectAndRound(Suspect suspect, int round, IEnumerable<SuspectAction> actionsOfOtherSuspect)
        {
            if (strategyManagment.ContainsKey((suspect, round)))
            {
                return strategyManagment[(suspect, round)].GetAction(actionsOfOtherSuspect);
            }
            throw new ArgumentException($"This Confrontation is not managed yet. [{(suspect, round)}]", $"{nameof(suspect)}, {nameof(round)}");
        }
    }
}