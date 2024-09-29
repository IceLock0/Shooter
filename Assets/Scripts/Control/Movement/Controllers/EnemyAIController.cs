using Configs.Character;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Movement
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyAIController : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        private NavMeshAgent _agent;

        [Inject]
        public void Initialize(EnemyConfig enemyConfig)
        {
            _agent = GetComponent<NavMeshAgent>();
            
            _agent.speed = enemyConfig.LinearSpeed;
            _agent.angularSpeed = enemyConfig.AngularSpeed;
            _agent.acceleration = enemyConfig.Acceleration;

            var averageStoppingDistance = enemyConfig.AverageStoppingDistance;

            var minStoppingDistance = averageStoppingDistance - averageStoppingDistance * 0.25f;
            var maxStoppingDistance = averageStoppingDistance + averageStoppingDistance * 0.25f;

            var stoppingDistance = Random.Range(minStoppingDistance, maxStoppingDistance);

            _agent.stoppingDistance = stoppingDistance;
        }

        private void Update()
        {
            Move();
            
            if (_agent.remainingDistance <= _agent.stoppingDistance && !_agent.pathPending)
                RotateTowardsPlayer();
        }

        private void Move()
        {
            if(_playerTransform)
                _agent.SetDestination(_playerTransform.position);
        }

        private void RotateTowardsPlayer()
        {
            Vector3 direction = (_playerTransform.position - transform.position).normalized;
            direction.y = 0; 

            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _agent.angularSpeed * 0.02f);
            }
        }
    }
}
