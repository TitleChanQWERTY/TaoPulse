using TaoPulse.ShootEmUp.Services;

namespace TaoPulse.ShootEmUp.Player
{
    public sealed class PlayerBullet : BaseBullet
    {
        protected override void Init()
        {
            SetMoveDirection(PlayerController.Instance.transform.right);
            transform.rotation = PlayerController.Instance.transform.rotation;
        }
    }
}