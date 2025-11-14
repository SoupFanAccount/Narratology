using UnityEngine;

public class ThirdPersonCameraMover : MonoBehaviour
{
    public GameObject Player;
    public Vector3 camOffset;

    void Start()
    {
        
    }

    void Update()
    {
        //Follow player with offset
        transform.position = Player.transform.position + camOffset;
    }
}
