using UnityEngine;

namespace Configs.Character
{
    [CreateAssetMenu(fileName = "Enemy config", menuName = "Configs/Character/Enemy", order = 0)]
    public class EnemyConfig : CharacterConfig
    {
        [SerializeField] private float _angularSpeed;
        [Range(2, 7)]
        [SerializeField] private float _averageStoppingDistance;
        [SerializeField] private float _attackRate;
        [SerializeField] private float _acceleration;
        
        public float AngularSpeed => _angularSpeed;
        public float AverageStoppingDistance => _averageStoppingDistance;
        public float AttackRate => _attackRate;
        public float Acceleration => _acceleration;
        
        private void OnValidate()
        {
            if (_angularSpeed < 0.0f)
                _angularSpeed = 0.1f;
            
            if (_attackRate < 0.0f)
                _attackRate = 0.0f;

            if (_acceleration < 0.0f)
                _acceleration = 0.1f;
        }
    }
}