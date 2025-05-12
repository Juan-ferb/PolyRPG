using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarPersonaje : MonoBehaviour
{
    public GameObject AssasinPersonaje;
    public GameObject MagicianPersonaje;

    private bool assasinSeleccionado;
    private bool magicianSeleccionado;

    private void Start()
    {
        assasinSeleccionado = PlayerPrefs.GetInt("AssasinSelect", 1) == 1;
        magicianSeleccionado = PlayerPrefs.GetInt("MagicianSelect", 0) == 1;

        if (assasinSeleccionado && AssasinPersonaje != null)
        {
            AssasinPersonaje.SetActive(true);
        }

        if (magicianSeleccionado && MagicianPersonaje != null)
        {
            MagicianPersonaje.SetActive(true);
        }

        // Desactivamos el personaje que no fue seleccionado (no se destruye para evitar errores)
        if (assasinSeleccionado && MagicianPersonaje != null)
        {
            MagicianPersonaje.SetActive(false);
        }
        else if (magicianSeleccionado && AssasinPersonaje != null)
        {
            AssasinPersonaje.SetActive(false);
        }
    }
}
