using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PalomitasCreator : MonoBehaviour
{
    //referenciamos
    public GameObject panel;
    public GameObject camera;
    public GameObject palomita;
    private GameObject palomitaClon;
    public GameObject palomitaRoja;
    private GameObject palomitaRojaClon;
    private float ancho;
    private float alto;
    private Vector3 posPalomitaWorld;
    private float margenVertical;
    private float margenHorizontal;

    private int palomitaRandom;

    

    // Start is called before the first frame update
    void Start()
    {
        margenHorizontal = 45.0f;
        margenVertical = 45.0f;
        InvokeRepeating("CrearPalomita", 4.0f, 0.2f);
    }

    public void CrearPalomita()
    {
        Debug.Log(panel.GetComponent<RectTransform>().sizeDelta.y);
        ancho = Random.Range(margenHorizontal, Screen.width-margenHorizontal);//min y max de ancho de pantalla
        alto = Random.Range(margenVertical, Screen.height-margenVertical-panel.GetComponent<RectTransform>().sizeDelta.y);//min y max de alto de pantalla
        //posicion de la palomita en el mundo
        posPalomitaWorld = camera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(ancho, alto, camera.transform.position.z));
        posPalomitaWorld.z = 0.0f;//la posicion de la palomita en z la pongo a 0, para que sea renderizada por la camara
                                  //referenciamos la palomitaclon



        palomitaRandom = Random.Range(0, 100);//aqui marco el rango
        if (palomitaRandom <= 90)//aqui creara el 90% de palomitas blancas y el otro 10% rojas
        {
            palomitaClon = (GameObject)Instantiate(palomita, posPalomitaWorld, Quaternion.identity);
        }
        else
        {//de lo contrario crea una roja
            palomitaRojaClon = (GameObject)Instantiate(palomitaRoja, posPalomitaWorld, Quaternion.identity);
        }
        if (General.GetSegundos() <= 0)
        {
            CancelInvoke("CrearPalomita");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
