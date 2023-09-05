using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//librería para cambiar de escena

public class JugarDeNuevo : MonoBehaviour
{
 

        public void Reiniciar()//creo un metodo para reiniciar el juego
        {
            SceneManager.LoadScene("MiniJuego3");
        }

    public void Volver()
    {
        SceneManager.LoadScene("MiniJuegos");
    }
        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
