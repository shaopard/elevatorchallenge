using DVT.ElevatorChallenge.Application;
using DVT.ElevatorChallenge.Entities;
using DVT.ElevatorChallenge.Extensions;
using DVT.ElevatorChallenge.Services.Abstract;

namespace DVT.ElevatorChallenge.Services.Concrete
{
    internal class ElevatorCaller : IOperationResolver
    {
        public void Resolve()
        {
            int floorCallingElevator = 0;
            bool isOkInput = false;
            do
            {
                Console.WriteLine("To which floor are you calling the elevator?");

                if (!int.TryParse(Console.ReadLine(), out floorCallingElevator))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                if (floorCallingElevator < 1 || floorCallingElevator > MyApp.Settings.NumberOfFloors)
                {
                    Console.WriteLine($"Floor {floorCallingElevator} does not exist. Please provide a valid floor");
                    continue;
                }
                
                isOkInput = true;
            } while (!isOkInput);

            var availableElevators =
                MyApp.Elevators.Where(elevator => elevator.PeopleCount < MyApp.Settings.ElevatorWeightLimit).ToList();

            if (!availableElevators.Any())
            {
                Console.WriteLine("All elevators are full");
            }
            else
            {
                var elevatorToCome = availableElevators.First();
                for (var i = 1; i < availableElevators.Count - 1; i++)
                {
                    if (elevatorToCome.CurrentFloor - floorCallingElevator >
                        availableElevators[i].CurrentFloor - floorCallingElevator)
                    {
                        elevatorToCome = availableElevators[i];
                    }
                }

                Console.WriteLine("The elevator coming is:");
                Console.WriteLine($"{elevatorToCome.ShowStatus()}");
            }
        }
    }
}
