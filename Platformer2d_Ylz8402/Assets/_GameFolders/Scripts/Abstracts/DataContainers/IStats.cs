namespace Platformer2d.Abstracts.DataContainers
{
    public interface IStats
    {
        float MoveSpeed { get; }
        int MaxHealth { get; }
        int Damage { get; }
    }
}