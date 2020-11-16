﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
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
            if (this.gameObject.name == "DistanceEnemy")
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
            else if (this.gameObject.name == "MeleeEnemy")
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
        if (this.gameObject.name == "DistanceEnemy")
        {
            yield return new WaitForSeconds(0.25f);

            GetComponent<DistanceMovement>().death();
            Destroy(this.gameObject, 5f);
        }
        else if (this.gameObject.name == "MeleeEnemy")
        {
            yield return new WaitForSeconds(0.25f);

            GetComponent<MeleeMovement>().death();
            Destroy(this.gameObject, 5f);
        }
    }
}