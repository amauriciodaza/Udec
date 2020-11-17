using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int EnemyType;//Type 1: Distancia, Type2: Cuerpo a Cuerpo, Type3: CarceleroGeotermico,Type 4: CarceleroSolar, Type 5: Contaminacion

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
            //Restrictor de daño(evita dos daños a un solo enemigo en un golpe)
            DoDamage = false;
            StartCoroutine(NoDamage(0.5f));
            //Enemigo a Distancia
            if (EnemyType == 1)
            {
                life = life - Dam;
                if (life >= 1)
                {
                    GetComponent<DistanceMovement>().impact();
                }
                else
                {
                    GetComponent<DistanceMovement>().impact();
                    StartCoroutine(Matar(10));
                    life = 0;
                }

            }
            //Enemigo Cuerpo a Cuerpo
            else if (EnemyType == 2)
            {
                life = life - Dam;
                if (life >= 1)
                {
                    GetComponent<MeleeMovement>().impact();
                    GetComponent<MeleeAtack>().AtackState = false;
                }
                else
                {
                    GetComponent<MeleeMovement>().impact();
                    StartCoroutine(Matar(10));
                    life = 0;
                }
            }
            //Carcelero Geotermico
            else if (EnemyType == 3 && GetComponent<GeoShield>().DamageActive)
            {
                life = life - Dam;
                if (life >= 1)
                {
                    GetComponent<GeoMovement>().impact();
                    GetComponent<GeoAtackActive>().AtackState = false;
                }
                else
                {
                    GetComponent<GeoMovement>().impact();
                    StartCoroutine(Matar(10));
                    life = 0;
                }
            }
            else if (EnemyType == 4)
            {
                life = life - Dam;
            }
            else if (EnemyType == 5)
            {
                life = life - Dam;
            }
        }
    }

    IEnumerator NoDamage(float D)
    {
        yield return new WaitForSeconds(D);
        DoDamage = true;
    }

    IEnumerator Matar(float t)
    {
        yield return new WaitForSeconds(0.25f);
        if (EnemyType == 1)
        {
            GetComponent<DistanceMovement>().death();
            Destroy(this.gameObject, 7f);
        }
        else if (EnemyType == 2)
        {
            GetComponent<MeleeMovement>().death();
            Destroy(this.gameObject, 7f);
        }
        else if (EnemyType == 3)
        {
            GetComponent<GeoMovement>().death();
            Destroy(this.gameObject, 10f);
        }
    }
}
