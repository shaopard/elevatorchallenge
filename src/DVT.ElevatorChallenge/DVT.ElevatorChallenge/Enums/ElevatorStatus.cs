using System.ComponentModel.DataAnnotations;

namespace DVT.ElevatorChallenge.Enums
{
    internal enum ElevatorStatus
    {
        [Display(Name = "Out of Service")]
        OutOfService,
        [Display(Name = "Stopped")]
        Stopped,
        [Display(Name = "Going Up")]
        GoingUp,
        [Display(Name = "Going Down")]
        GoingDown
    }
}
