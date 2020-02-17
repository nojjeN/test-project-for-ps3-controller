using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    Transform cam;
    Vector3 offsetVector;

    // Start is called before the first frame update
    void Start()
    {
        offsetVector = new Vector3(0, 20f, 0);
        cam = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        cam.position = player.position + offsetVector;
    }
}
