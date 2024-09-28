using UnityEngine;

namespace Configs.Character
{
    [CreateAssetMenu(fileName = "Enemy config", menuName = "Configs/Character/Enemy", order = 0)]
    public class EnemyConfig : CharacterConfig
    {
        [SerializeField] private float _angularSpeed;
        
        [SerializeField] private float _attackRate;
        
        public float AngularSpeed => _angularSpeed;
        public float AttackRate => _attackRate;
        
        private void OnValidate()
        {
            if (_angularSpeed < 0.0f)
                _angularSpeed = 0.0f;
            
            if (_attackRate < 0.0f)
                _attackRate = 0.0f;
        }
    }
}