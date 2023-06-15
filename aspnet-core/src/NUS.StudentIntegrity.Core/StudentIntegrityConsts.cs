using NUS.StudentIntegrity.Debugging;

namespace NUS.StudentIntegrity
{
    public class StudentIntegrityConsts
    {
        public const string LocalizationSourceName = "StudentIntegrity";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "981aa94900c7443dad8d80d54f6a325c";
    }
}
