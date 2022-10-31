using HotAndCold;
namespace HotAndCold.Test;

public class UnitTest1
{
    [Fact]
    // unitOfTest_TestCondition_CorrectBehavior
    public void printResult_CorrectGuess_Congratulate()
    {
        //a unit test needs to be precise!
        Guessing tmp = new Guessing();
        int secret = 5;
        int user = 5;
        string expected = "Congratulations, you've guessed the secret number!";
        
        string result = tmp.printResult(secret,user);
        Assert.Equal(expected: expected, actual: result);
    }
    [Fact]
    public void printResult_wrongGuess_Congratulate()
    {
        //a unit test needs to be precise!
        Guessing tmp = new Guessing();
        int secret = 5;
        int user = 6;
        string expected = "Oops, you've guessed too high!";
        
        string result = tmp.printResult(secret,user);
        Assert.Equal(expected: expected, actual: result);
    }
}