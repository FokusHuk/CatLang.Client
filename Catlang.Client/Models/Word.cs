namespace Catlang.Client.Models
{
    public class Word
    {
        public Word(int id, string original, string translation)
        {
            Id = id;
            Original = original;
            Translation = translation;
        }

        public int Id { get; }

        public string Original { get; set; }

        public string Translation { get; set; }
    }
}
