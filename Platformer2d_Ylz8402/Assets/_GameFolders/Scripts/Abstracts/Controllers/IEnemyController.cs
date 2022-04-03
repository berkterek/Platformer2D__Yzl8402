using Platformer2d.Abstracts.DataContainers;

namespace Platformer2d.Abstracts.Controllers
{
    public interface IEnemyController : IEntityController, IAttackerController, IHealthController
    {
        IEnemyStats Stats { get; }
    }
}