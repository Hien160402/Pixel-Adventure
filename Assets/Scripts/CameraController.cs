using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(player.position.x+10, player.position.y+3f, transform.position.z);
    }
}
