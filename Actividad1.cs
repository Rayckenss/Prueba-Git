using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actividad1 : MonoBehaviour
{
    [Header ("Actividad 1")]
    public  float altura, baseRectangulo;
    private float perimetro, area;
    [Header("Actividad 2")]
    public float cateto1, cateto2;
    private float hipotenusa;

    // Start is called before the first frame update
    void Start()
    {
        //Actividad 1
        perimetro = (2 * altura) + (2 * baseRectangulo);
        area = baseRectangulo * altura;
        Debug.Log("el perimetro es "+perimetro);
        Debug.Log("el area es "+area);
        //Actividad 2
        hipotenusa = Mathf.Sqrt((cateto1 * cateto1) + (cateto2 * cateto2));
        Debug.Log("la hipotenusa es "+hipotenusa);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
