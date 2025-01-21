using TaoPulse.ShootEmUp.Services;

namespace TaoPulse.ShootEmUp.Enemy
{
    public sealed class EnemyBullet : BaseBullet
    {
        protected override void Init()
        {
            SetMoveDirection(transform.right);
        }
    }
}