namespace TaoPulse.ShootEmUp.Services
{
    public abstract class BaseBullet : BaseMovingPhysicalObject
    {
        private int _damage;

        public void SetDamage(int value) => _damage = value;
    }
}