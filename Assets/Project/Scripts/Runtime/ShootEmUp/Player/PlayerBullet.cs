using UnityEngine;
using TaoPulse.ShootEmUp.Services;

namespace TaoPulse.ShootEmUp.Player
{
    public sealed class PlayerBullet : BaseBullet
    {
        [SerializeField] private float bulletSpeed;
        
        private void Start()
        {
            SetSpeed(bulletSpeed);
            SetMoveDirection(PlayerController.Instance.transform.right);
        }
    }
}