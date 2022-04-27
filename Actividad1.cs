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
    [Header("Actividad 3")]
    public int tiempo;
    private int horas, minutos;
    [Header ("Actividad 4")]
    public float calificacion1, calificacion2, calificacion3, examenFinal, trabajoFinal;
    private float promedioCalificaciones, notaEstudiante;

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
        //Actividad 3
        horas = tiempo / 60;
        minutos = tiempo % 60;
        Debug.Log(tiempo + " minutos son " + horas + " horas y " + minutos + " minutos");
        //Actividad 4
        promedioCalificaciones = (calificacion1 + calificacion2 + calificacion3) / 3;
        notaEstudiante = (promedioCalificaciones * 0.55f) + (examenFinal * 0.3f) + (trabajoFinal * 0.15f);
        Debug.Log("La nota del estudiante fue " + notaEstudiante);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
