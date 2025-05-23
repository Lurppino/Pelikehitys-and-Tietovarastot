using UnityEngine;

/// <summary>
/// Ase
/// </summary>
public class Weapon : MonoBehaviour
{
    // Asedata (ScriptableObject)
    public WeaponDataSO weaponData;

    public void Attack()
    {
        Debug.Log("Ase: " + weaponData.weaponName + ", Vahinko: " + weaponData.damage);
    }
}
