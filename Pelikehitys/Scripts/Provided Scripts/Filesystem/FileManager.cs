using System;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

// Sisältää kaikki luokat ja metodit tiedostosysteemin käsittelyyn
public class FilesystemManager : MonoBehaviour
{
    private string dataPath;
    private string textFile;
    private string state;

    private void Awake()
    {
        // Pysyvä kansio
        dataPath = Application.persistentDataPath + "/Player_Data/";
        // Liikkuva kansio vaihtoehtoisesti:
        // dataPath = Application.dataPath + "/Player_Data/";

        // Tiedoston nimi
        textFile = dataPath + "/Save_Data.txt";
    }

    private void Start()
    {
        Initialize();
    }

    // Alustustoimenpiteet kun peli alkaa
    public void Initialize()
    {
        // Voit lisätä alustuskoodia tänne
    }

    public void FilesystemInfo()
    {
        // Voit lisätä tiedostojärjestelmän tietojen näyttämisen tänne
    }

    // Luo uuden hakemiston, jos sitä ei vielä ole
    public void NewDirectory()
    {
        if (Directory.Exists(dataPath))
        {
            Debug.Log($"{dataPath} hakemisto on jo olemassa!");
            return;
        }

        Directory.CreateDirectory(dataPath);
        Debug.Log("Uusi hakemisto on luotu");
    }

    // Poistaa hakemiston
    public void DeleteDirectory()
    {
        if (!Directory.Exists(dataPath))
        {
            Debug.Log("Hakemistoa ei ole tai se on poistettu");
            return;
        }

        Directory.Delete(dataPath, true); // true = poistaa myös alihakemistot ja tiedostot
        Debug.Log("Hakemisto on poistettu!");
    }

    // Lisää uusi tiedosto, jos sitä ei vielä ole
    public void NewTextFile()
    {
        if (File.Exists(textFile))
        {
            Debug.Log("Tiedosto on jo olemassa!");
            return;
        }

        File.WriteAllText(textFile, "<TALLETETTU DATA>\n\n");
        Debug.Log("Uusi tiedosto luotu");
    }

    // Päivitää tiedoston
    public void UpdateTextFile(string text)
    {
        if (!File.Exists(textFile))
        {
            Debug.Log("Tiedostoa ei löydy...");
            return;
        }

        File.AppendAllText(textFile, text);
        Debug.Log("Tiedosto päivitetty!");
    }

    // Lukee tiedoston
    public string ReadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Debug.Log("Tiedostoa ei löydy...");
            return "";
        }

        return File.ReadAllText(filename);
    }

    // Poistaa tiedoston
    public void DeleteFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Debug.Log("Tiedostoa ei löydy...");
            return;
        }

        File.Delete(filename);
        Debug.Log("Tiedosto poistettu!");
    }
}

