using System;
using UnityEngine;

namespace PlayerWeapon.Weapon.Bullet
{
    public class PlayerShootDirectionProvider : IShootDirectionProvider
    {
        private Camera _camera;
    
        public PlayerShootDirectionProvider()
        {
            _camera = Camera.main;
            if (!_camera)
                throw new NullReferenceException("Main camera not found");
        }

        public Vector3 GetShootDirection()
        {
            Ray ray = _camera.ScreenPointToRay(new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0));
            return ray.direction.normalized;
        }
    }
}