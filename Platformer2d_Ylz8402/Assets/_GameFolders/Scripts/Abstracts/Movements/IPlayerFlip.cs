namespace Platformer2d.Movements
{
    public interface IPlayerFlip : IFlip
    {
        void Tick();
        void LateTick();
    }
}