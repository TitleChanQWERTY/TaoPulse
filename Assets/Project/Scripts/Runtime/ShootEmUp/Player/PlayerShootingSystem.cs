using TaoPulse.Managers;
using TaoPulse.ShootEmUp.Services;

namespace TaoPulse.ShootEmUp.Player
{
    public sealed class PlayerShootingSystem : BaseSpawner
    {
        protected override void Updating()
        {
            if (InputManager.Instance.InputActions.ShootEmUp.Attack.IsPressed())
            {
                Spawn();
            }
        }
    }
}