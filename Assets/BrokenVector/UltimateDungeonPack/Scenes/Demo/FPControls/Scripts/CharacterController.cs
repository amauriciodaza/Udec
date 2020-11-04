/* 
 * author : jiankaiwang
 * description : The script provides you with basic operations of first personal control.
 * platform : Unity
 * date : 2017/12
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour {
    public int runas;
    public int salud;
    public float speed = 10.0f;
    public float sprintSpeed = 1000f;
    private float translation;
    private float straffe;
    public Text Runastxt, Saludtxt;

    // Use this for initialization
    void Start () {
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;
        runas = 0;
        salud = 100;
        }
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.Space)) {
            transform.Translate(0, 2, 0);
        }
                    
            float speedModifier = 1;
        if (Input.GetKey(KeyCode.LeftShift)) {
            speedModifier = sprintSpeed;
        } else {
            speedModifier = speed;
        }
        // Input.GetAxis() is used to get the user's input
        // You can furthor set it on Unity. (Edit, Project Settings, Input)
        translation = Input.GetAxis("Vertical") * speedModifier * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * speedModifier * Time.deltaTime;
        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape")) {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }
    }


    public void ContarRunas(int num) 
    {
        runas = runas + num;
        Runastxt.text = "RUNAS: " + runas;
    }

    public void Daño(int num)
    {
        salud = salud - num;
        Saludtxt.text = "SALUD: " + salud;
    }
}