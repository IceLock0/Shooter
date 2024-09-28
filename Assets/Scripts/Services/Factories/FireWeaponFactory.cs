using UnityEngine;
using Zenject;

namespace Weapon
{
    public class FireWeaponFactory
    {
        private const string WEAPON_PREFABS_PATH = "Weapon/";
        private const string PISTOL_PATH = WEAPON_PREFABS_PATH + "Pistol";
        private const string RIFLE_PATH = WEAPON_PREFABS_PATH + "Rifle";
        private const string MACHIEGUN_PATH = WEAPON_PREFABS_PATH + "MachineGun";
        private const string ELECTROGUN_PATH = WEAPON_PREFABS_PATH + "ElectroGun";
        
        private Object _pistol;
        private Object _machineGun;
        private Object _electroGun;
        private Object _rifle;

        private DiContainer _container;
        
        public FireWeaponFactory(DiContainer container)
        {
            _container = container;
            Load();
        }
        
        public void Load()
        {
            _pistol = Resources.Load(PISTOL_PATH);
            _rifle = Resources.Load(PISTOL_PATH);
            _machineGun = Resources.Load(MACHIEGUN_PATH);
            _electroGun = Resources.Load(PISTOL_PATH);
            _rareComputer = Resources.Load(RareComputer);
        }
        
        public FireWeapon.FireWeapon CreateWeapon(IShootBehaviour shootBehaviour, FireWeapon.FireWeapon prefab,
            Vector3 at, Quaternion quaternion, Transform parent = null)
        {
            var weapon = Object.Instantiate(prefab, at, quaternion, parent);
            weapon.Initialize(shootBehaviour);
            return weapon;
        }
    }
}