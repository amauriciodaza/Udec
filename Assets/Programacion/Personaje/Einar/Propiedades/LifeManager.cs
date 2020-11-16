using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public float life;
    bool DoDamage;

    public Camera PointingCamera, ThirdPersonCamera;

    void Start()
    {
        DoDamage = true;
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

    }
}
