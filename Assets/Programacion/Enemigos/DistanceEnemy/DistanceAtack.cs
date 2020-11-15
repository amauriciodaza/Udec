using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceAtack : MonoBehaviour
{
    GameObject Character;
    public GameObject atack;
    public GameObject disparador;
    public float Impulse;

    // Start is called before the first frame update
    void Start()
    {
        Character = GameObject.Find("Einar");
    }

    public void InstancePower()
    {
        disparador.transform.LookAt(Character.transform.position);
        GameObject obj;
        Rigidbody rb;
        obj = Instantiate(atack, disparador.transform.position, disparador.transform.rotation);
        rb = obj.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * Impulse, ForceMode.Impulse);

        Destroy(obj, 5);
    }
}
