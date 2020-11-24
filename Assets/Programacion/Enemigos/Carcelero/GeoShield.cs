using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeoShield : MonoBehaviour
{
    bool destructible;
    public float Shield;
    public bool DamageActive;
    public GameObject HP_Bar;
    public Text ShieldTXT;
    // Start is called before the first frame update
    void Start()
    {
        ShieldTXT.text = "";
        destructible = true;
        DamageActive = false;
        Shield = 100f;
    }

    void Update()
    {
        update_HP();
        if (Shield == 0)
        {
            ShieldTXT.enabled = false;
        }
        else
        {
            ShieldTXT.text = "Escudo: " + (int)Shield;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Blade")
        {
            if (Shield >= 1)
            {
                Shield = Shield - Shield * 0.05f;
                if (destructible == true)
                {
                    GetComponent<GeoMovement>().impact();
                    destructible = false;
                    StartCoroutine(Indestructible(3.5f));
                }
            }
            else
            {
                Shield = 0;
                destructible = false;
                DamageActive = true;
            }
        }
    }

    IEnumerator Indestructible(float t)
    {
        yield return new WaitForSeconds(t);
        destructible = true;
    }

    void update_HP()
    {
        float z = Shield / 100;
        Vector3 ScaleBar = new Vector3(1, 1, z);
        HP_Bar.transform.localScale = ScaleBar;
    }

}
