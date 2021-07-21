using System.Collections.Generic;

namespace EmergentCodeChallenge.Models
{
    public class SearchViewModel
    {
        public string SoftwareVersion { get; set; }
        public IEnumerable<SoftwareViewModel> SoftwareResults { get; private set; }
        public string Message { get; set; }

        public SearchViewModel()
        {

        }

        public SearchViewModel(string version, IEnumerable<SoftwareViewModel> results)
        {
            SoftwareVersion = version;
            SoftwareResults = results;
        }
    }
}
