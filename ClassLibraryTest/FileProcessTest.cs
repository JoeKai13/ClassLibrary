using ClassLibrary;

namespace ClassLibraryTest;

[TestClass]
public class FileProcessTest : TestBase
{
    
    [TestMethod]
    public void FileNameDoesExist()
    {
        //Arrange
        FileProcess fp = new();
        fileName = GetTestSetting<string>("GoodFileName",TestConstants.GOOD_FILE_NAME);
        bool fromCall;

        //Add message to test output
        fileName = fileName.Replace("[AppDataPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        TestContext?.WriteLine($"Checking for file '{fileName}'");

        //Create a good file
        File.AppendAllText(fileName, "SomeText");

        //Act
        fromCall = fp.FileExists(fileName);

        //Delete a good file if it exists
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }

        //Assert
        Assert.IsTrue(fromCall);
    }
    [TestMethod]
    public void FileNameDoesNotExist()
    {
        //Arrange
        FileProcess fp = new();
        fileName = GetTestSetting<string>("BadFileName", TestConstants.BAD_FILE_NAME);
        bool fromCall;

        
        //Add message to test output
        TestContext?.WriteLine($"Checking for file '{fileName}' that does not exist.");

        //Act
        fromCall = fp.FileExists(fileName);

        //Assert
        Assert.IsFalse(fromCall);
    }
    [TestMethod]
    public void FileNameNullOrEmpty_UsingTryCatch_ShouldThrowArgumentNullException()
    {
        //Arrange
        //string fileName = string.Empty; //there would be a fail if path here actually existed "The call to FileExists() method did not throw ArgumentNullException and it should have.
        bool fromCall = false;
        //string outputMessage;
        try 
        {   
            //Act
            FileProcess fp = new FileProcess();

            //Add message to output
            outputMessage = GetTestSetting<string>("EmptyFileMsg", TestConstants.EMPTY_FILE_MESSAGE);
            TestContext?.WriteLine(outputMessage);

            fromCall = fp.FileExists(fileName);

            //Assert: Fail as we should not get here
            outputMessage = GetTestSetting<string>("EmptyFileFailMsg", TestConstants.EMPTY_FILE_FAIL_MESSAGE);
            
            Assert.Fail(outputMessage);
        }
        catch (ArgumentNullException)
        { 
            Assert.IsFalse(fromCall);
        }
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void FileNameNullOrEmpty_UsingExpectedExceptionAttribute()
    {
        //Arrange
        FileProcess fp = new();
        //string fileName = string.Empty;
        bool fromCall;
        //string outputMessage;

        outputMessage = GetTestSetting<string>("EmptyFileMsg", TestConstants.EMPTY_FILE_MESSAGE);
        TestContext?.WriteLine(outputMessage);

        fromCall = fp.FileExists(fileName);

        //Assert: Fail as we should not get here
        outputMessage = GetTestSetting<string>("EmptyFileFailMsg", TestConstants.EMPTY_FILE_FAIL_MESSAGE);
        Assert.Fail(outputMessage);

    }
}