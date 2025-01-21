using TaoPulse.ShootEmUp.Services;
using TaoPulse.ShootEmUp.Services.Triggers;

namespace TaoPulse.ShootEmUp.Player
{
    public sealed class PlayerBullet : BaseBullet
    {
        private DamageTrigger _damageTrigger;
        protected override void Init()
        {
            SetMoveDirection(PlayerController.Instance.transform.right);
            transform.rotation = PlayerController.Instance.transform.rotation;

            _damageTrigger = GetComponent<DamageTrigger>();
        }

        private void Damage()
        {
            Destroy(gameObject);
        }
        
        private void OnEnable()
        {
            _damageTrigger.OnTriggerEnterEvent += Damage;
        }
        
        private void OnDisable()
        {
            _damageTrigger.OnTriggerEnterEvent -= Damage;
        }
    }
}