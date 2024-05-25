namespace Lessons.Wordly.Application;

public sealed class Wordly
{
    private readonly string _word;

    public Wordly(string word)
    {
        _word = word;
    }

    public int LengthOfWord => _word.Length;

    public IEnumerable<WordCheckResult> CheckWord(string word)
    {
        if(word.Length != _word.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(word), $"Wrong size. Wating for {_word.Length}, but get {word.Length}");
        }

        for(var i = 0; i < _word.Length; i++)
        {
            var letter = word[i];

            if(letter == _word[i])
            {
                yield return new WordCheckResult(letter, Status.ContainsOnThisPosition);
            }
            else if(_word.Contains(letter))
            {
                yield return new WordCheckResult(letter, Status.Contains);
            }

            yield return new WordCheckResult(letter, Status.DoesNotContain);
        }
    }
}