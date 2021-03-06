using System;
/// <summary>
///ctor
/// </summary>

public class ArrayTypeMismatchExceptionctor1
{
    public static int Main()
    {
        ArrayTypeMismatchExceptionctor1 ArrayTypeMismatchExceptionctor1 = new ArrayTypeMismatchExceptionctor1();
        TestLibrary.TestFramework.BeginTestCase("ArrayTypeMismatchExceptionctor1");
        if (ArrayTypeMismatchExceptionctor1.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }
    public bool RunTests()
    {
        bool retVal = true;
       TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
      
        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong

    public bool PosTest1()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest1: Create a new ArrayTypeMismatchException instance. ");
        try
        {
            ArrayTypeMismatchException myException = new ArrayTypeMismatchException();
            if (myException == null)
            {
                TestLibrary.TestFramework.LogError("001.1", " the constructor should not return  null. ");
                retVal = false;
            }
           
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("001.0", "Unexpected exception: " + e);
            retVal = false;
        }
       
        return retVal;
    }
   
}

