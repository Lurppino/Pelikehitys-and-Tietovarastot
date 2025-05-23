using UnityEngine;
using static HealthManager;

public class GameOverDisplay : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        onHealthChange += DisplayGameOver;
    }
    private void OnDestroy()
    {
        onHealthChange -= DisplayGameOver;
    }
    private void DisplayGameOver()
    {
        gameOverPanel.SetActive(true);
    }

}
