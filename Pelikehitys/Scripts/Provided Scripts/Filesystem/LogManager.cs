using System;
using System.IO;
using TMPro;
using UnityEngine;

public class LogManager : MonoBehaviour
{
    public static LogManager Instance { get; private set; }

    private string logFilePath;
    private string textFileName;

    [SerializeField] private TMP_Text logText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Optional: persist across scenes
    }

    private void Start()
    {
        // Pysyvä tallennuspaikka
        logFilePath = Application.persistentDataPath + "/game_data/";
        textFileName = logFilePath + "game_log.txt";

        NewFolder();
        NewTextFile();

        LogEvent($"\nPeli alkaa: {DateTime.Now}");
        UpdateLogUI();
    }

    public void LogEvent(string text)
    {
        if (!File.Exists(textFileName))
        {
            Debug.Log("Tiedostoa ei löydy!");
            return;
        }

        File.AppendAllText(textFileName, $"{text}\n");
        Debug.Log($"Tiedosto päivitetty: {text}");
        UpdateLogUI();
    }

    private void OnDisable()
    {
        var endGameText = $"Peli päättyi: {DateTime.Now}\n----------------\n";
        if (File.Exists(textFileName))
        {
            File.AppendAllText(textFileName, endGameText);
        }
    }

    private void UpdateLogUI()
    {
        if (logText != null && File.Exists(textFileName))
        {
            logText.text = File.ReadAllText(textFileName);
        }
    }

    private void NewFolder()
    {
        if (Directory.Exists(logFilePath))
        {
            Debug.Log($"{logFilePath} hakemisto on jo olemassa!");
            return;
        }

        Directory.CreateDirectory(logFilePath);
        Debug.Log("Uusi hakemisto on luotu");
    }

    private void NewTextFile()
    {
        if (File.Exists(textFileName))
        {
            Debug.Log("Tiedosto on jo olemassa!");
            return;
        }

        File.WriteAllText(textFileName, "<TALLETETTU DATA - Soveltava harjoitus>\n\n");
        Debug.Log("Uusi tiedosto luotu");
    }

    public void DeleteFolder()
    {
        if (Directory.Exists(logFilePath))
        {
            Directory.Delete(logFilePath, true);
            Debug.Log("Kansio poistettu!");
        }
        else
        {
            Debug.Log("Kansiota ei ole tai se on jo poistettu.");
        }
    }

    public void DeleteFile()
    {
        if (!File.Exists(textFileName))
        {
            Debug.Log("Tiedostoa ei löydy...");
            return;
        }

        File.Delete(textFileName);
        Debug.Log("Tiedosto poistettu!");
        UpdateLogUI();
    }
}
