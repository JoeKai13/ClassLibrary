

namespace ClassLibraryTest;

internal class TestConstants
{
    public const string GOOD_FILE_NAME = @"C:\Windows\Regedit.exe";
    public const string BAD_FILE_NAME = @"C:\Nonexistent.exe";
    public const string EMPTY_FILE_MESSAGE = "Checking for an empty file name.";
    public const string EMPTY_FILE_FAIL_MESSAGE = "The call to FileExists() method did not throw ArgumentNullException and it should have.";
}
