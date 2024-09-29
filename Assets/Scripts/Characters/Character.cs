using Characters.Components;
using Configs.Character;
using UnityEngine;

namespace Characters
{
    public class Character : MonoBehaviour, IDamageable
    {
        [SerializeField] private CharacterConfig _characterConfig;
        
        private CharacterHP _hp;

        public void TakeDamage(float amount)
        {
            _hp.TakeDamage(amount);
        }

        public bool IsAlive() => gameObject.activeSelf;

        private void Awake()
        {
            _hp = new CharacterHP(_characterConfig.HP);
        }

        private void OnEnable()
        {
            _hp.OnDeath += Die;
        }

        private void OnDisable()
        {
            _hp.OnDeath -= Die;
        }

        private void Die()
        {
            Debug.Log("R.I.P.");
            gameObject.SetActive(false);
        }
    }
}