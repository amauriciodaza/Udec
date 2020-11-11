using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GanaroPerder : MonoBehaviour
{
    public void IrMenuPrincipal()
    {
        SceneManager.LoadScene("Principales", LoadSceneMode.Single);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Principal Scene", LoadSceneMode.Single);
    }

    public void Prologo()
    {
        SceneManager.LoadScene("Prologo", LoadSceneMode.Single);
    }
    
}
