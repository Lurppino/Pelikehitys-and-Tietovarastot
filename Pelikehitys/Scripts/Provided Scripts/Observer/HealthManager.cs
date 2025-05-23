using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance {  get; set; }

    [SerializeField] private float hp = 100;

    public delegate void OnHealthChange();

    public static event OnHealthChange onHealthChange;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        onHealthChange += Death;
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            print("Pelaaja kuoli");

            onHealthChange?.Invoke();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }

}
