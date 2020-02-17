using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotatePlayer : MonoBehaviour
{
    Vector2 rotate;
    PlayerControls controls;
    // Start is called before the first frame update
    void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.RotateCamera.performed += ctx => rotate = ctx.ReadValue<Vector2>();
        controls.Gameplay.RotateCamera.canceled += ctex => rotate = Vector2.zero;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotationAxis = new Vector3(0, 1, 0);
        GetComponent<Transform>().rotation *= Quaternion.AngleAxis(rotate.x, rotationAxis);
        GetComponent<Transform>().rotation *= Quaternion.AngleAxis(rotate.x, rotationAxis);

    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
