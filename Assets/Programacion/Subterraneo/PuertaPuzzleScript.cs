using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class PuertaPuzzleScript : MonoBehaviour
{
    public int a, b, c, d, e;
    int sec, abrir;

    // Start is called before the first frame update
    void Start()
    {
        a = 0;
        b = 0;
        c = 0;
        d = 0;
        e = 0;
        sec = 0;
        abrir = 0;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("secuencia: " + a + "," + b + "," + c + "," + d + "," + e + ",");

        if (a == 1 && b == 0 && c == 0 && d == 0 && e == 0)
        {
            Debug.Log("primero");
            sec = 1;
        }
        if (b == 1 && c == 0 && d == 0 && e == 0 && sec ==1)
        {
            Debug.Log("segundo");
            sec = 2;
        }
        if (c == 1 && d == 0 && e == 0 && sec==2)
        {
            Debug.Log("tercero");
            sec = 3;

        }
        if (d == 1 && e == 0 && sec == 3)
        {
            Debug.Log("cuarto");
            sec = 4;
            abrir = 1;

        }
        if (e == 1 && sec == 4 && Input.GetKeyUp(KeyCode.F)&& abrir==1)
        {
            Debug.Log("abrio");
            GetComponent<Animator>().SetBool("Estado", true);
            GetComponent<AdministrarSonidos>().SonidoObjeto();
            abrir = 0;
        }


    }

   
}
