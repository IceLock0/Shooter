using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Player config", menuName = "Configs/Character/Player", order = 0)]
    public class PlayerConfig : CharacterConfig
    {
        [SerializeField] private float _mouseSensitivity;

        public float MouseSensitivity => _mouseSensitivity;
    }
}