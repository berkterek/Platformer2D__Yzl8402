using Platformer2d.Abstracts.Combats;
using Platformer2d.Abstracts.DataContainers;
using Platformer2d.Abstracts.Inputs;
using Platformer2d.Abstracts.Movements;
using UnityEngine;

namespace Platformer2d.Abstracts.Controllers
{
    public interface IPlayerController : IEntityController,IAttackerController
    {
        IInputReader InputReader { get; }
        IGroundChecker GroundChecker { get; }
        IPlayerStats Stats { get; }
        IPlayerDataContainer PlayerData { get;}
        IPlayerHealth Health { get; }
        SpriteRenderer ObjectiveSpriteRenderer { get; }
        void IncreaseCoin(int coinValue);
        bool DecreaseCoin(int coinValue);
    }
}