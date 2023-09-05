using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//librería para cambiar de scena

public class CreadorDeAsteroides : MonoBehaviour
{
    //vamos a referenciar todos los spawn, vamos a crear un array
    public GameObject[] spawns;
    public GameObject asteroide;
    protected GameObject asteroideClon;
    // Start is called before the first frame update
    void Start()
    {
        //para llamar el metodo y que se repita varias veces, 3 parametros: 1 metodo, 2 tiempo que tengo que esperarr desde que mpieza el juego, 3 tiempo de espera de creacion de asteroides
        InvokeRepeating("Crear", 0.0f, 2.0f);
    }
    public void Crear()//metodo para crear un asteroide
    {
       //con la clase instantiate, tiene 3 parametros, 1. que vamos a crear, 2 donde, 3 en que posicion
       //para que salgan los asteroides aleatoriamente seria con el random.range( entre 0 y spawns.lenght. nº aleatorio entre pos 0 y el numero de spaws que hay
        asteroideClon = Instantiate(asteroide, spawns[Random.Range(0,spawns.Length)].transform.position, Quaternion.identity);
        Destroy(asteroideClon, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene("MiniJuego2");
    }

    public void Volver()
    {
        SceneManager.LoadScene("MiniJuegos");
    }
}
