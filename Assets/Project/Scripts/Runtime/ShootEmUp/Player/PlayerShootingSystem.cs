using TaoPulse.Managers;
using TaoPulse.ShootEmUp.Services;
using UnityEngine;

namespace TaoPulse.ShootEmUp.Player
{
    public sealed class PlayerShootingSystem : BaseSpawner
    {
        [Header("Bullet Setup")]
        [SerializeField] private int bulletDamage;
        [SerializeField] private float bulletSpeed = 75f;
        
        protected override void Updating()
        {
            if (!InputManager.Instance.InputActions.ShootEmUp.Attack.IsPressed()) return;
            GameObject[] gameObjects = Spawn();

            if (gameObjects == null) return;
            foreach (var objects in gameObjects)
            {
                PlayerBullet playerBullet = objects.GetComponent<PlayerBullet>();
                if (!playerBullet) continue;
                playerBullet.SetDamage(bulletDamage);
                playerBullet.SetSpeed(bulletSpeed);
            }
        }

        public void SetBulletsDamage(int value) => bulletDamage = value;
        public void SetBulletsSpeed(float value) => bulletSpeed = value;
    }
}