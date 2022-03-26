namespace Platformer2d.Abstracts.Movements
{
    public interface IGroundChecker
    {
        bool IsOnGround { get; }
        void FixedTick();
    }
}