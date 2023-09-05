using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject explosion;//referenciamos la explosion
    protected GameObject explosionClon;//hago clon
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
        if (other.gameObject.tag == "Asteroide")
        {
            //cada vez que un laser choca con un asteroide
            GeneralNave.puntos = GeneralNave.puntos + 1;//actualizara el valor de generaNaves puntos
            //tenemos que instanciar en tiempo de ejecucion, que salga una explosion, el metodo es Instantiate(),tiene tres parametros. 1º el objeto que vas a clonar.2º donde lo vas a clonar (lo vamos a clonar en la posicion del asteroide)
            //3º Quaternion.identity8posicion la que tiene, no va a girar nada)
            explosionClon = Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
            Destroy(explosionClon, 5.0f);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}