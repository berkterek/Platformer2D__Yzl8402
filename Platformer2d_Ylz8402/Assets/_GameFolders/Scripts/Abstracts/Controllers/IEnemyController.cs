namespace Platformer2d.Abstracts.Controllers
{
    public interface IEnemyController : IEntityController
    {
        float MoveSpeed { get; }
    }
}