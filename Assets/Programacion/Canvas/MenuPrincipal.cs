using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public static bool ParPan;
    public static bool OpcPan;
    public static bool NueParPan;

    public GameObject PanelPartidas, OpcionesPanel, PanelNuePartida;

    // Start is called before the first frame update
    void Start()
    {
        PanelNuePartida.SetActive(false);
        PanelPartidas.SetActive(false);
        OpcionesPanel.SetActive(false);
    }
    public void Regresar()
    {
        SceneManager.LoadScene("Principal Scene", LoadSceneMode.Single);
    }
    // Update is called once per frame
    public void IrMenuPrincipal()
    {
        SceneManager.LoadScene("Principales", LoadSceneMode.Single);
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
}