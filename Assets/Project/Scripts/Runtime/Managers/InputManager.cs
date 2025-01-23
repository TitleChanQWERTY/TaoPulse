using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace TaoPulse.Managers
{
    public enum Controls
    {
        Gamepad,
        KeyboardAndMouse
    }
    public sealed class InputManager : MonoBehaviour
    {
        private static InputManager _inputManager;

        public static InputManager Instance => _inputManager;
        
        
        private InputActions _inputActions;

        private bool _cursorShowed;

        private Controls _currentControls = Controls.KeyboardAndMouse;

        public Vector2 MoveAxis => _inputActions.ShootEmUp.Move.ReadValue<Vector2>();
        public Vector2 LookAxis => _inputActions.ShootEmUp.Look.ReadValue<Vector2>();

        public KeyControl[] NumberKeys { get; private set; }

        public Controls CurrentControls => _currentControls;

        public InputActions InputActions => _inputActions;
        
        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }
            _inputActions = new InputActions();
            InitNumberKeys();
            _inputManager = this;
            DontDestroyOnLoad(gameObject);
        }
        
        private void InitNumberKeys()
        {
            if (Keyboard.current == null) return;
            NumberKeys = new[]
            {
                Keyboard.current.digit0Key,
                Keyboard.current.digit1Key,
                Keyboard.current.digit2Key,
                Keyboard.current.digit3Key,
                Keyboard.current.digit4Key,
                Keyboard.current.digit5Key,
                Keyboard.current.digit6Key,
                Keyboard.current.digit7Key,
                Keyboard.current.digit8Key,
                Keyboard.current.digit9Key
            };
        }

        private void Update()
        {
            ControlChanged();
            Cursor.visible = false;
        }
        
        private void OnEnable()
        {
            _inputActions?.Enable();
        }

        private void OnDisable()
        {
            _inputActions?.Disable();
        }

        private void ControlChanged()
        {
            if (Keyboard.current != null)
            {
                if (NumberKeys == null) InitNumberKeys();
                if (Keyboard.current.IsPressed()) _currentControls = Controls.KeyboardAndMouse;
            }
            
            if (Mouse.current != null)
            {
                if (Mouse.current.delta.x.value != 0 || Mouse.current.delta.y.value != 0)
                {
                    _currentControls = Controls.KeyboardAndMouse;
                }
            }
            
            if (Gamepad.current != null)
            {
                if (Gamepad.current.IsActuated())
                {
                    _currentControls = Controls.Gamepad;
                }
            }
        }

        public float GetMouseWheelValue()
        {
            if (CurrentControls != Controls.KeyboardAndMouse) return 0;
            return Mouse.current.scroll.value.y;
        }

        public Vector2 GetMousePosition()
        {
            if (CurrentControls != Controls.KeyboardAndMouse) return Vector2.zero;
            return Mouse.current.position.value;
        }
    }
}
