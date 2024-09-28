using System;
using Configs.Character;
using UnityEngine;
using Zenject;

namespace Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class Mover : MonoBehaviour, IControllable
    {
        protected CharacterConfig CharacterConfig;
        
        private CharacterController _characterController;
       
        public void Control(Vector2 direction)
        {
            TryMove(direction);
        }
        
        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void TryMove(Vector2 direction)
        {
            Vector3 directionVector3 = -transform.forward * direction.x + transform.right * direction.y;
            
            _characterController.Move(directionVector3 * CharacterConfig.LinearSpeed);
        }
    }
}