using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public Vector3 eulerRotation;
    public float damper;
    private void Start()
    {
        transform.eulerAngles = eulerRotation;
    }

    private void LateUpdate()
    {
        if (player == null)
            return;

        transform.position = player.position + offset;
    }
}
