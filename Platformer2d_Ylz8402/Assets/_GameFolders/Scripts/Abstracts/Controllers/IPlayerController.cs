using Platformer2d.Abstracts.DataContainers;
using Platformer2d.Abstracts.Inputs;
using Platformer2d.Abstracts.Movements;
using Platformer2d.Movements;

namespace Platformer2d.Abstracts.Controllers
{
    public interface IPlayerController : IEntityController,IHealthController,IAttackerController
    {
        IInputReader InputReader { get; }
        IGroundChecker GroundChecker { get; }
        IPlayerStats Stats { get; }
    }
}