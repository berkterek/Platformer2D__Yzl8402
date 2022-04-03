
namespace Platformer2d.Abstracts.DataContainers
{
    public interface IPlayerDataContainer
    {
        IPlayerStats Stats { get; }
        public int CurrentCoin { get; }
        bool DecreaseCoin(int coinValue);
        void IncreaseCoin(int coinValue);
    }
}