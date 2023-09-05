using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    private GameObject logo;
    public Text numPalomitas;
    public Text crono;
    public Text record;
    public GameObject panelFinal;
    public GameObject panelInicio;
    private int segundosInicio;

    private void Awake()
    {

        General.SetSegundos(General.GetMaxSegundos());//volvera a mostrar los 10 seg iniciales 
        General.SetNumPalomitasDestruidas(0);//al inicio del juego el nº de palomitas sera 0
        logo = (GameObject)GameObject.FindGameObjectWithTag("Logo");
        if (logo != null)
        {
            Invoke("IrMenuPrincipal", 3.0f);
        }
    }

    //creamos 3 metodos para actualizar 

    public void SetNumPalomitas()//actualizar el nº de palomitas destruidas
    {
        numPalomitas.text ="Palomitas: " + General.GetNumPalomitasDestruidas().ToString();
    }

    public void SetCrono()//actualizar crono
    {
        crono.text = General.GetSegundos().ToString();
    }

    public void BorrarRecordUI()
    {
        record.text = "";//borramos el record
    }

    public void SetRecordUI(int r)// actualiza record
    {
        record.text = "Record: " + r.ToString();
    }
    public void IrMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void IrMiniJuego1()
    {
        SceneManager.LoadScene("MiniJuego1");
    }
    public void IrMiniJuego2()
    {
        SceneManager.LoadScene("MiniJuego2");
    }
    public void IrMiniJuego3()
    {
        SceneManager.LoadScene("MiniJuego3");
    }
    public void IrMiniJuegos()
    {
        SceneManager.LoadScene("MiniJuegos");
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Has salido de la app");
    }

    public void IrVolver()
    {
        SceneManager.LoadScene("IrVolver");
    }

    public void IrCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    // Start is called before the first frame update
    void Start()
    {
        segundosInicio = 3;//valor inicial del panel
       if(panelInicio!=null) panelInicio.transform.GetChild(2).GetComponent<Text>().text = segundosInicio.ToString();
     
        if(panelFinal!=null) panelFinal.SetActive(false);//desactivamos el panel
        if (panelInicio != null)
        {
            InvokeRepeating("Crono", 4.0f, 1.0f);//llamamos al metodo crono, lo inicia cuando haya pasado 3seg, y le pasamos el valor de 1 seg para que lo reste
            InvokeRepeating("CronoInicio", 1.0f, 1.0f);
        }


        
    }
    //creo un metodo para crear un panel de inicio
    private void CronoInicio()
    {
        segundosInicio--;
        panelInicio.transform.GetChild(2).GetComponent<Text>().text = segundosInicio.ToString();//actualizo

        if (segundosInicio <= 0)//cuando segundos llega a 0
        {
            
            CancelInvoke("CronoInicio");//cancelo el crono
            panelInicio.SetActive(false);//desactivo el panel de inicio
        }
    }
   //creamos el metodo crono para restar 1 segundo a los 60 que tenemos marcados
    private void Crono()
    {
        General.SetSegundos(General.GetSegundos() - 1);
        this.GetComponent<UIController>().SetCrono();//actualizamos el crono
       // panelFinal.transform.GetChild(2).GetComponent<Text>().enabled = false;

        if (General.GetSegundos() <= 0)
        {
            panelFinal.SetActive(true);//activamos el panel
            panelFinal.transform.GetChild(2).GetComponent<Text>().enabled = false;

            if (this.GetComponent<Persistencia>().ExisteRecord())//miramos si existe un record
            {
                //si nº palomitas destruidas es mayor que el record actual
                if (General.GetNumPalomitasDestruidas() > this.GetComponent<Persistencia>().GetRecord())
                {
                    this.GetComponent<Persistencia>().SetRecord(General.GetNumPalomitasDestruidas());//actualiza su valor
                    panelFinal.transform.GetChild(2).GetComponent<Text>().enabled = true;
                }
            }
            else
            {
                this.GetComponent<Persistencia>().SetRecord(General.GetNumPalomitasDestruidas());//accedemos al componente persistencia que tendra el metodo serecord, que almacenaremos el metodo getnumpalomitasdestruidas
                panelFinal.transform.GetChild(2).GetComponent<Text>().enabled =true;
            }
            //mostramos la informacion de las palomitas destruidas
            panelFinal.transform.GetChild(1).GetComponent<Text>().text = "Palomitas: " + General.GetNumPalomitasDestruidas();
            CancelInvoke("Crono");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        //  pruebaText.GetComponent<Text>().text = Input.touchCount.ToString();
    }
}
