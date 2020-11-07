using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseMovement : MonoBehaviour
{
    public Vector3 offset;
    private Transform target;
    [Range (0,1)]public float lerpValue;
    public float sensibilidad;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Einar").transform;
    }

    // Esta funcion se ejecuta al final de cada frame
    void LateUpdate()
    {
        //Lerp va a mover un objeto de un vector a otro pero lo hara de una forma suavizada
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue);
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * sensibilidad, Vector3.up)*offset;
        
        transform.LookAt(target.position);
    }
}
