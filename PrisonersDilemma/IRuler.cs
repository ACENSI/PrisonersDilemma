namespace PrisonersDilemma
{
    internal interface IRuler
    {
        (int Suspect1, int Suspect2) CalculateSentence((ActionEnum Suspect1, ActionEnum Suspect2) interrogatoryResult);
    }
}