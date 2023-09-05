using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{

    
    public GameObject imagenTouch;
    private GameObject[] cloneImagenTouch;
    public GameObject camera;
    private Vector3 posTouch;
    private Ray rayo;//declaramos la clase rayo
   //tenemos que detectar cuando el rayo atraviesa un objeto 2D que tenga un collider2D
    private RaycastHit2D hit;//esta clase es el punto de golpeo donde a atravesado el rayo al objeto
    // Start is called before the first frame update
    void Start()
    {
        cloneImagenTouch = new GameObject[10];
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)//con este condicional evitamos que el código se ejecute continuamente
            //creamos el rayo con todas las posiciones en la pantalla
            rayo = camera.GetComponent<Camera>().ScreenPointToRay(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, camera.transform.position.z));
        hit = Physics2D.GetRayIntersection(rayo, 10000);//me va a devolver el objeto que ha atravesado.
        if (hit.collider != null)
        {
            if (General.GetSegundos() > 0)//con este condicional evitamos que cuando acabe el tiempo, se puedan picar palomitas

            {
                if (hit.collider.gameObject.tag=="Palomita")//si el objeto es igual a palomita  suma un punto
                {
                    //cada vez que destruyamos una palomita aumentaremos en 1 el nº de palomitas destruidas
                    General.SetNumPalomitasDestruidas(General.GetNumPalomitasDestruidas() + 1);
                }
                else
                {
                    General.SetNumPalomitasDestruidas(General.GetNumPalomitasDestruidas() -3);//de lo contrarío resta 3
                }
                this.GetComponent<UIController>().SetNumPalomitas();//accedemos al script UIcontroller, esta en el mismo gameobject
                Destroy(hit.collider.gameObject);//cada vez que pique una palomita la voy a destruir
                Debug.Log(hit.collider.gameObject.tag);//me devuelve por consola el objeto que ha golpeado
            }
        }
        
        for (int i = 0; i < Input.touchCount; i++)
                //definimos cada uno de los estados del touch
                //pruebaText.GetComponent<Text>().text = Input.touchCount.ToString();
                switch (Input.GetTouch(i).phase)
                {
                    case TouchPhase.Began://1er frame del touch cuando pulsamos por 1 vez

                        posTouch = camera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.GetTouch(i).position.x, Input.GetTouch(i).position.y, camera.transform.position.z));
                        posTouch.z = 0.0f;
                        cloneImagenTouch[i] = (GameObject)Instantiate(imagenTouch, posTouch, Quaternion.identity);
                        break;
                    case TouchPhase.Moved://2er frame del touch cuando movemos el dedo
                                          //vamos calculando la posicion constantemente cada vez que se mueve
                        posTouch = camera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.GetTouch(i).position.x, Input.GetTouch(i).position.y, camera.transform.position.z));
                        posTouch.z = 0.0f;
                        if (cloneImagenTouch[i] != null)
                        {
                            cloneImagenTouch[i].transform.position = posTouch;

                        }
                        break;
                    case TouchPhase.Ended://3er frame del touch cuando acabamos de pulsar
                        Destroy(cloneImagenTouch[i].gameObject);//para destruir el objeto cuando dejemos de pulsar
                        break;
                }

        }
    }

