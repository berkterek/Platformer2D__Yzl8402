using Platformer2d.Abstracts.Inputs;
using Platformer2d.Movements;

namespace Platformer2d.Abstracts.Controllers
{
    public interface IPlayerController : IEntityController
    {
        IInputReader InputReader { get; }
        IGroundChecker GroundChecker { get; }
    }
}