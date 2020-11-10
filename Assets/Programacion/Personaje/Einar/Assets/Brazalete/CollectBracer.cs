using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBracer : MonoBehaviour
{
    GameObject bracer;
    // Start is called before the first frame update
    void Start()
    {
        bracer = GameObject.Find("Bracer");
        bracer.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Einar")
        {
            other.gameObject.GetComponent<BracerFunction>().bracerCollected = true;
            bracer.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
