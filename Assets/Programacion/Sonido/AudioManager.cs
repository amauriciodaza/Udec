using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] sonidos;
    AudioSource fuente;
    // Start is called before the first frame update
    void Start()
    {
        fuente = GetComponent<AudioSource>();
        fuente.clip = sonidos[0];
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Cube")
        {
            fuente.clip = sonidos[1];
            fuente.Play();
        }
        else if (other.name == "Capsule")
        {
            fuente.clip = sonidos[2];
            fuente.Play();
        }
        else if (other.name == "Sword")
        {
            fuente.clip = sonidos[3];
            fuente.Play();
        }
    }
}
