using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Places.Responses
{
    public class DebugLog
    {
        [DataMember(Name = "line")]
        public string[] Line { get; set; }
    }
}