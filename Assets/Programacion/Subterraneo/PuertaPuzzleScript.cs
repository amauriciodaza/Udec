using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class PuertaPuzzleScript : MonoBehaviour
{
    int total;
    // Start is called before the first frame update
    void Start()
    {
        total = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Verificar(int num) 
    {
        total = total - num;
        Debug.Log("secuencia: " + total);
        if (total == -5) 
        {
            GetComponent<Animator>().SetBool("Estado", true);
            
        }
    }
}
