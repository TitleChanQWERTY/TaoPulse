using System;
using TaoPulse.ShootEmUp.Enemy;
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

        public event Action OnTriggerEnterEvent;
        public event Action OnTriggerStayEvent;
        public event Action OnTriggerExitEvent;

        private bool Damage(Collider2D other)
        {
            if (damageType == DamageType.Player)
            {
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                if (playerHealth)
                {
                    playerHealth.Damage(damageValue);
                    return true;
                }
            }
            else if (damageType == DamageType.Enemy)
            {
                EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
                if (enemyHealth)
                {
                    enemyHealth.Damage(damageValue);
                    return true;
                }
            }

            return false;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (triggerType != TriggerType.Enter) return;
            if (Damage(other)) OnTriggerEnterEvent?.Invoke();
        }
        
        private void OnTriggerStay2D(Collider2D other)
        {
            if (triggerType != TriggerType.Stay) return;
            if (Damage(other)) OnTriggerStayEvent?.Invoke();
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (triggerType != TriggerType.Exit) return;
            if (Damage(other)) OnTriggerExitEvent?.Invoke();
        }
    }
}