using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoCarceleroSub : MonoBehaviour
{
    public GameObject cuchilla1, cuchilla2;
    Animator Animaciones;
    // Start is called before the first frame update

    void Start()
    {
        Animaciones = GetComponent<Animator>();
     
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == cuchilla1.name || other.name == cuchilla2.name)
        {
            Animaciones.SetInteger("Estado", 3);
            Debug.Log("tocado");
        }
    }
}
