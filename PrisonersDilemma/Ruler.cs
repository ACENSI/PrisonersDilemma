namespace PrisonersDilemma
{
    internal sealed class Ruler: IRuler
    {
        Dictionary<(ActionEnum Suspect1, ActionEnum Suspect2), (int Suspect1, int Suspect2)> Sentence = new()
        {
            {(ActionEnum.StaysSilent, ActionEnum.StaysSilent), (-1, -1) },
            {(ActionEnum.Betrays, ActionEnum.StaysSilent), (0, -10) },
            {(ActionEnum.StaysSilent, ActionEnum.Betrays), (-10, 0) },
            {(ActionEnum.Betrays, ActionEnum.Betrays), (-5, -5) },
        };

        public (int Suspect1, int Suspect2) CalculateSentence((ActionEnum Suspect1, ActionEnum Suspect2) interrogatoryResult)
        {
            if (Sentence.ContainsKey(interrogatoryResult))
            {
                return Sentence[interrogatoryResult];
            }
            throw new ArgumentException("This interrogatory result is not managed yet.", nameof(interrogatoryResult));
        }
    }
}