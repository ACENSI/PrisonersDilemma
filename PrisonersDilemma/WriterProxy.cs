namespace PrisonersDilemma
{
    internal class WriterProxy : IWriterProxy
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}