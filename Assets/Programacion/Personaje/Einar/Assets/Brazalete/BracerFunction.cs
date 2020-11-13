using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BracerFunction : MonoBehaviour
{
    public GameObject poder;
    public GameObject InstancePosition;
    public float Impulse;

    public bool bracerFunctional;
    public bool bracerCollected;
    public bool Recharge;

    public float timeRecharging;
    // Start is called before the first frame update
    void Start()
    {
        bracerFunctional = false;
        bracerCollected = false;
        Recharge = true;
        timeRecharging = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        point();
        Disparar();
    }

    public void Disparar()
    {
        if (bracerFunctional && bracerCollected)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && Recharge)
            {
                StartCoroutine(Recharging(timeRecharging));
                InstancePower();
                Recharge = false;
                GetComponent<Animator>().speed = 1;
                bracerFunctional = false;
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && Recharge == false)
            {
                Debug.Log("Recargando");
                GetComponent<TranslationMovement>().FinishMovement();
                GetComponent<Animator>().speed = 1;
                bracerFunctional = false;
            }
        }
        else
        {
            Debug.Log("Cancelado");
            GetComponent<TranslationMovement>().FinishMovement();
            GetComponent<Animator>().speed = 1;
            bracerFunctional = false;
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
            bracerFunctional = !bracerFunctional;
            if (bracerFunctional == false)
            {
                Debug.Log("A la verga");
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
}
