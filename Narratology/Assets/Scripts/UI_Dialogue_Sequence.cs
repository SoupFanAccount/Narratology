using UnityEngine;
using static UI_Dialogue_Test;

[CreateAssetMenu(fileName = "DialogueSequence", menuName = "Dialogue/Sequence")]
public class UI_Dialogue_Sequence : ScriptableObject
{
    public DialogueLine[] lines;
}
