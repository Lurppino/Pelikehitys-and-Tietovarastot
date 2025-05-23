using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance { get; private set; }


    private void Awake()
    {
        // Ensure only one instance exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Optional: keeps the instance across scenes
    }

    public void CollectItem(string itemName)
    {
        Debug.Log($"Esine kerätty: {itemName}");
        LogManager.Instance.LogEvent(itemName);
    }

    public void OpenDoor(string doorName)
    {
        Debug.Log($"Ovi {doorName} avattu!");
        LogManager.Instance.LogEvent($"{doorName} avattu!");
    }

    public void EnterArea(string areaName)
    {
        Debug.Log($"Alue: {areaName}");
        LogManager.Instance.LogEvent($"Tultiin alueelle {areaName}");
    }
}
