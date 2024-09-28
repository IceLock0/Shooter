using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Enemy config", menuName = "Configs/Character/Enemy", order = 0)]
    public class EnemyConfig : CharacterConfig
    {
        [SerializeField] private float _angularSpeed;
        
        public float AngularSpeed => _angularSpeed;
    }
}