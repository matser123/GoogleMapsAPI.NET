namespace GoogleMapsAPI.NET.API.Places.Enums
{
    public enum FindPlaceFieldsEnum
    {
        #region Basic

        formatted_address,
        geometry,
        icon,
        id,
        name,
        permanently_closed,
        photos,
        place_id,
        plus_code,
        scope,
        types,

        #endregion

        #region Contact

        opening_hours,

        #endregion

        #region Atmosphere

        price_level,
        rating

        #endregion
    }
}