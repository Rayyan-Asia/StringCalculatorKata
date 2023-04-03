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
    public void testAdd_shouldReturnCorrectSumOfThreeNumbers(string numbers, int expected)
    {
        //Act
        var sum = _calculator.Add(numbers);

        //Assert
        Assert.Equal(expected, sum);
    }

    [Theory]
    [InlineData("1, ,3", 4)]
    public void testAdd_shouldSkipTheSecondinput(string numbers, int expected)
    {
        //Act
        var sum = _calculator.Add(numbers);

        //Assert
        Assert.Equal(expected, sum);
    }

    [Theory]
    [InlineData("", 0)]
    public void testAdd_shouldReturnZero(string numbers, int expected)
    {
        //Act
        var sum = _calculator.Add(numbers);

        //Assert
        Assert.Equal(expected, sum);
    }

    [Theory]
    [InlineData("1", 1)]
    public void testAdd_shouldReturnNumber(string numbers, int expected)
    {

        //Act
        var sum = _calculator.Add(numbers);

        //Assert
        Assert.Equal(expected, sum);
    }

    [Theory]
    [InlineData("1,2,3,4,5", 15)]
    public void testAdd_shouldReturnSumOfNumbers(string numbers, int expected)
    {
        //Act
        var sum = _calculator.Add(numbers);

        //Assert
        Assert.Equal(expected, sum);
    }

    [Theory]
    [InlineData("\n1\n2,3\n4,5\n", 15)]
    public void testAdd_shouldSplitNewLineAndCalculateSumOfNumbers(string numbers, int expected)
    {
        //Act
        var sum = _calculator.Add(numbers);

        //Assert
        Assert.Equal(expected, sum);
    }

    [Theory]
    [InlineData("//;\n1;2;3;4\n5", 15)]
    [InlineData("//.\n1.2.3.4\n5", 15)]
    public void testAdd_shouldTakeCustomDelimiterAndCalculateSumOfNumbers(string numbers, int expected)
    {
        //Act
        var sum = _calculator.Add(numbers);

        //Assert
        Assert.Equal(expected, sum);
    }

    [Fact]
    public void testAdd_shouldThrowExceptionForForgottenCustomDelimiter()
    {
        //Arrange 
        string numbers = "//\n1;2;3;4\n5";
        //Act and Assert
        Assert.Throws<Exception>(() => _calculator.Add(numbers));
    }

    [Fact]
    public void testAdd_shouldThrowExceptionForNegativeNumber()
    {
        //Arrange 
        string numbers = "1,2,3,-4\n5";
        //Act and Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Add(numbers));
    }

    [Theory]
    [InlineData("//;\n1;2;3;4\n5;1001;1000", 1015)]
    public void testAdd_shouldIgnoreNumbersGreaterThan1000(string numbers, int expected)
    {
        //Act
        var sum = _calculator.Add(numbers);

        //Assert
        Assert.Equal(expected, sum);
    }

}