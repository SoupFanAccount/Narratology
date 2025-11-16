using UnityEngine;

public class TextBubbleFollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player, cam;
    [SerializeField] Vector3 offset;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = player.transform.position + offset;
        transform.rotation = (Quaternion.Euler(transform.rotation.x, cam.transform.rotation.y, transform.rotation.z));
    }
}
