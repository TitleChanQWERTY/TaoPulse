using TaoPulse.ShootEmUp.Services;

namespace TaoPulse.ShootEmUp.Player
{
    public sealed class PlayerHealth : BaseHealth
    {
        private void Awake()
        {
            SetDamageCooldown(0.5f);
            SetMaximumHealth(100);
        }
    }
}