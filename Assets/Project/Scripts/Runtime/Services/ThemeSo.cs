using UnityEngine;

namespace TaoPulse.Services
{
    [CreateAssetMenu(fileName = "ThemeSo", menuName = "Scriptable Objects/ThemeSo")]
    public sealed class ThemeSo : ScriptableObject
    {
        [Header("Cursors")]
        [SerializeField] private Texture2D defaultCursor;
        [SerializeField] private Texture2D shootEmUpCursor;

        public Texture2D ShootEmUpCursor => shootEmUpCursor;
        public Texture2D DefaultCursor => defaultCursor;
    }
}
