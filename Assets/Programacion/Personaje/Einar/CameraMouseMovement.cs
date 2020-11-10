using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseMovement : MonoBehaviour
{
    public Vector3 offset;
    private Transform target;
    [Range(0, 1)] public float lerpValue;

    public float speedH;
    public float speedV;

    float Horizontal;
    float Vertical;

    void Start()
    {
        target = GameObject.Find("Einar").transform;
    }

    void LateUpdate()
    {
        //Horizontal += speedH * Input.GetAxis("Mouse X");
        Vertical -= speedV * Input.GetAxis("Mouse Y");

        //transform.eulerAngles = new Vector3(Vertical, 0, 0);

        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue);

        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * speedH, Vector3.up) * offset;

        transform.LookAt(target.position);
    }
    
    
    
    
    
    
    
    
    
    
    


    // Start is called before the first frame update


    // Esta funcion se ejecuta al final de cada frame
   /* void LateUpdate()
    {
        //Lerp va a mover un objeto de un vector a otro pero lo hara de una forma suavizada
        
        
    }*/
}
