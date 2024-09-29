namespace Weapon.View
{
    public class WeaponView
    {
        private FireWeapon.FireWeapon _lastWeapon;
        
        public void ChangeWeaponVisible(FireWeapon.FireWeapon weaponType)
        {
            if(_lastWeapon)
                _lastWeapon.gameObject.SetActive(false);
            
            weaponType.gameObject.SetActive(true);
            
            _lastWeapon = weaponType;
        } 
    }
}