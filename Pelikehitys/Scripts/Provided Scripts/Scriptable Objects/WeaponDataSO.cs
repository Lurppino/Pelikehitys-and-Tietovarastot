using UnityEngine;

public enum WeaponType { Melee, Ranged, Magic }

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapons/Weapon Data")]
public class WeaponDataSO : ScriptableObject
{
    public string weaponName;         // Aseen nimi
    public WeaponType weaponType;     // Aseen tyyppi
    public string specialAbility;     // Erikoisominaisuus
    public int damage;                // Vahingon m��r�
    public float range;               // Hy�kk�ysalue
    public Sprite icon;              // Aseen kuva
}
