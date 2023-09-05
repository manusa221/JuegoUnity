using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tierr : MonoBehaviour
{
    public GameObject explosion;//referenciamos la explosion
    protected GameObject explosionClon;//hago clon

    public GameObject canvas;//referenciamos el canvas
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

            //si he perdido tenemos que mirar si los puntos son menores de los que hemos conseguido 
            if (PlayerPrefs.HasKey("ASTEROIDESDESTRUIDOS"))//si he jugado almenos una vez
            {
                //linea que da el valor actual                   //puntos que acabo de conseguir
                if (PlayerPrefs.GetInt("ASTEROIDESDESTRUIDOS") < GeneralNave.puntos)
                {
                    PlayerPrefs.SetInt("ASTEROIDESDESTRUIDOS", GeneralNave.puntos);//machacamos el valor que tiene.
                }
            }
            else//no hemos jugado nunca
            {
                //estamos creando una linea con una clave y le voy asignar un valor, que será el del script generalnuevo puntos
                PlayerPrefs.SetInt("ASTEROIDESDESTRUIDOS", GeneralNave.puntos);
            }
        
           
            //cuando choque un asteroide lo activamos.
            canvas.gameObject.SetActive(true);
        Time.timeScale = 0.0f;//para el tiempo de juego
            //tenemos que instanciar en tiempo de ejecucion, que salga una explosion, el metodo es Instantiate(),tiene tres parametros. 1º el objeto que vas a clonar.2º donde lo vas a clonar (lo vamos a clonar en la posicion del asteroide)
            //3º Quaternion.identity8posicion la que tiene, no va a girar nada)
            explosionClon = Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
            Destroy(explosionClon, 5.0f);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
