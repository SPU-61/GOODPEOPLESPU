using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 rotation;
    private void Start()
    {
        if (!player.GetComponent<PlayerController>().isLocalPlayer)
        {
            transform.GetChild(0).GetComponent<Camera>().enabled = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            Destroy(gameObject);
            return;
        }
        if (!player.GetComponent<PlayerController>().isLocalPlayer)
        {
            return;
        }
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");
        rotation.x -= mouseY;
        rotation.y += mouseX;
        transform.rotation = Quaternion.Euler(rotation);
        transform.position = player.position;
    }

}
