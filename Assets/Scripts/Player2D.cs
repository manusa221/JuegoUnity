using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//para utilizar un elemento de la UI tenemos que utilizar una librería

public class Player2D : MonoBehaviour
{
    protected int numToques = 0;//creamos una variable para saber el num de toques
    public GameObject puntuacion;//referenciamos el gameobject puntuacion en public para que se pueda relacionar con el objeto en unity, relacionaremos 
    //puntuacion con el objeto player2d, arrastrando puntuacion a player
    protected float velocidad = 5.0f;//variable velocidad
    protected float h = 0.0f;//desplazamiento final de la barra, será el desplazamiento horizontal
    protected float v = 0.0f;

    protected bool bloquearDerecha = false;
    protected bool bloquearIzquierda = false;
    public VariableJoystick vj;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //la clase input sirve para la interaccion del usuario y siempre la utilizaremos en el metodo update. la clase input es de entrada/salida, el getaxis
        //me va a dar un valor opositivo depende de la tecla que pique. Flecha izq -, flecha derch +. o movimieto tactil, joystick etc..
        //Input.GetAxis("Horizontal") lo multiplicamos * Time.deltaTime significa que divida el nº de frames que este dispositivo de ejecutar. ira la barra más lenta.
       // h = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;//lo multiplicamos por la velocidad para que la barra se mueva más rápido
        h = vj.Horizontal * Time.deltaTime * velocidad;

        if (h > 0)//me voy a la derecha
        {
            if (!bloquearDerecha)//si no esta bloqueado a la derecha
            {
                //this hace referencia a la barra, que con la clase transform, es el desplazamiento y translate, desplazamiento en x,y,z(la barra se movera de derch a izq)     
                this.gameObject.transform.Translate(h, 0.0f, 0.0f);//se desplazará
            }
        }
        else if (h < 0)//me voy a la izquierda
        {
            if (!bloquearIzquierda)
            {
                this.gameObject.transform.Translate(h, 0.0f, 0.0f);
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D other)//creamos este metodo para saber si hay algun objeto que colisione con otro
    {
        if (other.gameObject.tag == "Balon")//le decimos que si el otro objeto es igual a balon
        {

            //Destroy(other.gameObject);
            //Destroy(this.gameObject);

            numToques = numToques + 1;//tenemos un contador de toques del balon al objeto player
            puntuacion.GetComponent<Text>().text = numToques.ToString();//vamos a acceder al componente Text, con esto conseguiremos que se actualice el nº de toques y se mostrará en pantalla
                                                                        //accedemos al rigibody de balon para generarle una fuerza, añadimos addforce y marcamos sus coordenadas con el vector2(x=le damos un valor aleatorio y "y" le aplicamos un 0,1
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-2.0f, 2.0f), 0.1f), ForceMode2D.Impulse);


            // Debug.Log("Toques: " + numToques);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)//bloquearemos la pared izq y la pared derecha para que la barra no traspase
    {

        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "ParedIzquierda")
        {
            bloquearIzquierda = true;
        }
        if (other.gameObject.tag == "ParedDerecha")
        {
            bloquearDerecha = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)//creamos este meteodo para desbloquear las paredes para que la barra se pueda mover a izq o derecha despues de tocar las paredes
    {

        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "ParedIzquierda")
        {
            bloquearIzquierda = false;
        }
        if (other.gameObject.tag == "ParedDerecha")
        {
            bloquearDerecha = false;
        }
    }
}




