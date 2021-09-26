using UnityEngine;

// class to control main camera
public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform playerDango;

    private void FixedUpdate()
    {
        CameraFollowPlayerDango();
    }

    private void CameraFollowPlayerDango()
    {
        transform.position = new Vector3(playerDango.position.x, playerDango.position.y,  transform.position.z);
    }
    
}
