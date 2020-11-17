using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaScript : MonoBehaviour
{
    Collider player;

    Vector3 groundPosition;
    Vector3 lastGroundPosition;
    string groundName;
    string lastGroundName;
    bool isGrounded = true;
    

    Quaternion actualRot;
    Quaternion lastRot;


    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (isGrounded==true)
        {

            RaycastHit hit;
            Debug.Log("isGrounded");
            if (Physics.SphereCast(transform.position, 2f / 2.5f, -transform.up, out hit))
            {
                GameObject groundedIn = hit.collider.gameObject;
                groundName = groundedIn.name;
                groundPosition = groundedIn.transform.position;

                actualRot = groundedIn.transform.rotation;

                if (groundPosition != lastGroundPosition && groundName == lastGroundName)
                {
                    this.transform.position += groundPosition - lastGroundPosition;
                }

                if (actualRot != lastRot && groundName == lastGroundName)
                {
                    var newRot = this.transform.rotation * (actualRot.eulerAngles - lastRot.eulerAngles);
                    this.transform.RotateAround(groundedIn.transform.position, Vector3.up, newRot.y);
                }

                lastRot = actualRot;               
                lastGroundName = groundName;
                lastGroundPosition = groundPosition;

            }


        }
        else if (isGrounded==false) 
        {
            lastGroundName = null;
            lastGroundPosition = Vector3.zero;
            lastRot = Quaternion.Euler(0, 0, 0);
        }
        
    }

     void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.gameObject.transform.position, 2f/2.5f);        
    }





    void OnCollisionEnter(Collision Colisionado)
    {

        if (Colisionado.gameObject.CompareTag("Plataforma")) 
        {
            Debug.Log("Colisionando true");
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision Colisionado)
    {
 
        if (Colisionado.gameObject.CompareTag("Plataforma"))
        {
          
        }
    }

}
