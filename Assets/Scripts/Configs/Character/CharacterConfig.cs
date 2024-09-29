using UnityEngine;

namespace Configs.Character
{
    [CreateAssetMenu(fileName = "Character config", menuName = "Configs/Character", order = 0)]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private float _hp;
        [SerializeField] private float _linearSpeed;

        public float HP => _hp;
        public float LinearSpeed => _linearSpeed;

        private void OnValidate()
        {
            if (_hp <= 0.0f)
                _hp = 1.0f;
            
            if (_linearSpeed < 0.0f)
                _hp = 0.0f;
        }
    }
}