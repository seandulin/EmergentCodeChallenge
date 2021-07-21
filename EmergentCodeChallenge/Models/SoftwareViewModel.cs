namespace EmergentCodeChallenge.Models
{
    public enum SoftwareVersionPart
    {
        Major = 0,
        Minor = 1,
        Patch = 2
    }

    public class SoftwareViewModel
    {
        public const int DefaultVersionPartValue = -1;
        public string Name { get; set; }
        public string Version { get; set; }
        public int MajorVersion { get; private set; }
        public int MinorVersion { get; private set; }
        public int PatchVersion { get; private set; }

        public SoftwareViewModel(string name)
        {
            Name = name;
        }
        public SoftwareViewModel(string name, string version): this(name)
        {
            Version = version;
            MajorVersion = ConvertVersionToIntPart(version, SoftwareVersionPart.Major);
            MinorVersion = ConvertVersionToIntPart(version, SoftwareVersionPart.Minor);
            PatchVersion = ConvertVersionToIntPart(version, SoftwareVersionPart.Patch);
        }

        /// <summary>
        /// Splits the version on a period and returns the specified part as an integer
        /// </summary>
        /// <param name="version">A string representation of the version.  eg: "2.0.0"</param>
        /// <param name="softwareVersionPart">A specification of which part of the version you want the value of</param>
        /// <returns>The specified version part as an integer</returns>
        private int ConvertVersionToIntPart(string version, SoftwareVersionPart softwareVersionPart)
        {
            var splitVersion = version.Split(".");
            int calculatedValue;
            if (splitVersion?.Length > (int)softwareVersionPart && !string.IsNullOrWhiteSpace(splitVersion?[(int)softwareVersionPart]))
            {
                calculatedValue = int.TryParse(splitVersion[(int)softwareVersionPart].Trim(), out calculatedValue) ? calculatedValue : DefaultVersionPartValue;
            }
            else
            {
                calculatedValue = DefaultVersionPartValue;
            }
            return calculatedValue;
        }

        /// <summary>
        /// Compares the current object to the given object and returns true if the current object is Greater Than and not equal to the given object using semantic versioning.
        /// </summary>
        /// <param name="obj">Object to compare to</param>
        /// <returns>true when the current object is greater than the given object.</returns>
        public bool GreaterThan(SoftwareViewModel obj)
        {
            if (MajorVersion > obj.MajorVersion) return true;
            if (MajorVersion == obj.MajorVersion && MinorVersion > obj.MinorVersion) return true;
            if (MajorVersion == obj.MajorVersion && MinorVersion == obj.MinorVersion && PatchVersion > obj.PatchVersion) return true;
            return false;
        }
    }
}
