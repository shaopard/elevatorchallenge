using DVT.ElevatorChallenge.Configuration;
using DVT.ElevatorChallenge.Entities;
using DVT.ElevatorChallenge.Enums;
using DVT.ElevatorChallenge.Services.Abstract;
using DVT.ElevatorChallenge.Services.Concrete;
using System.Linq;

namespace DVT.ElevatorChallenge.Application
{
    internal class MyApp
    {
        internal static IEnumerable<Elevator> Elevators;
        internal static IEnumerable<Floor> Floors;
        internal static ConfigurationSettings Settings;

        private readonly IDictionary<SupportedOperation, IOperationResolver> _operations;

        public MyApp(IConfigurationReader configurationReader)
        {
            Settings = configurationReader.GetFromFile();
            Elevators = SetElevators();
            Floors = SetFloors();

            _operations = new Dictionary<SupportedOperation, IOperationResolver>
            {
                { SupportedOperation.ShowEachElevatorStatus, new ElevatorsStatusShower() },
                { SupportedOperation.CallElevator, new ElevatorCaller() },
                { SupportedOperation.SetNumberOfPeopleOnEachFloor, new NumberOfPeopleOnFloorSetter() }
            };
        }

        internal void Run()
        {
            do
            {
                bool okInput;
                WriteBasicPrompt();

                if (!int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                var operation = (SupportedOperation)option;
                if (operation == SupportedOperation.Quit)
                {
                    break;
                }

                if (!_operations.ContainsKey(operation))
                {
                    Console.WriteLine("Unknown feature");
                    continue;
                }

                _operations[operation].Resolve();
            } while (true);
        }

        private IEnumerable<Elevator> SetElevators()
        {
            var rnd = new Random();
            var elevators = new List<Elevator>(Settings.NumberOfElevators);

            for (var i = 1; i <= Settings.NumberOfElevators; i++)
            {
                var elevator = new Elevator
                {
                    Id = i,
                    PeopleCount = rnd.Next(0, Settings.ElevatorWeightLimit),
                    Status = rnd.Next() % 2 == 0 ? ElevatorStatus.GoingUp : ElevatorStatus.GoingDown,
                    CurrentFloor = rnd.Next(1, Settings.NumberOfFloors)
                };
                elevators.Add(elevator);
            }

            return elevators;
        }

        private IEnumerable<Floor> SetFloors()
        {
            var rnd = new Random();
            var floors = new List<Floor>(Settings.NumberOfElevators);

            for (var i = 1; i <= Settings.NumberOfFloors; i++)
            {
                var floor = new Floor
                {
                    Id = i,
                    PeopleCount = rnd.Next(0, Settings.MaxPeopleOnFloor)
                };

                floors.Add(floor);
            }

            return floors;
        }

        private void WriteBasicPrompt()
        {
            Console.WriteLine();
            Console.WriteLine("0. Quit");
            Console.WriteLine("1. Show each elevator status");
            Console.WriteLine("2. Call elevator");
            Console.WriteLine("3. Set number of people on each floor");
        }
    }
}
