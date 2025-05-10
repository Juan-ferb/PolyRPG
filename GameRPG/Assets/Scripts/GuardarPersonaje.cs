using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GuardarPersonaje : MonoBehaviour
{
    public bool Assasin;
    public bool Magician;

    private void Update()
    {
        if (Assasin == false && Magician == false)
        {
            Assasin = true;
        }

        Assasin = PlayerPrefs.GetInt("Assasin Seelect") == 1;
        Magician = PlayerPrefs.GetInt("Magician select") == 1;
    }

    public void PersonajeAssasin()
    {
        Assasin = true;
        Magician = false;
        Guardar();
    }

    public void  PersnajeMagician()
    {
        Magician = true;
        Assasin = false;
        Guardar();
    }

    public void Guardar()
    {
        PlayerPrefs.SetInt("Assasin Select", Assasin ? 1 : 0);
        PlayerPrefs.SetInt("Magician Select", Magician ? 1 : 0);
    }
}
