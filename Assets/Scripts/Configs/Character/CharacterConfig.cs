using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Character config", menuName = "Configs/Character", order = 0)]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private float _hp;
        [SerializeField] private float _linearSpeed;

        public float Hp => _hp;
        public float LinearSpeed => _linearSpeed;
    }
}