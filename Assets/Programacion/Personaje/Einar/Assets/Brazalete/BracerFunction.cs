﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BracerFunction : MonoBehaviour
{
    public GameObject poder;
    public GameObject InstancePosition;
    public float Impulse;

    public bool bracerFunctional;
    public bool bracerCollected;
    public bool Recharge;
    public Image Mira;
    public bool finish;

    public float timeRecharging;
    // Start is called before the first frame update
    void Start()
    {
        bracerFunctional = false;
        bracerCollected = false;
        Recharge = true;
        timeRecharging = 2f;
        finish = true;
        Mira.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bracerCollected)
        {
            point();
            Disparar();
        }
    }

    public void Disparar()
    {
        if (bracerFunctional && bracerCollected)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && Recharge)
            {
                Mira.enabled = false;
                StartCoroutine(Recharging(timeRecharging));
                InstancePower();
                Recharge = false;
                GetComponent<Animator>().speed = 1;
                StartCoroutine(Esperar());
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && Recharge == false)
            {
                Mira.enabled = false;
                Debug.Log("Recargando");
                //Atack.text = "Recargando";
                GetComponent<TranslationMovement>().FinishMovement();
                GetComponent<Animator>().speed = 1;
                bracerFunctional = false;
            }
        }
        else if (bracerFunctional == false && finish)
        {
            StartCoroutine(Finishing());
            GetComponent<TranslationMovement>().FinishMovement();
            GetComponent<Animator>().speed = 1;
        }
    }

    public void InstancePower()
    {
        GameObject obj;
        Rigidbody rb;
        obj = Instantiate(poder, InstancePosition.transform.position, InstancePosition.transform.rotation);
        rb = obj.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * Impulse, ForceMode.Impulse);

        Destroy(obj, 5);
    }

    public void point()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && GetComponent<TranslationMovement>().armas == false)
        {
            Mira.enabled = true;
            bracerFunctional = !bracerFunctional;

            if (bracerFunctional == false)
            {
                finish = true;
                GetComponent<TranslationMovement>().FinishMovement();
                GetComponent<Animator>().speed = 1;
                bracerFunctional = false;
            }
        }
    }

    IEnumerator Recharging(float time)
    {
        yield return new WaitForSeconds(time * 1f);
        Recharge = true;
    }

    //Por evento de animacion.
    void Apuntar()
    {
        GetComponent<Animator>().speed = 0;
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(0.4f);
        bracerFunctional = false;
    }

    IEnumerator Finishing()
    {
        yield return new WaitForSeconds(0.1f);
        finish = false;
    }
}
