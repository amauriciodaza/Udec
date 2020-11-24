using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaScript : MonoBehaviour
{
    bool activo;
    Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            activo = !activo;
                canvas.enabled = activo;
            Time.timeScale = (activo) ? 0 : 1f ;

        }

    }
}
