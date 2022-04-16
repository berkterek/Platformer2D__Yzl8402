using Platformer2d.Abstracts.Uis;
using Platformer2d.Managers;

namespace Platformer2d.Uis
{
    public class ReturnMenuButton : BaseButton
    {
        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.LoadMenuScene();
        }
    }
}