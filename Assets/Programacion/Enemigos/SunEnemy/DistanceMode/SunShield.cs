using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunShield : MonoBehaviour
{
    public float Shield;
    public GameObject HP_Bar;
    public GameObject MeleeSun;
    // Start is called before the first frame update
    void Start()
    {
        Shield = 100f;
        MeleeSun.SetActive(false);
    }

    void Update()
    {
        update_HP();
        if (Shield == 0)
        {
            gameObject.SetActive(false);
            MeleeSun.SetActive(true);
        }
    }

    public void DestroyShield(float D)
    {
        Shield = Shield - D;
    }

    void update_HP()
    {
        float z = Shield / 100;
        Vector3 ScaleBar = new Vector3(1, 1, z);
        HP_Bar.transform.localScale = ScaleBar;
    }
}
