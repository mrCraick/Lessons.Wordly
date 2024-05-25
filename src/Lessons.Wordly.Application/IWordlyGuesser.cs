namespace Lessons.Wordly.Application;

public interface IWordlyGuesser
{
    string? TryGuess(Wordly wordly);
}