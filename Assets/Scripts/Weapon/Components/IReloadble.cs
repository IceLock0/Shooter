using System.Collections;

namespace Weapon.Components
{
    public interface IReloadble
    {
        public IEnumerator Reload();
    }
}