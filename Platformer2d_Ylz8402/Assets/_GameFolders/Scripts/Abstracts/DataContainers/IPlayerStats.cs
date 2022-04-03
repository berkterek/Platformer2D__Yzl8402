
namespace Platformer2d.Abstracts.DataContainers
{
    public interface IPlayerStats : IStats
    {
        float JumpForce { get; }
        int MaxJumpCount { get; }
        
    }
}