using UnityEngine;

namespace Configs.Weapon
{
    [CreateAssetMenu(fileName = "ElectroEffect config", menuName = "Configs/Weapon/ElectroEffect", order = 0)]
    public class FireWeaponWithElectroEffectConfig : FireWeaponConfig
    {
        [Header("Effect")]
        [SerializeField] private float _damagePerInterval;
        [SerializeField] private float _duration;
        [SerializeField] private float _damageInterval;

        public float DamagePerInterval => _damagePerInterval;
        public float Duration => _duration;
        public float DamageInterval => _damageInterval;
        
        private void OnValidate()
        {
            if (_damagePerInterval <= 0)
                _damagePerInterval = .1f;

            if (_duration <= 0)
                _duration = .1f;

            if (_damageInterval > _duration || _damageInterval <= 0)
                _damageInterval = _duration;
        }
    }
}