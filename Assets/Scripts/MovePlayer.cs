using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    Vector2 move;
    PlayerControls controls;
    public Transform playerTransform;
    public float speed = 5000;
    // Start is called before the first frame update
    void Awake()
    {
        playerTransform = GetComponent<Transform>();
        controls = new PlayerControls();
        controls.Gameplay.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Movement.canceled += ctex => move = Vector2.zero;

    }

    void Update()
    {
        float xMove = move.x * Time.deltaTime * speed;
        float yMove = move.y * Time.deltaTime * speed;
        float playerRotationY = Mathf.Round(playerTransform.rotation.eulerAngles.y);
        float cosRotation = Mathf.Cos(playerRotationY);
        float sinRotation = Mathf.Sin(playerRotationY);

        //GetComponent<Rigidbody>().AddForce(xMove * cosRotation, 0, xMove * -sinRotation);
        GetComponent<Rigidbody>().AddForce(xMove, 0, yMove);
        Debug.Log("sinrotation: " + sinRotation + "  Cosrotation: " + cosRotation + " rotation: " + playerRotationY);

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
