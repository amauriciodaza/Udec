using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CargaEscenaSuperficie : MonoBehaviour
{
    public Text instruccion;   
    // Start is called before the first frame update
    void Start()
    {
        instruccion.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Einar")
        {
            instruccion.enabled = true;
            instruccion.text = "Cargando...";
            SceneManager.LoadScene("Superficie", LoadSceneMode.Single);
            
        }
    }
}
