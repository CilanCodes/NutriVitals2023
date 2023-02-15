using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

    public int smoothCameraSpeed;
    public static float tailPosition = 0f;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Debug.Log(tailPosition);
        Debug.Log("Offset: " + offset.x);
        Debug.Log("Tail: " + tailPosition);
        Vector3 newPosition =
            new Vector3(target.position.x + offset.x, transform.position.y, offset.z + target.position.z + tailPosition);

        transform.position = Vector3.Lerp(transform.position, newPosition, smoothCameraSpeed * Time.deltaTime);
    }

    /*public Transform player; // reference to the player character
    public float cameraDistance = 10f; // distance between camera and player
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + cameraDistance, player.position.z - cameraDistance);
    }*/
}
