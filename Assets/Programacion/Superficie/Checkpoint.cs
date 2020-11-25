using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int runas;
    private GameMaster gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Einar")
        {
            gm.lastCheckPointPost = transform.position;
            if (other.GetComponent<PropiedadesScript>().runas == 0)
            {
                other.GetComponent<PropiedadesScript>().ContarRunas(runas);
            }
        }    
    }

}
