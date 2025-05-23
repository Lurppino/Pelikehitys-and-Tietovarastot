using UnityEngine;
using UnityEngine.SceneManagement;
using static HealthManager;
using static PointHUD;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject restartButton;

    private void OnEnable()
    {
        onHealthChange += DisplayRestartButton;
        OnVictory += DisplayRestartButton;
    }

    private void OnDisable()
    {
        onHealthChange -= DisplayRestartButton;
        OnVictory -= DisplayRestartButton;
    }
    private void DisplayRestartButton()
    {
        OnVictory -= DisplayRestartButton;
        restartButton.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
