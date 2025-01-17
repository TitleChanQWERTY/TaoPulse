using TaoPulse.ShootEmUp.Services;

namespace Project.Scripts.Runtime.ShootEmUp.Enemy
{
    public sealed class EnemyBullet : BaseBullet
    {
        protected override void Init()
        {
            SetMoveDirection(transform.right);
        }
    }
}