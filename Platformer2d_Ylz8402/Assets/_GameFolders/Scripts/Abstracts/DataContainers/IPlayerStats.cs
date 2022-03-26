
namespace Platformer2d.Abstracts.DataContainers
{
    public interface IPlayerStats
    {
        float MoveSpeed { get; }
        float JumpForce { get; }
        int MaxJumpCount { get; }
        int MaxHealth { get; }
    }
}