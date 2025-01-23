using UnityEngine;

namespace TaoPulse.Services
{
    [CreateAssetMenu(fileName = "ThemeSo", menuName = "Scriptable Objects/ThemeSo")]
    public sealed class ThemeSo : ScriptableObject
    {
        [Header("Cursors")]
        [SerializeField] private Sprite defaultCursor;
        [SerializeField] private Sprite shootEmUpCursor;

        public Sprite ShootEmUpCursor => shootEmUpCursor;
        public Sprite DefaultCursor => defaultCursor;
    }
}
