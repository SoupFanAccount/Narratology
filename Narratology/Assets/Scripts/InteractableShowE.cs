using UnityEngine;

public class InteractableShowE : MonoBehaviour
{
    public GameObject actionIndicator;
    public bool isInteractable = true;

    void Start()
    {
        actionIndicator.SetActive(false);
    }

    public void TurnOffandMakeInteractable()
    {
        actionIndicator.SetActive(false);
        isInteractable = true;
    }

    // This shows the indicator
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isInteractable == true)
        {
            actionIndicator.SetActive(true);
        }
    }

    // This hides the indicator
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            actionIndicator.SetActive(false);
        }
    }

}
