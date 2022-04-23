using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kalculo : MonoBehaviour
{
    public float peso;
    public float estatura;
    private float resultado;

    // Start is called before the first frame update
    void Start()
    {
        float resultado = peso / (estatura*estatura);
        Debug.Log(resultado);
    }


}
