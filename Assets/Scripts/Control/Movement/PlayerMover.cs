using DefaultNamespace;
using UnityEngine;
using Zenject;

namespace Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMover : MonoBehaviour, IControllable
    {
       private CharacterConfig _playerConfig;
       private CharacterController _characterController;

        [Inject]
        public void Initialize(PlayerConfig playerConfig)
        {
            _playerConfig = playerConfig;
            _characterController = GetComponent<CharacterController>();
        }
        
        public void Control(Vector2 direction)
        {
            TryMove(direction);
        }

        private void TryMove(Vector2 direction)
        {
            Vector3 directionVector3 = -transform.forward * direction.x + transform.right * direction.y;
            
            _characterController.Move(directionVector3 * _playerConfig.LinearSpeed);
        }
    }
}