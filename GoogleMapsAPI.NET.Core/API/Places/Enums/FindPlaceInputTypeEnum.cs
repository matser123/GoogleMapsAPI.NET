using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Places.Enums
{
    public enum FindPlaceInputTypeEnum
    {
        [EnumMember(Value = "textquery")]
        TextQuery,

        [EnumMember(Value = "phonenumber")]
        PhoneNumber
    }
}
