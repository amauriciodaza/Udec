using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEinarScript : MonoBehaviour
{
    public GameObject Carcelero;
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
        if (other.name == Carcelero.name) 
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) 
            {
                Carcelero.GetComponent<IACarceleroSub>().esp = true;
                Debug.Log("lee el mouse");
            }

        }
    }
}
