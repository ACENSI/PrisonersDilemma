﻿namespace PrisonersDilemma
{
    internal sealed class Ruler : IRuler
    {
        private readonly Dictionary<(SuspectAction Suspect1, SuspectAction Suspect2), (int Suspect1, int Suspect2)> Sentence = new()
        {
            {(SuspectAction.StaysSilent, SuspectAction.StaysSilent), (-1, -1) },
            {(SuspectAction.Betrays, SuspectAction.StaysSilent), (0, -10) },
            {(SuspectAction.StaysSilent, SuspectAction.Betrays), (-10, 0) },
            {(SuspectAction.Betrays, SuspectAction.Betrays), (-5, -5) },
        };

        public (int Suspect1, int Suspect2) CalculateSentence((SuspectAction Suspect1, SuspectAction Suspect2) interrogatoryResult)
        {
            if (Sentence.ContainsKey(interrogatoryResult))
            {
                return Sentence[interrogatoryResult];
            }
            throw new ArgumentException($"This interrogatory result is not managed yet. [{interrogatoryResult}]", nameof(interrogatoryResult));
        }

        public Winner GetWinner(IEnumerable<(int Suspect1, int Suspect2)> scoreHistory)
        {
            var suspect1Score = scoreHistory.Sum(x => x.Suspect1);
            var suspect2Score = scoreHistory.Sum(x => x.Suspect2);

            if (suspect1Score > suspect2Score)
            {
                return Winner.One;
            }
            if (suspect2Score > suspect1Score)
            {
                return Winner.Two;
            }
            return Winner.Null;
        }
    }
}