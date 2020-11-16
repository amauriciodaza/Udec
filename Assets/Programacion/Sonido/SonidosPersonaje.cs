using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosPersonaje : MonoBehaviour
{
    public AudioClip[] sonidos;
    AudioSource fuente;
    // Start is called before the first frame update
    void Start()
    {
        fuente = GetComponent<AudioSource>();
    }
    public void Runas()
    {
        fuente.clip = sonidos[0];
        fuente.Play();
    }
    public void Caminar()
    {
        fuente.clip = sonidos[1];
        fuente.Play();
    }
    public void Espada()
    {
        fuente.clip = sonidos[2];
        fuente.Play();
    }
    public void Espada2()
    {
        fuente.clip = sonidos[3];
        fuente.Play();
    }
    public void SacarEspada()
    {
        fuente.clip = sonidos[4];
        fuente.Play();
    }
    public void MeterEspada()
    {
        fuente.clip = sonidos[5];
        fuente.Play();
    }
}
