using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [Range(1, 10)] public float rotationVelocity;
    [Range(1, 10)] public float walkingVelocity;
   

    float rotationY;
    float axisX;
    float axisY;

    float speedX;
    float speedZ;
    bool run;

    CharacterController cc;

    Animator anim;

    const string nameAxisX = "Horizontal";
    const string nameAxisY = "Vertical";

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        
        //cc.detectCollisions = true;
    }
    // Update is called once per frame
    void Update()
    {
        axisX = Input.GetAxis(nameAxisX);
        axisY = Input.GetAxis(nameAxisY);
        
        
        if (axisY > 0)
        {
            anim.SetInteger("Estado", 1);
        }
        else
            anim.SetInteger("Estado", 0);
    }
    private void FixedUpdate()
    {
        rotationY += axisX * rotationVelocity;
        speedX = Mathf.Sin(rotationY * Mathf.Deg2Rad) * walkingVelocity * axisY ;//seno del ángulo "rotationY", Mathf.Sin solo recibe radianes, por lo que hay que convertir el ángulo de grados a radianes
        speedZ = Mathf.Cos(rotationY * Mathf.Deg2Rad) * walkingVelocity * axisY ;//seno del ángulo "rotationY", Mathf.Sin solo recibe radianes, por lo que hay que convertir el ángulo de grados a radianes
        //cc.SimpleMove(new Vector3(speedX, 0, speedZ));
        transform.localEulerAngles = new Vector3(0, rotationY, 0);

      

    }
    
}
