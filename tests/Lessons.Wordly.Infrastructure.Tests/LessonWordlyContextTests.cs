namespace Lessons.Wordly.Infrastructure.Tests;

public sealed class LessonWordlyContextTests
{
    [Fact]
    public void AR()
    {
        // arrange

        using var lessonWordlyContext = new LessonWordlyContext();
        
        // actual

        var count = lessonWordlyContext.Nouns.Count();
        
        // assert
        
        Assert.Equal(65500, count);
    }
}