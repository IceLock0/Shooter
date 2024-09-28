using UnityEngine;

namespace Movement
{
    public interface IControllable
    {
        public void Control(Vector2 direction);
    }
}