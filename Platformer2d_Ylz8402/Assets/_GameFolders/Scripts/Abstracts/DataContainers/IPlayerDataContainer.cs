
using Platformer2d.ScriptableObjects;

namespace Platformer2d.Abstracts.DataContainers
{
    public interface IPlayerDataContainer
    {
        IPlayerStats Stats { get; }
        public int CurrentCoin { get; }
        bool DecreaseCoin(int coinValue);
        void IncreaseCoin(int coinValue);
        IntEventWithOneParameterSO HealthEvent { get; }
        StringEventWithOneParameterSO DyingEvent { get; }
    }
}