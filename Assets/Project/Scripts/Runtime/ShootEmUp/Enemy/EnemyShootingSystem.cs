using TaoPulse.ShootEmUp.Services;
using UnityEngine;

namespace Project.Scripts.Runtime.ShootEmUp.Enemy
{
    public sealed class EnemyShootingSystem : BaseSpawner
    {
        [Header("Bullet Setup")]
        [SerializeField] private float bulletSpeed = 75f;
        
        protected override void Updating()
        {
            GameObject[] gameObjects = Spawn();

            if (gameObjects == null) return;
            foreach (var objects in gameObjects)
            {
                EnemyBullet enemyBullet = objects.GetComponent<EnemyBullet>();
                if (!enemyBullet) continue;
                enemyBullet.SetSpeed(bulletSpeed);
            }
        }
        
        public void SetBulletsSpeed(float value) => bulletSpeed = value;
    }
}