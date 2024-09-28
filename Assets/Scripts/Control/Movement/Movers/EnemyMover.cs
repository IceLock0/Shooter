using Configs.Character;
using Zenject;

namespace Movement
{
    public class EnemyMover : Mover
    {
        [Inject]
        public void Initialize(EnemyConfig enemyConfig)
        {
            CharacterConfig = enemyConfig;
        }
    }
}