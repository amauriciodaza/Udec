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
    }

    // Update is called once per frame
    void Update()
    {
        point();
        Disparar();
    }

    public void Disparar()
    {
        if (bracerFunctional)
        {
            Debug.Log("Ohh me vengo");

            if (Input.GetKeyDown(KeyCode.Mouse0) && Recharge)
            {
                StartCoroutine(Recharging(timeRecharging));
                InstancePower();
                Recharge = false;
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("Recargando");
            }
        }
    }

    public void InstancePower()
    {
        Debug.Log("Salio Poder");
        GameObject obj;
        Rigidbody rb;
        obj = Instantiate(poder, InstancePosition.transform.position, InstancePosition.transform.rotation);
        rb = obj.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * Impulse, ForceMode.Impulse);

        Destroy(obj, 5);
    }

    public void point()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            bracerFunctional = true;
        }
        else
        {
            bracerFunctional = false;
        }
    }

    IEnumerator Recharging(float time)
    {
        yield return new WaitForSeconds(time * 1f);
        Recharge = true;
    }
}
