using Platformer2d.Abstracts.Movements;
using Platformer2d.Movements;

namespace Platformer2d.Abstracts.Controllers
{
    public interface ISlimeEnemyController : IEnemyController
    {
        float Direction { get; set; }
        IGroundChecker GroundChecker { get; }
        IFlip Flip { get;}
    }
}