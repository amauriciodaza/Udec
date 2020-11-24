using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocasSub : MonoBehaviour
{
    GameObject Carcelero;
    // Start is called before the first frame update
    void Start()
    {
        Carcelero = GameObject.Find("CarceleroGeo");
    }

    // Update is called once per frame
    void Update()
    {
        if (Carcelero.GetComponent<EnemyLife>().life < 1) 
        {
            Destroy(this.gameObject);
        }

    }
}
