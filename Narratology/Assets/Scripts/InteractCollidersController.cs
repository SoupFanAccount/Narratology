using UnityEngine;

public class InteractCollidersController : MonoBehaviour
{
    [SerializeField] WhereAreWe whereAreWe;

    private bool isAtGasPump;
    public GameObject gasPumpCollider, goodGasPumpCollider;

    void Start()
    {

        gasPumpCollider.SetActive(false);
        goodGasPumpCollider.SetActive(false);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isAtGasPump)
            {
                if (goodGasPumpCollider.activeSelf)
                {
                    goodGasPumpCollider.gameObject.SetActive(false);
                }

                if (gasPumpCollider != null)
                {
                    Destroy(gasPumpCollider);
                }

                whereAreWe.CheckGameStateAndDoStuff(1);

                isAtGasPump = false;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CantGas"))
        {
            isAtGasPump = true;
        }
        if (other.CompareTag("PumpGas"))
        {
            isAtGasPump = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("CantGas"))
        {
            isAtGasPump = false;
        }
    }
}
