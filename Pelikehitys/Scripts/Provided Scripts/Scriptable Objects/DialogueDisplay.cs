using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueDisplay : MonoBehaviour
{
    // Dialogin tekstit
    public DialogueLineSO dialogue;

    // Tekstilaatikko
    public TMP_Text dialogueText;

    // Kirjoitusnopeus
    public float typingSpeed = 0.05f;

    // Nykyinen tekstirivi
    private int currentLine;

    // Dialogipaneli
    public GameObject dialogPanel;

    // Nimilaatikko
    public TMP_Text npcNameText;

    // Onko dialogi aloitettu
    private bool isDialogStart;

    private void Start()
    {
        //StartDialogue(); // Aloitusdialogia ei heti
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isDialogStart)
        {
            // Nostetaan lippu merkiksi ett‰ dialogi on alkanut
            isDialogStart = true;

            // N‰ytet‰‰n dialogi
            dialogPanel.SetActive(true);

            // Aloitetaan dialogi
            StartDialogue();
        }
    }

    public void StartDialogue()
    {
        Cursor.lockState = CursorLockMode.None;
        currentLine = 0;

        // N‰ytet‰‰n nimi
        npcNameText.text = dialogue.npcName;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        dialogueText.text = "";

        // Kirjoittaa tekstirivi kirjain kerrallaan
        foreach (char c in dialogue.lines[currentLine])
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        currentLine++;
    }

    /// <summary>
    /// Seuraava dialogirivi
    /// </summary>
    public void NextLine()
    {
        // Tutkitaan ollaanko vika rivi ohitettu
        if (dialogue.lines.Length > currentLine)
        {
            StartCoroutine(TypeLine());
        }
        else
        {
            // Piilotetaan paneli
            dialogPanel.SetActive(false);

            // Lukitaan kursori
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
