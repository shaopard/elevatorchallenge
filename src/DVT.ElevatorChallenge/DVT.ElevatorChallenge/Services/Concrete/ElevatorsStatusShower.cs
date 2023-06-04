using DVT.ElevatorChallenge.Application;
using DVT.ElevatorChallenge.Extensions;
using DVT.ElevatorChallenge.Services.Abstract;

namespace DVT.ElevatorChallenge.Services.Concrete
{
    internal class ElevatorsStatusShower : IOperationResolver
    {
        public void Resolve()
        {
            foreach (var elevator in MyApp.Elevators)
            {
                Console.WriteLine(elevator.ShowStatus());
            }
        }
    }
}
