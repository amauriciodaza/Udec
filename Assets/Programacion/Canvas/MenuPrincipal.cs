﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public static bool ParPan;
    public static bool OpcPan;
    public static bool NueParPan;
    public static bool SalirPan;
    public static bool CargarPan;

    public GameObject PanelPartidas, OpcionesPanel, PanelNuePartida, PanelSalir, PanelCargar;

    // Start is called before the first frame update
    void Start()
    {
        PanelNuePartida.SetActive(false);
        PanelPartidas.SetActive(false);
        OpcionesPanel.SetActive(false);
        PanelSalir.SetActive(false);
        PanelCargar.SetActive(false);
    }
    public void EmpezarJuego()
    {
        SceneManager.LoadScene("Principal Scene", LoadSceneMode.Single);
    }
    // Update is called once per frame
    public void IrMenuPrincipal()
    {
        SceneManager.LoadScene("Principales", LoadSceneMode.Single);
    }
    public void IrGameOver()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
    public void Panel1()
    {
        PanelNuePartida.SetActive(true);
    }
    public void Panel2()
    {
        PanelPartidas.SetActive(true);
    }
    public void Panel3()
    {
        OpcionesPanel.SetActive(true);
    }
    public void Panel4()
    {
        PanelSalir.SetActive(true);
    }

    public void Prologo()
    {
        SceneManager.LoadScene("Prologo", LoadSceneMode.Single);
    }

    public void Salir()
    {
        Debug.Log("Se ha salido del juego");
        Application.Quit();
    }
    public void Cancelar()
    {
        PanelCargar.SetActive(false);
    }

    public void Cargar()
    {
        PanelCargar.SetActive(true);
    }
}