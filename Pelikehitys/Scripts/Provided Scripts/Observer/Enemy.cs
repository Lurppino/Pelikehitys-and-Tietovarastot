using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    private void Update()
    {
        var eKEy = Keyboard.current.eKey.wasPressedThisFrame;

        if (eKEy)
        {
            HealthManager.Instance.TakeDamage(10);
        }
    }

}
