using DVT.ElevatorChallenge.Enums;

namespace DVT.ElevatorChallenge.Entities
{
    internal class Elevator
    {
        public int Id { get; set; }
        public ElevatorStatus Status { get; set; }
        public int PeopleCount { get; set; }

        public int CurrentFloor { get; set; }
    }
}
