using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [Header("Movimiento del personaje")]
    public float speedMovement;
    public Vector3 direccion;
    public CharacterController controller;
    public float speedRun;

    [Header("Rotacion de la camara")]
    public Camera playerView;
    public Vector2 cameraView;
    public float cameraSpeed;
    private float playerRotationX, playerRotationY;

    [Header("Salto")]
    public Vector3 gravity;
    public float jumpHeight;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        //Gravedad
        gravity.y -= 9.8f * Time.deltaTime;
        controller.Move(gravity * Time.deltaTime);
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            gravity.y = Mathf.Sqrt(jumpHeight * -2f * -9.8f);
        }
        else if (controller.isGrounded && gravity.y<0)
        {
            gravity.y = -9.8f;
        }
        //Movimiento del presonaje
        direccion.x = Input.GetAxisRaw("Horizontal");
        direccion.z = Input.GetAxisRaw("Vertical");
        controller.Move(transform.TransformDirection(direccion) * Time.deltaTime * speedMovement);
        if (Input.GetButton("Run Botton"))
        {
            controller.Move(transform.TransformDirection(direccion) * Time.deltaTime * speedMovement*speedRun);
        }
        //Movimiento de la camara
        cameraView = new Vector2(Input.GetAxisRaw("Mouse X")*cameraSpeed, Input.GetAxisRaw("Mouse Y")*cameraSpeed);
        playerRotationX -= cameraView.y;
        playerRotationY += cameraView.x;
        playerRotationX = Mathf.Clamp(playerRotationX, -40, 40);
        playerView.transform.localRotation = Quaternion.Euler(playerRotationX, 0,0);
        controller.transform.rotation = Quaternion.Euler(0, playerRotationY, 0);

    }
}