using TaoPulse.ShootEmUp.Services;
using UnityEngine;

namespace TaoPulse.ShootEmUp.Enemy
{
    public sealed class EnemyShootingSystem : BaseSpawner
    {
        [Header("Bullet Setup")]
        [SerializeField] private float bulletSpeed = 75f;
        
        private void Update()
        {
            GameObject[] gameObjects = Spawn();

            if (gameObjects == null) return;
            foreach (var objects in gameObjects)
            {
                if (!objects.TryGetComponent(out EnemyBullet enemyBullet)) continue;
                enemyBullet.SetSpeed(bulletSpeed);
            }
        }
        
        public void SetBulletsSpeed(float value) => bulletSpeed = value;
    }
}