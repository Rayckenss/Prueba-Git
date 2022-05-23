using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    private Rigidbody rb;
    public float velocidad;
    public GameObject uI;
    private Vector3 initialPosition;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState=CursorLockMode.Locked;
        initialPosition = transform.position;
    }
    public void MovimientoBolita()
    {

        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoH, 0.9f, movimientoV);
        rb.AddForce(movimiento * velocidad * Time.deltaTime);

    }
    private void FixedUpdate()
    {
        MovimientoBolita();
        if (Vector3.Distance(initialPosition,transform.position)>1)
        {
            uI.SetActive(false);
        }
       

    }
}
