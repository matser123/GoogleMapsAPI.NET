using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Places.Components
{
    /// <summary>
    /// Place opening periods component
    /// </summary>
    [DataContract]
    public class PlaceOpeningPeriods
    {

        #region Properties

        /// <summary>
        /// When the place opens
        /// </summary>
        [DataMember(Name = "open")]
        public PlaceOpeningPeriodDayTime Open { get; set; }

        /// <summary>
        /// When the place closes
        /// </summary>
        [DataMember(Name = "close")]
        public PlaceOpeningPeriodDayTime Close { get; set; }

        #endregion

    }
}