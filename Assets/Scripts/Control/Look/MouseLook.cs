using Configs.Character;
using UnityEngine;
using Zenject;

namespace Movement.Look
{
    public class MouseLook : MonoBehaviour
    {
        private PlayerConfig _playerConfig;

        private Transform _playerTransform;

        private InputService _inputService;
        
        private float _rotation = 0.0f;

        [Inject]
        public void Initialize(PlayerConfig playerConfig, InputService inputService)
        {
            _playerConfig = playerConfig;
            _inputService = inputService;

            _inputService.Enable();
        }
        
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;

            _playerTransform = transform.parent;
        }

        private void Update()
        {
            Look();
        }

        private void Look()
        {
            var directionLook = ReadLookVector() * _playerConfig.MouseSensitivity * Time.deltaTime;
            
            _rotation -= directionLook.y;

            _rotation = Mathf.Clamp(_rotation, -90, 90);
            
            transform.localRotation = Quaternion.Euler(_rotation, transform.localEulerAngles.y, 0);

            _playerTransform.Rotate(Vector3.up * directionLook.x);
        }

        private Vector2 ReadLookVector() => _inputService.Gameplay.Look.ReadValue<Vector2>();

        private void OnDisable()
        {
            _inputService.Disable();
        }
    }
}