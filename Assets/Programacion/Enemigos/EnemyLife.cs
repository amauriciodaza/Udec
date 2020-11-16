using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int EnemyType;

    public float life;
    bool DoDamage;

    void Start()
    {
        DoDamage = true;
    }

    public void Damage(float Dam)
    {
        if (DoDamage)
        {
            DoDamage = false;
            StartCoroutine(NoDamage(0.5f));
            life = life - Dam;
            if (EnemyType == 1)
            {
                if (life >= 1)
                {
                    GetComponent<DistanceMovement>().impact();
                }
                else
                {
                    GetComponent<DistanceMovement>().impact();
                    StartCoroutine(Matar());
                }

            }
            else if (EnemyType == 2)
            {
                if (life >= 1)
                {
                    GetComponent<MeleeMovement>().impact();
                }
                else
                {
                    GetComponent<MeleeMovement>().impact();
                    StartCoroutine(Matar());
                }
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
        if (EnemyType == 1)
        {
            yield return new WaitForSeconds(0.25f);

            GetComponent<DistanceMovement>().death();
            Destroy(this.gameObject, 5f);
        }
        else if (EnemyType == 2)
        {
            yield return new WaitForSeconds(0.25f);

            GetComponent<MeleeMovement>().death();
            Destroy(this.gameObject, 5f);
        }
    }
}
