using System;
using UnityEngine;

namespace Characters.Components
{
    public class CharacterHP
    {
        private float _currentHP;
        
        public CharacterHP(float maxHP)
        {
            _currentHP = maxHP;
        }

        public event Action OnDeath;

        public void TakeDamage(float amount)
        {
            if (amount < 0)
                throw new ArgumentException("Damage must be >= 0");
            
            _currentHP -= amount;

            if (_currentHP <= 0)
                Die();
            
            Debug.Log($"CurrentHP = {_currentHP}");
        }

        private void Die() => OnDeath?.Invoke();
    }
}