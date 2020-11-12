using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonPuzzleAnimScript : MonoBehaviour
{
    public GameObject Numero1;
    public GameObject Numero2;
    public GameObject Numero3;
    public GameObject Numero4;
    public GameObject Numero5;
    public GameObject puerta;
    public GameObject Instructor;
    bool op;
    public GameObject other;
    public Text Instrucciontxt;
    // Start is called before the first frame update
    void Start()
    {
        other = GameObject.Find("Einar");
    }

    // Update is called once per frame
    void Update()
    {
        if (op == true)
        {
            Instrucciontxt.enabled = true;
            Instrucciontxt.text = "REINICIAR (F)";
            if (Input.GetKeyDown(KeyCode.F))
            {
                GetComponent<Animator>().SetInteger("Estado", 1);
                Numero1.GetComponent<BotonPuzzleSub>().no = 0;
                Numero2.GetComponent<BotonPuzzleSub>().no = 0;
                Numero3.GetComponent<BotonPuzzleSub>().no = 0;
                Numero4.GetComponent<BotonPuzzleSub>().no = 0;
                Numero5.GetComponent<BotonPuzzleSub>().no = 0;
                puerta.GetComponent<PuertaPuzzleScript>().a = 0;
                puerta.GetComponent<PuertaPuzzleScript>().b = 0;
                puerta.GetComponent<PuertaPuzzleScript>().c = 0;
                puerta.GetComponent<PuertaPuzzleScript>().d = 0;
                puerta.GetComponent<PuertaPuzzleScript>().e = 0;
                Instructor.GetComponent<InstruccionPuzzle>().t = 0f;
                Instructor.GetComponent<InstruccionPuzzle>().op = true;

                Instrucciontxt.enabled = false;
            }
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Einar")
        {
            op = true;
            Debug.Log("entro");

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Einar")
        {
            op = false;
            GetComponent<Animator>().SetInteger("Estado", 0);
            Instrucciontxt.enabled = false;
        }
    }

}
