namespace BigMani.Interfaces.AirConditionerInterfaces
{
    interface IStationaryAirConditioner : IAirConditioner
    {
        int PowerUsage { get; set; }

        string EnergyRating { get; set; }
    }
}
