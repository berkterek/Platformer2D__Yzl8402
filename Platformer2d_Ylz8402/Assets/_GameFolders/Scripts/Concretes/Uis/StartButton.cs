using Platformer2d.Abstracts.Uis;
using Platformer2d.Managers;

namespace Platformer2d.Uis
{
    public class StartButton : BaseButton
    {
        protected override void HandleOnButtonClicked()
        {
            //bu button icinde ne olucaksa burdaki senaryoda oyun baslamasi
            GameManager.Instance.LoadGameScene("Level1");
        }
    }
}