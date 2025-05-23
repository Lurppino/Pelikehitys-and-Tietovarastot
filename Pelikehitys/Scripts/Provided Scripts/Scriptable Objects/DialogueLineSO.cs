using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/Dialogue Line")]
public class DialogueLineSO : ScriptableObject
{
    [TextArea]
    public string[] lines;

    // NPC-hahmon nimi
    public string npcName;
}
