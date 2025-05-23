using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using static ScoreManager1;

public class PointHUD : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;

    public delegate void onVictory();
    public static event onVictory OnVictory;

    public static PointHUD Instance;

    public TextMeshProUGUI scoreText;

    int score = 0;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        scoreText.text = "SCORE: " + score.ToString();
        OnVictory += Victory;
    }
    private void OnDestroy()
    {
        OnVictory -= Victory;
    }
    public void AddPoint()
    {
        score += 1;
        scoreText.text = "SCORE: " + score.ToString();
        Victory();
    }
    
    public void Victory()
    {
        if (score == 10)
        {
            OnVictory -= Victory;
            winScreen.SetActive(true);
            OnVictory?.Invoke();
        }
    }
}
