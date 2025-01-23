using TaoPulse.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace TaoPulse.Services
{
    public enum CursorType
    {
        Default,
        ShootEmUp
    }
    public sealed class CursorSystem : MonoBehaviour
    {
        private static CursorSystem _cursorSystem;

        public static CursorSystem Instance => _cursorSystem;
        
        [SerializeField] private ThemeSo themeSoReference;
        [SerializeField] private Image imageReference;

        [SerializeField] private CursorType cursorTypeByDefault = CursorType.ShootEmUp;

        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }
            SetCursor(cursorTypeByDefault);
            _cursorSystem = this;
        }

        private void Update()
        {
            imageReference.transform.position = InputManager.Instance.GetMousePosition();
        }

        private void SetCursor(CursorType cursorType)
        {
            switch (cursorType)
            {
                case CursorType.ShootEmUp:
                    imageReference.sprite = themeSoReference.ShootEmUpCursor;
                    break;
            }
        }
    }
}

