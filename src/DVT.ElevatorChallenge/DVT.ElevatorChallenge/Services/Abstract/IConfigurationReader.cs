using DVT.ElevatorChallenge.Configuration;

namespace DVT.ElevatorChallenge.Services.Abstract
{
    internal interface IConfigurationReader
    {
        ConfigurationSettings GetFromFile();
    }
}
