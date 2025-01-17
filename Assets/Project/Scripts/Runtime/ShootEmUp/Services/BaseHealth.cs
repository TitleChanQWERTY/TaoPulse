using System;
using TaoPulse.Services;
using UnityEngine;

namespace TaoPulse.ShootEmUp.Services
{
    public abstract class BaseHealth : MonoBehaviour
    {
        public event Action OnHealEvent;
        public event Action OnDamageEvent;
        public event Action OnDieEvent;

        private bool _isCanHeal = true;
        private bool _isCanDamage = true;

        private int _maximumHealth;
        private int _currentHealth;
        
        private float _cooldownHeal;
        private float _cooldownDamage;

        private float _cooldownHealDelay;
        private float _cooldownDamageDelay;

        public int CurrentHealth => _currentHealth;
        public int MaximumHealth => _maximumHealth;

        public bool Heal(int value)
        {
            if (!_isCanHeal) return false;
            if (!Timer.SimpleTimer(_cooldownHealDelay, _cooldownHeal)) return false;
            _cooldownHealDelay = Time.time;
            _currentHealth += value;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maximumHealth);
            OnHealEvent?.Invoke();
            if (_currentHealth <= 0 || _currentHealth >= _maximumHealth) _isCanHeal = false;
            return true;
        }

        public bool Damage(int value)
        {
            if (!_isCanDamage) return false;
            if (!Timer.SimpleTimer(_cooldownDamageDelay, _cooldownDamage)) return false;
            _cooldownDamageDelay = Time.time;
            _currentHealth -= value;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maximumHealth);
            OnDamageEvent?.Invoke();
            if (_currentHealth > 0) return true;
            OnDieEvent?.Invoke();
            _isCanDamage = false;
            return true;
        }

        public void SetMaximumHealth(int value)
        {
            _maximumHealth = value;
            _currentHealth = value;
        }

        public void SetHealCooldown(float value) => _cooldownHeal = value;
        public void SetDamageCooldown(float value) => _cooldownDamage = value;
    }
}