using TaoPulse.ShootEmUp.Player;
using UnityEngine;

namespace TaoPulse.ShootEmUp.Services.Triggers
{
    public enum DamageType
    {
        Player,
        Enemy
    }

    public enum TriggerType
    {
        Enter,
        Stay,
        Exit
    }
    
    public sealed class DamageTrigger : MonoBehaviour
    {
        [SerializeField] private DamageType damageType = DamageType.Enemy;
        [SerializeField] private TriggerType triggerType = TriggerType.Enter;
        [SerializeField] private int damageValue;

        private void Damage(Collider2D other)
        {
            if (damageType == DamageType.Player)
            {
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                if (playerHealth) playerHealth.Damage(damageValue);
            }
            else if (damageType == DamageType.Enemy) return;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (triggerType != TriggerType.Enter) return;
            Damage(other);
        }
        
        private void OnTriggerStay2D(Collider2D other)
        {
            if (triggerType != TriggerType.Stay) return;
            Damage(other);
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (triggerType != TriggerType.Exit) return;
            Damage(other);
        }
    }
}