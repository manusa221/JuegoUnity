using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    protected float velocidadGiro;
    // Start is called before the first frame update
    void Start()
    {
        velocidadGiro = Random.Range(-4.0f, 4.0f);//nos devuelve un valor entre -4 y 4. Con esto conseguimos que no siempre gire hacia un lado.
    }

    // Update is called once per frame
    void Update()
    {
        //El elemento que tenga asignado este script rotara en el eje z
        //para hacer referencia al objeto del cual este script es el componente hay que poner this
        //multiplicamos la velocidaddegiro * time.deltaTime que lo dividara por el nº de frames por segundo.
        this.gameObject.transform.Rotate(0.0f, 0.0f, velocidadGiro * Time.deltaTime);
    }
}
