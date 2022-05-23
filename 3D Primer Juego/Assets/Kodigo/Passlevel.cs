using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passlevel : MonoBehaviour
{
    public GameObject bolita;
    public Endlevel pn;

    private void OnTriggerEnter(Collider other)
    {

        pn.CambiarNivel(pn.indiceNivel);
    }

}
