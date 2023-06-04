using DVT.ElevatorChallenge.Entities;
using DVT.ElevatorChallenge.Enums;

namespace DVT.ElevatorChallenge.Extensions
{
    internal static class ElevatorExtensions
    {
        internal static string ShowStatus(this Elevator elevator)
        {
            return $"Elevator {elevator.Id} is at floor {elevator.CurrentFloor}, is {ShowElevatorStatus(elevator.Status)} and it is carrying {elevator.PeopleCount} people.";

            string ShowElevatorStatus(ElevatorStatus status) =>
                status == ElevatorStatus.GoingUp ? "going up" : "going down";
        }
    }
}
