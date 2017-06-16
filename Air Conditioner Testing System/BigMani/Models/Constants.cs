namespace AirConditionalTesterSystem.Models
{
    public static class Constants
    {
        public const string IncorrectPropertyLength = "{0}'s name must be at least {1} symbols long.";

        public const string NoReportsMessage = "No reports.";

        public const string InvalidCommandMessage = "Invalid command";

        public const string StatusMessage = "Jobs complete: {0:F2}%";

        public const string IncorrectEfficiencyMessage = "Energy efficiency rating must be between \"A\" and \"E\".";

        public const string NotPossitiveMessage = "{0} must be a positive integer.";

        public const string DuplicateEntryMessage = "An entry for the given model already exists.";

        public const string NonExistingEntryMessage = "The specified entry does not exist.";

        public const string SuccessfullRegistrationMessage = "Air Conditioner model {0} from {1} registered successfully.";

        public const string SuccessfullTestMessage = "Air Conditioner model {0} from {1} tested successfully.";

        public const int ModelMinLength = 1;

        public const int ManufacturerMinLength = 4;

        public const int MinCarVolume = 3;

        public const int MinPlaneElectricity = 150;
    }
}
