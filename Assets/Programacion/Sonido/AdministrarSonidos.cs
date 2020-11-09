using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministrarSonidos : MonoBehaviour
{
    public AudioClip[] sonidos;
    AudioSource fuente;
    // Start is called before the first frame update
    void Start()
    {
        fuente = GetComponent<AudioSource>();
        fuente.clip = sonidos[0];
    }

    public void AbrirPuerta()
    {
        fuente.clip = sonidos[1];
        fuente.Play();
    }
}
