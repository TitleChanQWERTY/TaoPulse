using TaoPulse.ShootEmUp.Services;

namespace TaoPulse.ShootEmUp.Enemy
{
    public sealed class EnemyHealth : BaseHealth
    {
        private void OnDie()
        {
            Destroy(gameObject);
        }

        private void OnEnable()
        {
            OnDieEvent += OnDie;
        }
        
        private void OnDisable()
        {
            OnDieEvent -= OnDie;
        }
    }
}
