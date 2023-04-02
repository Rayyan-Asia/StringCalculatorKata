namespace StringCalculator.Tests;
using Xunit;
public class CalculatorTests
{
    [Fact]

    public void ShouldReturnCorrectSumOfThreeNumbers()
    {
        // Arrange
        var numbers = "1,2,3";
        var expected = 6;
        var calculator = new StringCalculator();

        //Act
        var sum = calculator.Add(numbers);

        //Assert
        Assert.Equal(expected, sum);
    }

    [Fact]
    public void ShouldReturnZero()
    {
        // Arrange
        var numbers = "";
        var expected = 0;
        var calculator = new StringCalculator();

        //Act
        var sum = calculator.Add(numbers);

        //Assert
        Assert.Equal(expected, sum);
    }

    [Fact]
    public void ShouldReturnNumber()
    {
        // Arrange
        var numbers = "1";
        var expected = 1;
        var calculator = new StringCalculator();

        //Act
        var sum = calculator.Add(numbers);

        //Assert
        Assert.Equal(expected, sum);
    }

    [Fact]
    public void ShouldThrowAnException()
    {

        //Arrange
        var numbers = "1,2,3,4";
        var calculator = new StringCalculator();

        //Assert 
        Assert.Throws<Exception>(() => calculator.Add(numbers));
    }
}