using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarPersonaje : MonoBehaviour
{
    public bool Assasin;
    public bool Magician;

    private void Awake()
    {
        Assasin = PlayerPrefs.GetInt("AssasinSelect", 1) == 1;  // valor por defecto: Assasin = true
        Magician = PlayerPrefs.GetInt("MagicianSelect", 0) == 1;
    }

    private void Update()
    {
        if (!Assasin && !Magician)
        {
            Assasin = true; // valor por defecto si ninguno está activo
        }
    }

    public void PersonajeAssasin()
    {
        Assasin = true;
        Magician = false;
        Guardar();
    }

    public void PersonajeMagician()
    {
        Assasin = false;
        Magician = true;
        Guardar();
    }

    public void Guardar()
    {
        PlayerPrefs.SetInt("AssasinSelect", Assasin ? 1 : 0);
        PlayerPrefs.SetInt("MagicianSelect", Magician ? 1 : 0);
        PlayerPrefs.Save();
    }
}
