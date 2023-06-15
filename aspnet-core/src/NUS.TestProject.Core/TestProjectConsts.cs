using NUS.TestProject.Debugging;

namespace NUS.TestProject
{
    public class TestProjectConsts
    {
        public const string LocalizationSourceName = "TestProject";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "f4c50b59665c42b5bd433c3001547b63";
    }
}
