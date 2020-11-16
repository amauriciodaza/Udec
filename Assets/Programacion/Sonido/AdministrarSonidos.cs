using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministrarSonidos : MonoBehaviour
{
    public AudioClip sonido;
    AudioSource fuente;
    // Start is called before the first frame update
    void Start()
    {
        fuente = GetComponent<AudioSource>();
        fuente.clip = sonido;

    }
    public void SonidoObjeto()
    {
        fuente.clip = sonido;
        fuente.Play();
    }
    




}
