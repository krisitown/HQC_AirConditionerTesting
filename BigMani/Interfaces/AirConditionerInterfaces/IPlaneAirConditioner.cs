namespace BigMani.Interfaces.AirConditionerInterfaces
{
    interface IPlaneAirConditioner : IAirConditioner
    {
        int VolumeCovered { get; set; }

        int ElectricityUsed { get; set; }
    }
}
