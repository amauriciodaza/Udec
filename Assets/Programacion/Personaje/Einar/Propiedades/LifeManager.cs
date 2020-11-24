using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public float life;
    bool DoDamage;
    public Canvas canvas;

    public Camera PointingCamera, ThirdPersonCamera;

    public Scrollbar HealthBar;
    float Health;
    // public Text saludTxt;

    void Start()
    {
        canvas.enabled = false;
        DoDamage = true;
        Health = life;
    }
    void Update()
    {
        HealthBar.size = life / Health;
    }
    public void Damage(float Dam)
    {
        if (DoDamage)
        {
            DoDamage = false;
            StartCoroutine(NoDamage(0f));
            life = life - Dam;
            if (life >= 1)
            {
                GetComponent<TranslationMovement>().Impact();
                GetComponent<AtackDamageEinar>().SwordState = false;
            }
            else
            {
                GetComponent<TranslationMovement>().Impact();
                StartCoroutine(Matar());
            }
          
        }
    }

    IEnumerator NoDamage(float D)
    {
        yield return new WaitForSeconds(D);
        DoDamage = true;
    }

    IEnumerator Matar()
    {
        yield return new WaitForSeconds(0.25f);

        GetComponent<TranslationMovement>().Death();
        GetComponent<TranslationMovement>().enabled = false;
        GetComponent<BracerFunction>().bracerFunctional = false;
        GetComponent<BracerFunction>().enabled = false;
        PointingCamera.GetComponent<MouseCamLook>().enabled = false;
        PointingCamera.enabled = false;
        ThirdPersonCamera.enabled = true;
        ThirdPersonCamera.GetComponent<MouseCamLook>().enabled = false;

        StartCoroutine(GameOver());

    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(7f);

        //SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        canvas.enabled = true;
    }

    public void Curar(float n) 
    {
        life = n;
    }
}
