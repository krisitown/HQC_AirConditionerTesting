namespace BigMani.Interfaces.AirConditionerInterfaces
{
    public interface ICommand
    {
        string Name { get; }

        string[] Parameters { get; }
    }
}
