using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balon : MonoBehaviour
{
    public GameObject perder;//referenciamos perder
    public GameObject jugarDeNuevo;
    public GameObject volver;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Limite")//si el balon atraviesa el limite
        {
            perder.gameObject.SetActive(true);//activo el objeto perder (texto perder)
            jugarDeNuevo.gameObject.SetActive(true);//lanzo un mensaje de jugar de nuevo
            volver.gameObject.SetActive(true);
        }
    }
}