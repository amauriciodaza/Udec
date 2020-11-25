using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CargaEscenaSuperficie : MonoBehaviour
{
    public Text instruccion;
    private GameMaster gm;
    GameObject Ajuste;
    Vector3 AjusteV;
    // Start is called before the first frame update
    void Start()
    {
        instruccion.enabled = false;
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        Ajuste = GameObject.Find("Ajusteposicion");
        AjusteV = new Vector3(0f, 2f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(AjusteV+"Ajuste");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Einar")
        {
            gm.lastCheckPointPost = AjusteV;
            instruccion.enabled = true;
            instruccion.text = "CARGANDO...";
            SceneManager.LoadScene("Superficie", LoadSceneMode.Single);
            
        }
    }
}
