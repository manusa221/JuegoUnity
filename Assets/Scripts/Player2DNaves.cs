using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//siempre que queramos trabajar con algun elemento de la UI tenemos que importar la librería

public class Player2DNaves : MonoBehaviour
{
    public GameObject record;
    public GameObject puntuacion;//vamos a referenciar el objeto, donde voy almacenar los puntos
    //1º vamos a generar el desplazamiento
    public VariableJoystick vj;
    protected float h;
    protected float velocidad;
    public GameObject explosion;//referenciamos la explosion
    protected GameObject explosionClon;//hago clon

    public GameObject laser;//referenciamos la laser
    protected GameObject laserClon;//hago clon

    public GameObject canvas;//referenciamos el canvas
    protected float fuerza;
    // Start is called before the first frame update
    void Start()
    {
        //inicio juego
        Time.timeScale = 1.0f;//1 va normal, y contra menos va más despació
        //reiniciamos los puntos al reiniciar la partida
        GeneralNave.puntos = 0;
        puntuacion.GetComponent<Text>().text = GeneralNave.puntos.ToString();
        //playerPrefs es como una base de datos, si tiene la clave 
        if (PlayerPrefs.HasKey("ASTEROIDESDESTRUIDOS"))
        {
            record.GetComponent<Text>().text = PlayerPrefs.GetInt("ASTEROIDESDESTRUIDOS").ToString();
        }
        else
        {
            record.GetComponent<Text>().text = "";//si no hay record lo dejamos vacío
        }
        velocidad = 5.0f;
        fuerza = 10.0f;
        //InvokeRepeating("Disparar", 0.0f, 1.0f);//repite el disparo cada segundo

    }

    public void Disparar()//creo un metodo para disparar
    {
        laserClon = Instantiate(laser, this.gameObject.transform.position, Quaternion.identity);
        Destroy(laserClon, 5.0f);//destruyo el laser al cabo de 5seg
                                 //vamos aplicarle una fuerza en su rigibody
        laserClon.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, fuerza);
    }

    // Update is called once per frame
    void Update()
    {
        //puntuacion es un UIText(elemento de la interfaz gráfica de usuario) y queremos acceder a su componente Text y a su atributo Text
        puntuacion.gameObject.GetComponent<Text>().text = GeneralNave.puntos.ToString();

        
        h = vj.Horizontal * Time.deltaTime * velocidad;//calculo de la velocidad de los frames
        this.gameObject.transform.Translate(h, 0.0f, 0.0f);//movimiento en el eje x
       
        if (Input.GetMouseButtonDown(1))//le digo si pulso el boton dercho del raton.Input sirve para dar entrada a un hardware 
        {
           // Disparar();//llamamos al metodo disparar
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Asteroide")
        {
           //si he perdido tenemos que mirar si los puntos son menores de los que hemos conseguido 
            if (PlayerPrefs.HasKey("ASTEROIDESDESTRUIDOS"))//si he jugado almenos una vez
            {
                //linea que da el valor actual                   //puntos que acabo de conseguir
                if (PlayerPrefs.GetInt("ASTEROIDESDESTRUIDOS")< GeneralNave.puntos)
                {
                    PlayerPrefs.SetInt("ASTEROIDESDESTRUIDOS", GeneralNave.puntos);//machacamos el valor que tiene.
                } 
            }
            else//no hemos jugado nunca
            {
                //estamos creando una linea con una clave y le voy asignar un valor, que será el del script generalnuevo puntos
                PlayerPrefs.SetInt("ASTEROIDESDESTRUIDOS", GeneralNave.puntos);
            }
            
             //cuando cuoque un asteroide lo activamos.
            canvas.gameObject.SetActive(true);
            //Time.timeScale = 0.0f;//para el tiempo de juego
            //tenemos que instanciar en tiempo de ejecucion, que salga una explosion, el metodo es Instantiate(),tiene tres parametros. 1º el objeto que vas a clonar.2º donde lo vas a clonar (lo vamos a clonar en la posicion del asteroide)
            //3º Quaternion.identity8posicion la que tiene, no va a girar nada)
            explosionClon = Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
            Destroy(explosionClon, 5.0f);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        }
    
    }
