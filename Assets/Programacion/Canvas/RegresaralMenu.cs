using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegresaralMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas menu;
    public Canvas NuevaPartida;
    public Canvas Opciones;
    public Canvas Partidas;


    public void Start()
    {
        menu.enabled = true;
        NuevaPartida.enabled = false;
        Opciones.enabled = false;
        Partidas.enabled = false;
    }
    private void Update()
    {

    }

    public void MenuPrincipal()
    {
        menu.enabled = true;
        NuevaPartida.enabled = false;
        Opciones.enabled = false;
        Partidas.enabled = false;

    }
}