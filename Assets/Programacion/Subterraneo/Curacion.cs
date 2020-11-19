using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Curacion : MonoBehaviour
{
    public float curacion;
    public Text Instrucciontxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Einar")
        {
            Instrucciontxt.enabled = true;
            Instrucciontxt.text = "CURARSE (F)";
            if (Input.GetKey(KeyCode.F))
            {
                other.GetComponent<LifeManager>().Curar(curacion);
                Destroy(this.gameObject);
            }
        }
    }

}
