namespace test;

public class UnitTest1
{
    [Fact]
    public void Boek()
    {
        // Arrange
        DatabaseContext context = new DatabaseContext();
        Gast gast = new Gast();
        Attractie attractie = new Attractie();
        TijdBereik datum = new TijdBereik();

        // Act
        var result = context.Boek(gast, attractie, datum);

        // Assert
        Assert.True(result);
    }
}