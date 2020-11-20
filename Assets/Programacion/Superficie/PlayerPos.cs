using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    Canvas canvas;
    private GameMaster gm;
    GameObject Einar,cn;
    // Start is called before the first frame update
    void Start()
    {
        cn = GameObject.Find("Game Over Variant");
        canvas = cn.GetComponent<Canvas>();
        Einar = GameObject.Find("Einar");
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        Einar.transform.position = gm.lastCheckPointPost;
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void cargar() 
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if(canvas.enabled){
            canvas.enabled = false;
        }
        Time.timeScale = 1;
    }
}
