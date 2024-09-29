using UnityEngine;

namespace Movement
{
    public class EnemyMovementController : MovementController
    {
        protected override Vector2 GetDirection()
        {
            return Vector2.left;
        }
    }
}   