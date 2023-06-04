using DVT.ElevatorChallenge.Services.Abstract;
using System.Configuration;
using DVT.ElevatorChallenge.Constants;
using ConfigurationSettings = DVT.ElevatorChallenge.Configuration.ConfigurationSettings;

namespace DVT.ElevatorChallenge.Services.Concrete
{
    internal class ConfigurationReader : IConfigurationReader
    {
        public ConfigurationSettings GetFromFile()
        {
            var settings = new ConfigurationSettings
            {
                NumberOfElevators = GetConfigurationValue("NumberOfElevators", Constants.Constants.MinimumNumberOfElevators),
                NumberOfFloors = GetConfigurationValue("NumberOfFloors", Constants.Constants.MinimumNumberOfFloors),
                MaxPeopleOnFloor = GetConfigurationValue("MaxPeopleOnFloor", Constants.Constants.MinimumPossiblePeopleOnFloor),
                ElevatorWeightLimit = GetConfigurationValue("ElevatorWeightLimit", Constants.Constants.MinimumElevatorWeightLimit)
            };

            return settings;
        }

        private static int GetConfigurationValue(string configName, int minimalValue)
        {
            var value = int.Parse(ConfigurationManager.AppSettings[configName]!);

            if (value < minimalValue)
            {
                throw new ArgumentOutOfRangeException(nameof(configName));
            }

            return value;
        }
    }
}
