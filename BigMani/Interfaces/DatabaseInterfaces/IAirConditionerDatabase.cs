using BigMani.Interfaces.AirConditionerInterfaces;

namespace BigMani.Interfaces.DatabaseInterfaces
{
    public interface IAirConditionerDatabase
    {
        void AddAirConditioner(IAirConditioner airConditioner);

        void RemoveAirConditioner(IAirConditioner airConditioner);

        IAirConditioner GetAirConditioner(string manufacturer, string model);
        
        int GetAirConditionersCount();
    }
}
