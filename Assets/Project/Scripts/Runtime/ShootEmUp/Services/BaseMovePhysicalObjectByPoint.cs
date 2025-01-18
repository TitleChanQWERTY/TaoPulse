using UnityEngine;

namespace TaoPulse.ShootEmUp.Services
{
    public enum MovingType
    {
        Smooth,
        AutoReverseSmooth
    }
    public class BaseMovePhysicalObjectByPoint : MonoBehaviour
    {
        [SerializeField] private Transform[] movingPoints;
        [SerializeField] private MovingType movingType = MovingType.Smooth;
        [SerializeField] private float speed = 20f;
        
        private Rigidbody2D _rigidbody2D;
        
        private int _pointIndex;

        private int _direction = 1;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            int lenght = movingPoints.Length;
            if (lenght == 0) return;
            
            Vector2 currentPosition = _rigidbody2D.position;
            Vector2 targetPosition = movingPoints[_pointIndex].position;
            
            Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetPosition, speed * Time.fixedDeltaTime);
            _rigidbody2D.MovePosition(newPosition);
            
            if (!(Vector2.Distance(currentPosition, targetPosition) < 0.1f)) return;
            switch (movingType)
            {
                case MovingType.Smooth:
                    _pointIndex++;
                    _pointIndex = Mathf.Clamp(_pointIndex, 0, lenght-1);
                    break;
                case MovingType.AutoReverseSmooth:
                {
                    _pointIndex += _direction;
                    
                    if (_pointIndex >= lenght || _pointIndex < 0)
                    {
                        _direction *= -1;
                        _pointIndex += _direction * 2;
                    }

                    break;
                }
            }
        }

        public void SetMovingPoints(Transform[] movePoints) => movingPoints = movePoints;
        public void SetSpeed(float value) => speed = value;
    }
}
