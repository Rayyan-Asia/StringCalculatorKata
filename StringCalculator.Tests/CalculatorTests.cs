namespace StringCalculator.Tests;
using Xunit;
public class CalculatorTests
{
    private IStringCalculator _calculator;

    public CalculatorTests()
    {
        _calculator = new StringCalculator();
    }

    [Fact]
    public void ShouldReturnCorrectSumOfThreeNumbers()
    {
        // Arrange
        var numbers = "1,2,3";
        var expected = 6;

        //Act
        var sum = _calculator.Add(numbers);

        //Assert
        Assert.Equal(expected, sum);
    }

    [Fact]
    public void ShouldReturnZero()
    {
        // Arrange
        var numbers = "";
        var expected = 0;

        //Act
        var sum = _calculator.Add(numbers);

        //Assert
        Assert.Equal(expected, sum);
    }

    [Fact]
    public void ShouldReturnNumber()
    {
        // Arrange
        var numbers = "1";
        var expected = 1;
        

        //Act
        var sum = _calculator.Add(numbers);

        //Assert
        Assert.Equal(expected, sum);
    }

    [Fact]
    public void ShouldThrowAnException()
    {

        //Arrange
        var numbers = "1,2,3,4";

        //Act and Assert 
        Assert.Throws<Exception>(() => _calculator.Add(numbers));
    }
}