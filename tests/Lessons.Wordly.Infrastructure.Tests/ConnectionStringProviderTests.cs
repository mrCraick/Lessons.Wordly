namespace Lessons.Wordly.Infrastructure.Tests;

public class ConnectionStringProviderTests
{
    [Fact]
    public void GetConnectionString_ShoudCreatedb()
    {
        // arrange
        
        var _dbName = $"{nameof(GetConnectionString_ShoudCreatedb)}.db";
        var connectionStringProvider = new ConnectionStringProvider(_dbName);
        
        // act

        _ = connectionStringProvider.GetConnectionString();
        
        // assert
        
        Assert.True(File.Exists(Path.Combine(Environment.CurrentDirectory, _dbName)));
    }
    
    [Fact]
    public void GetConnectionString_ShoudReturnCoccetCS()
    {
        // arrange
        
        var dbName = $"{nameof(GetConnectionString_ShoudReturnCoccetCS)}.db";
        var connectionStringProvider = new ConnectionStringProvider(dbName);
        
        // act

        var actual = connectionStringProvider.GetConnectionString();
        
        // assert
        
        Assert.Equal($"Data Source={Path.Combine(Environment.CurrentDirectory, dbName)};", actual);
    }
}