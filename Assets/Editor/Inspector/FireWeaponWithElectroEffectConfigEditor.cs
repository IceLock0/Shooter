using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Configs.Weapon
{
    [CustomEditor(typeof(FireWeaponWithElectroEffectConfig))]
    public class FireWeaponWithElectroEffectConfigEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            FireWeaponWithElectroEffectConfig config = (FireWeaponWithElectroEffectConfig) target;

            float totalDamage = config.Duration / config.DamageInterval * config.DamagePerInterval;
            EditorGUILayout.LabelField("Total Damage", totalDamage.ToString());
        }
    }
}