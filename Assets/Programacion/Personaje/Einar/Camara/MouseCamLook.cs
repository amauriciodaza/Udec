/* 
 * author : jiankaiwang
 * description : The script provides you with basic operations 
 *               of first personal camera look on mouse moving.
 * platform : Unity
 * date : 2017/12
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamLook : MonoBehaviour {

    public Camera ThirdPersonCamera;
    public Camera PointingCamera;

    public GameObject Einar;

    bool CameraActive;

    //Sensibilidades de las camaras
    [SerializeField]
    public float sensitivity;
    [SerializeField]
    public float smoothing;
    // the chacter is the capsule
    public GameObject character;
    // get the incremental value of mouse moving
    private Vector2 mouseLook;
    // smooth the mouse moving
    private Vector2 smoothV;

	// Use this for initialization
	void Start ()
    {
        CameraActive = false;
        character = this.transform.parent.gameObject;
        smoothing = 2f;
        PointingCamera.enabled = false;
        Einar = GameObject.Find("Einar");
	}
	
	// Update is called once per frame
	void Update ()
    {
        ChangeCamera();
        CameraSelection();
    }


    void ChangeCamera()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            CameraActive = !CameraActive;
        }
    }

    void CameraSelection()
    {
        if (Einar.GetComponent<BracerFunction>().bracerFunctional && Einar.GetComponent<BracerFunction>().bracerCollected
            && Einar.GetComponent<TranslationMovement>().armas == false)
        {
            Camera();
            ThirdPersonCamera.enabled = false;
            PointingCamera.enabled = true;
            sensitivity = 2f;
        }
        else
        {
            Camera();
            ThirdPersonCamera.enabled = true;
            PointingCamera.enabled = false;
            sensitivity = 3.5f;
        }
    }

    void Camera()
    {
        // md is mosue delta
        var md = new Vector2(Input.GetAxisRaw("Mouse X"),0 /*Input.GetAxisRaw("Mouse Y")*/);
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        // the interpolated float result between the two float values
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        // incrementally add to the camera look
        mouseLook += smoothV;

        // vector3.right means the x-axis
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);

        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}