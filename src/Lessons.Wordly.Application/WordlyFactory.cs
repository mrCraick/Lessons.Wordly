using Lessons.Wordly.Infrastructure;

namespace Lessons.Wordly.Application;

public sealed class WordlyFactory
{
    public Wordly GetRandom()
    {
        using var context = new LessonWordlyContext();
        var randomWord = context.Nouns.Skip(Random.Shared.Next(0, 65499)).FirstOrDefault();

        if(randomWord is null)
        {
            return GetRandom();
        }

        return new Wordly(randomWord.Word);
    }
}