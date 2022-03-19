using Platformer2d.Abstracts.Inputs;

namespace Platformer2d.Abstracts.Controllers
{
    public interface IPlayerController : IEntityController
    {
        IInputReader InputReader { get; }    
    }
}