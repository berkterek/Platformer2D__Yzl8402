namespace Platformer2d.Abstracts.Controllers
{
    public interface IEnemyController : IEntityController, IAttackerController
    {
        float MoveSpeed { get; }
    }
}