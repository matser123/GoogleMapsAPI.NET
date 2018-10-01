using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleMapsAPI.NET.API.Common.Responses;
using GoogleMapsAPI.NET.API.Places.Results;

namespace GoogleMapsAPI.NET.API.Places.Responses
{
    [DataContract]
    public class FindPlaceResponse : APIResponse
    {
        #region Properties

        /// <summary>
        /// Set of attributions about this listing which must be displayed to the user.
        /// </summary>
        [DataMember(Name = "html_attributions")]
        public List<string> HTMLAttributions { get; set; }

        /// <summary>
        /// Result
        /// </summary>
        [DataMember(Name = "candidates")]
        public PlaceSearchResult[] Candidates { get; set; }

        [DataMember(Name = "debug_log")]
        public DebugLog DebugLog { get; set; }

        #endregion
    }
}
