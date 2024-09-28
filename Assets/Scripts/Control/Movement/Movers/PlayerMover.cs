using Configs.Character;
using Zenject;

namespace Movement
{
    public class PlayerMover : Mover
    {
        [Inject]
        public void Initialize(PlayerConfig playerConfig)
        {
            CharacterConfig = playerConfig;
        }
    }
}