using UnityEngine;
/// <summary>
/// Ase jonka voi poimia.
/// </summary>
public class WeaponPickup : MonoBehaviour
{
    // Asedata, joka v‰litet‰‰n pelaajalle (ScriptableObject)
    public WeaponDataSO weaponToGive;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Tarkistaa ett‰ pelaaja hallinoi aseita
            if (other.TryGetComponent<PlayerWeaponManager>(out var weaponManager))
            {
                // Aseista pelaaja
                weaponManager.EquipWeapon(weaponToGive);
                // Poista ase
                Destroy(gameObject);
            }
        }
    }
}
