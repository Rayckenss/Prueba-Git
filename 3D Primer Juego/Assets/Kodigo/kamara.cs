using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamara : MonoBehaviour
{
    //se crea un parametro para poder llamar a un objeto cualquiera que se pueda escoger en el editor
    public GameObject bolita;
    //se crea un vector de 3 dimensiones con el cual voy a separar la camara del objeto que escoja
    public Vector3 offset;

    private void Start()
    {
        //Alejo la posicion de la camara de la posicion de el objeto que escogí
        offset = transform.position - bolita.transform.position;
    }

    private void LateUpdate()
    {
        //fijo la posicion de la camara a la del objeto que escogí
        transform.position = bolita.transform.position + offset;
    }
}
