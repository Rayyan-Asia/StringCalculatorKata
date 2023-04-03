namespace StringCalculator.Tests;
using Xunit;
public class CalculatorTests
{
    private IStringCalculator _calculator;

    public CalculatorTests()
    {
        _calculator = new StringCalculator();
    }

    [Theory]
    [InlineData("1,2,3", 6)]
    public void ShouldReturnCorrectSumOfThreeNumbers(string numbers, int expected)
    {
        //Act
        var sum = _calculator.Add(numbers);

        //Assert
        Assert.Equal(expected, sum);
    }

    [Theory]
    [InlineData("1, ,3", 4)]
    public void ShouldSkipTheSecondinput(string numbers, int expected)
    {
        //Act
        var sum = _calculator.Add(numbers);

        //Assert
        Assert.Equal(expected, sum);
    }

    [Theory]
    [InlineData("", 0)]
    public void ShouldReturnZero(string numbers, int expected)
    {
        //Act
        var sum = _calculator.Add(numbers);

        //Assert
        Assert.Equal(expected, sum);
    }

    [Theory]
    [InlineData("1", 1)]
    public void ShouldReturnNumber(string numbers, int expected)
    {

        //Act
        var sum = _calculator.Add(numbers);

        //Assert
        Assert.Equal(expected, sum);
    }

    [Theory]
    [InlineData("1,2,3,4,5", 15)]
    public void ShouldReturnSumOfNumbers(string numbers, int expected)
    {
        //Act
        var sum = _calculator.Add(numbers);

        //Assert
        Assert.Equal(expected, sum);
    }

    [Theory]
    [InlineData("\n1\n2,3\n4,5\n", 15)]
    public void ShouldSplitNewLineAndCalculateSumOfNumbers(string numbers, int expected)
    {
        //Act
        var sum = _calculator.Add(numbers);

        //Assert
        Assert.Equal(expected, sum);
    }

    [Theory]
    [InlineData("//;\n1;2;3;4\n5", 15)]
    [InlineData("//.\n1.2.3.4\n5", 15)]
    public void ShouldTakeCustomDelimiterAndCalculateSumOfNumbers(string numbers, int expected)
    {
        //Act
        var sum = _calculator.Add(numbers);

        //Assert
        Assert.Equal(expected, sum);
    }

    [Fact]
    public void ShouldThrowExceptionForForgottenCustomDelimiter()
    {
        //Arrange 
        string numbers = "//\n1;2;3;4\n5";
        //Act and Assert
        Assert.Throws<ArgumentException>(() => _calculator.Add(numbers));
    }

    [Fact]
    public void ShouldThrowExceptionForNegativeNumber()
    {
        //Arrange 
        string numbers = "1,2,3,-4\n5";
        //Act and Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Add(numbers));
    }

}