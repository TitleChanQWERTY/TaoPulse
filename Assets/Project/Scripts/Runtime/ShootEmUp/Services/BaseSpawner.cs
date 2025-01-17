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
        
        [Header("Spawn")]
        [SerializeField] private GameObject[] spawnObjects;
        [SerializeField] private float destroyingTime;
        [SerializeField, Min(0)] private float timeOutSpawn;
        [SerializeField] private bool onUpdate;

        private float _timeOutDelayTimer;
        private bool _isCanSpawn = true;

        private void Update()
        {
            TimeOutSpawn();
            Updating();
            if (onUpdate) Spawn();
        }

        protected virtual void Updating()
        {
            
        }

        private void TimeOutSpawn()
        {
            if (_isCanSpawn) return;
            if (Time.time - _timeOutDelayTimer < timeOutSpawn) return;
            _timeOutDelayTimer = Time.time;
            _isCanSpawn = true;
        }

        public void SetNewSpawnObjects(GameObject[] objects)
        {
            spawnObjects = objects;
        }

        public void SetNewTimeout(float value)
        {
            timeOutSpawn = value;
        }
        
        public void Spawn()
        {
            if (!_isCanSpawn) return;
            switch (spawnShape)
            {
                case SpawnShape.Dot:
                    DotSpawn();
                    break;
                case SpawnShape.Circle:
                    CircleSpawn();
                    break;
            }

            _isCanSpawn = false;
        }

        private void CircleSpawn()
        {
            for (int i = 0; i < spawnObjects.Length; i++)
            {
                float angle = i * Mathf.PI * 2 / spawnObjects.Length;
                
                Vector3 spawnPosition = new Vector3(
                    Mathf.Cos(angle) * radius,
                    Mathf.Sin(angle) * radius,
                    0f
                );
                
                GameObject spawned = Instantiate(spawnObjects[i], transform.position + spawnPosition, Quaternion.identity);
                if (destroyingTime <= 0) continue;
                Destroy(spawned, destroyingTime);
            }
        }

        private void DotSpawn()
        {
            for (int i = 0; i < spawnObjects.Length; i++)
            {
                GameObject spawned = Instantiate(spawnObjects[i], transform.position, Quaternion.identity);
                if (destroyingTime <= 0) continue;
                Destroy(spawned, destroyingTime);
            }
        }
    }
}