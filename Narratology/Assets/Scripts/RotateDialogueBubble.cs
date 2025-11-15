using UnityEngine;

public class RotateDialogueBubble : MonoBehaviour
{
    public GameObject dialogueBubble;
    public GameObject mainCamera;


    // Update is called once per frame
    void Update()
    {
        dialogueBubble.transform.rotation = mainCamera.transform.rotation;
    }
}
