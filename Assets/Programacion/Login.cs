using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public string direccionLostEnergy;

    public InputField usuarioTxt, contraseñaTxt;
    public Text Incorrecto;

    // Start is called before the first frame update
    void Start()
    {
        Incorrecto.enabled = false;
    }

    public void logear()
    {
        string _log = "`tb_usuarios` WHERE `Nombre_Usuario` LIKE '" + usuarioTxt.text +
                      "' AND `Contraseña_Usuario` LIKE '" + contraseñaTxt.text + "'";
        MySQLManager _mySQLManager = GameObject.Find("DBManager").GetComponent<MySQLManager>();
        MySqlDataReader Resultado = _mySQLManager.Select(_log);

        if (Resultado.HasRows)
        {
            Debug.Log("Login Correcto");
            Resultado.Close();
            SceneManager.LoadScene("Principales", LoadSceneMode.Single);
        }
        else
        {
            Incorrecto.enabled = true;
            StartCoroutine(DatosErrados());
            Resultado.Close();
        }
    }

    public void RedireccionaraPagLostEnergy()
    {
        Application.OpenURL(direccionLostEnergy);
    }

    IEnumerator DatosErrados()
    {
        yield return new WaitForSeconds(10f);
        Incorrecto.enabled = false;
    }
}
