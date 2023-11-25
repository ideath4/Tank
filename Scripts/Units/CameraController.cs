using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] PlayerController player;
    Transform cameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = player.CameraPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cameraPosition != null)
        {
            transform.position = Vector3.Lerp(transform.position, cameraPosition.position, 0.1f);
            transform.LookAt(player.transform.position);
        }
    }
}
