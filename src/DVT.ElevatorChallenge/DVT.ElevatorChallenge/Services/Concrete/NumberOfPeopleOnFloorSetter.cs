using DVT.ElevatorChallenge.Application;
using DVT.ElevatorChallenge.Constants;
using DVT.ElevatorChallenge.Services.Abstract;

namespace DVT.ElevatorChallenge.Services.Concrete
{
    internal class NumberOfPeopleOnFloorSetter : IOperationResolver
    {
        public void Resolve()
        {
            Console.WriteLine($"There are {MyApp.Settings.NumberOfFloors} floors to set people count for. Let's begin");

            foreach (var floor in MyApp.Floors)
            {
                bool isOkInput = false;
                do
                {
                    Console.WriteLine($"Setting people count for floor {floor.Id}");
                    if (!int.TryParse(Console.ReadLine(), out var peopleCount))
                    {
                        Console.WriteLine("Invalid input");
                        continue;
                    }

                    if (peopleCount < Constants.Constants.MinimumPossiblePeopleOnFloor)
                    {
                        Console.WriteLine($"{peopleCount} is below the minimum possible people on a floor, {Constants.Constants.MinimumPossiblePeopleOnFloor}.");
                        continue;
                    }
                    
                    if (peopleCount > MyApp.Settings.MaxPeopleOnFloor)
                    {
                        Console.WriteLine($"{peopleCount} is more than a floor supports.");
                        continue;
                    }

                    floor.PeopleCount = peopleCount;
                    isOkInput = true;
                } while (!isOkInput);
            }
        }
    }
}
