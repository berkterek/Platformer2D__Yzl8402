
namespace Platformer2d.Abstracts.Combats
{
    public interface IHealth
    {
        void TakeDamage(IAttacker attacker);
        int MaxHealth { get; }
        int CurrentHealth { get; }
        event System.Action OnDead;
        event System.Action OnTookHit;
    }
}