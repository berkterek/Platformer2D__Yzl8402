using UnityEngine;

namespace Platformer2d.Abstracts.Controllers
{
    public interface IFlyEnemyController : IEnemyController
    {
        float MaxDistance { get; }
        Vector3 Direction { get; set; }
    }
}