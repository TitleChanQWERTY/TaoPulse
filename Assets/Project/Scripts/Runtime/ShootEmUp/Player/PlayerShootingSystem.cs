using TaoPulse.Managers;
using TaoPulse.ShootEmUp.Services;
using UnityEngine;

namespace TaoPulse.ShootEmUp.Player
{
    public sealed class PlayerShootingSystem : BaseSpawner
    {
        [Header("Bullet Setup")]
        [SerializeField] private float bulletSpeed = 75f;
        
        private void Update()
        {
            if (!InputManager.Instance.InputActions.ShootEmUp.Attack.IsPressed()) return;
            GameObject[] gameObjects = Spawn();

            if (gameObjects == null) return;
            foreach (var objects in gameObjects)
            {
                if (!objects.TryGetComponent(out PlayerBullet playerBullet)) continue;
                playerBullet.SetSpeed(bulletSpeed);
            }
        }
        
        public void SetBulletsSpeed(float value) => bulletSpeed = value;
    }
}