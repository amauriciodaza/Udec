using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApuñalamientoScript : MonoBehaviour
{
    GameObject carcelero;
    public bool op;

    // Start is called before the first frame update
    void Start()
    {
        op = false;
        carcelero = GameObject.Find("CarceleroGeo");
    }

    public void golpeEinar()
    {
        if (op)
        {
            carcelero.GetComponent<IACarceleroSub>().esp = true;
            Debug.Log("lee el mouse");
        }
    }

}
