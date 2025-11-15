using UnityEngine;

public class ThirdPersonCameraMover : MonoBehaviour
{
    public GameObject Player;
    public Vector3 camOffset;

    public float xClampMin, xClampMax, zClampMin, zClampMax;
    private float xClamped, yClamped;

    void Start()
    {
        
    }

    void Update()
    {
        //Follow player with offset
        transform.position = new Vector3(Mathf.Clamp(Player.transform.position.x + camOffset.x, xClampMin, xClampMax), Player.transform.position.y + camOffset.y, Mathf.Clamp(Player.transform.position.z + camOffset.z, zClampMin, zClampMax));

        //Mathf.Clamp(transform.position.x, xClampMin, xClampMax);
        //Mathf.Clamp(transform.position.z, zClampMin, zClampMax);
    }
}
