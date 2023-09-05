using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistencia : MonoBehaviour
{
    
    void Start()
    {
        if (ExisteRecord())
        {
            this.GetComponent<UIController>().SetRecordUI(GetRecord());//muestra el record
        }
        else
        {
            this.GetComponent<UIController>().BorrarRecordUI();//borra el record
        }
    }
    
    
    
    public int GetRecord()
    {
        return PlayerPrefs.GetInt("RECORD");
    }
    public void SetRecord(int r)
    {
        PlayerPrefs.SetInt("RECORD", r);
    }
    public bool ExisteRecord()
    {
        return PlayerPrefs.HasKey("RECORD");
    }
    public void BorrarRecord()
    {
        PlayerPrefs.DeleteKey("RECORD");
    }
    public void BorrarTodo()
    {
        PlayerPrefs.DeleteAll();
    }
}
