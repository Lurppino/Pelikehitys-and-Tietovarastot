using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    public string areaName;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log($"Alueen nimi: {areaName}");
            GameEvents.Instance.EnterArea(areaName);
        }
    }
}
