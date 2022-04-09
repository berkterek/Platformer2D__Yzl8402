using Platformer2d.Abstracts.Uis;
using Platformer2d.Managers;

namespace Platformer2d.Uis
{
    public class ExitButton : BaseButton
    {
        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.ExitGame();
        }
    }
}