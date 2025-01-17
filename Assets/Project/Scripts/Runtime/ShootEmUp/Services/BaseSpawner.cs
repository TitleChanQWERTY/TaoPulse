using TaoPulse.Services;
using UnityEngine;

namespace TaoPulse.ShootEmUp.Services
{
    public enum SpawnShape
    {
        Dot,
        Circle
    }
    
    public class BaseSpawner : MonoBehaviour
    {
        [Header("Shape")]
        [SerializeField] private SpawnShape spawnShape = SpawnShape.Dot;
        [SerializeField] private float radius = 5;
        [SerializeField] private bool rotateObjectByCircle;
        
        [Header("Spawn")]
        [SerializeField] private GameObject[] spawnObjects;
        [SerializeField] private float destroyingTime;
        [SerializeField, Min(0)] private float timeOutSpawn;

        private float _timeOutDelayTimer;
        private bool _isCanSpawn = true;

        private void Update()
        {
            Updating();
        }

        protected virtual void Updating()
        {
            
        }

        private bool TimeOutSpawn()
        {
            bool isTime = Timer.SimpleTimer(_timeOutDelayTimer, timeOutSpawn);
            if (!isTime) return false;
            _timeOutDelayTimer = Time.time;
            return true;
        }

        protected GameObject[] Spawn()
        {
            if (!_isCanSpawn) return null;
            if (!TimeOutSpawn()) return null;
            return spawnShape switch
            {
                SpawnShape.Dot => DotSpawn(),
                SpawnShape.Circle => CircleSpawn(),
                _ => null
            };
        }

        private GameObject[] CircleSpawn()
        {
            GameObject[] gameObjects = new GameObject[spawnObjects.Length];
            for (int i = 0; i < spawnObjects.Length; i++)
            {
                float angle = i * Mathf.PI * 2 / spawnObjects.Length;
                
                Vector2 spawnPosition = new Vector2(
                    Mathf.Cos(angle) * radius,
                    Mathf.Sin(angle) * radius
                );
                
                Vector2 direction = spawnPosition.normalized;

                // Розрахунок кута повороту для об'єкта
                float rotationZ;
                GameObject spawned;
                if (rotateObjectByCircle)
                {
                    rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    spawned = Instantiate(spawnObjects[i], spawnPosition + (Vector2)transform.position, Quaternion.Euler(0, 0, rotationZ));
                }
                else spawned = Instantiate(spawnObjects[i], spawnPosition + (Vector2)transform.position, Quaternion.identity);
                
                
                gameObjects[i] = spawned;
                if (destroyingTime <= 0) continue;
                Destroy(spawned, destroyingTime);
            }

            return gameObjects;
        }

        private GameObject[] DotSpawn()
        {
            GameObject[] gameObjects = new GameObject[spawnObjects.Length];
            for (int i = 0; i < spawnObjects.Length; i++)
            {
                GameObject spawned = Instantiate(spawnObjects[i], transform.position, Quaternion.identity);
                gameObjects[i] = spawned;
                if (destroyingTime <= 0) continue;
                Destroy(spawned, destroyingTime);
            }

            return gameObjects;
        }
        
        public void SetNewSpawnObjects(GameObject[] objects) => spawnObjects = objects;

        public void SetNewTimeout(float value) => timeOutSpawn = value;
    }
}