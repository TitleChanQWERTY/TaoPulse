using UnityEngine;

namespace TaoPulse.ShootEmUp.Services
{
    public abstract class BaseMovePhysicalObject : MonoBehaviour
    {
        private Vector2 _directionMove;
        
        private float _speed;
        
        private Rigidbody2D _rigidbody2D;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            Init();
        }

        protected abstract void Init();

        private void FixedUpdate()
        {
            _rigidbody2D.linearVelocity = _directionMove.normalized * _speed;
        }

        public void SetSpeed(float value) => _speed = value;

        public void SetMoveDirection(Vector2 direction) => _directionMove = direction;
        public void SetRotation(float angle) => _rigidbody2D.rotation = angle;
    }
}

