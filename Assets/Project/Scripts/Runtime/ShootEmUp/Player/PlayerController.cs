using TaoPulse.Managers;
using UnityEngine;

namespace TaoPulse.ShootEmUp.Player
{
    public sealed class PlayerController : MonoBehaviour
    {
        private static PlayerController _playerController;

        public static PlayerController Instance
        {
            get
            {
                if (!_playerController) _playerController = FindAnyObjectByType<PlayerController>();
                return _playerController;
            }
        }
        
        [SerializeField] private float defaultSpeedMove;
        [SerializeField] private Camera mainCamera;
        
        private Rigidbody2D _rigidbody2D;
        private Vector2 _moveVelocity;
        private float _speedMove;

        public Camera MainCamera => mainCamera;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            if (_speedMove == 0) _speedMove = defaultSpeedMove;
        }

        private void Update()
        {
            Move();
            Look();
        }

        private void FixedUpdate()
        {
            _rigidbody2D.linearVelocity = _moveVelocity * _speedMove;
        }

        private void Move()
        {
            _moveVelocity = InputManager.Instance.MoveAxis;
            _moveVelocity = _moveVelocity.normalized;
        }
        
        private void Look()
        {
            switch (InputManager.Instance.CurrentControls)
            {
                case Controls.KeyboardAndMouse:
                {
                    Vector3 mousePosition = mainCamera.ScreenToWorldPoint(InputManager.Instance.GetMousePosition());
                    Vector2 direction = (mousePosition - transform.position).normalized;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    _rigidbody2D.rotation = angle;
                    break;
                }
                case Controls.Gamepad:
                {
                    Vector2 direction = new Vector2(InputManager.Instance.LookAxis.x, InputManager.Instance.LookAxis.y);
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    _rigidbody2D.rotation = angle;   
                    break;
                }
            }
        }

        public void SetSpeed(float value) => _speedMove = value;
    }
}

