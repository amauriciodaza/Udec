using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //para tener acceso a la interface de usuario
using UnityEngine.SceneManagement;
using MySql.Data.MySqlClient;
public class Login : MonoBehaviour
{
    // Redireccionamiento a crear cuenta
    public string direccionLostEnergy;

    //Logeo
    public Text usuario;
    public InputField experimento;
    public Text mensaje;

    public string convertir1;
    public string convertir2;

    private string usuario_encapsulado;
    private string contra_encapsulado;

    public string Usuario_encapsulado { get => usuario_encapsulado; set => usuario_encapsulado = value; }
    public string Contra_encapsulado { get => contra_encapsulado; set => contra_encapsulado = value; }

    void Start()
    {
        Debug.Log("Conexion Establecida");
         mensaje.enabled = false;
        // contraseña = Text.c
           //  convertir2 = InputField.ContentType.Standard;
    }

    //PARA MOSTRAR EN EL FORMULARIO
    public void iniciarsesion()
    {
        experimento.contentType = InputField.ContentType.Standard;
        // Debug.Log("ell usuario es:  " + (usuario.GetComponent<Text>().text).ToString() + contraseña);
        convertir1 = (usuario.GetComponent<Text>().text).ToString();
        convertir2 = (experimento.text).ToString();
     
        experimento.contentType = InputField.ContentType.Password;

        try
        {
            MySqlConnection conexion = new MySqlConnection();
            string DataConection = "Server=151.106.96.51;Database=u323658391_lostenergy;Uid=u323658391_daniels;Pwd=Uepq0[Uu7;Port=3306;";
            conexion.ConnectionString = DataConection;

            conexion.Open();

            MySqlCommand comando = new MySqlCommand("SELECT * FROM tb_usuarios where Nombre_Usuario LIKE " +"'"+ convertir1 + "'" + " AND clave LIKE "+"'"+ convertir2 + "'" + " ;", conexion);

            MySqlDataReader ejecute;

            ejecute = comando.ExecuteReader();

          //  Debug.Log("funciono");


            while (ejecute.Read())
            {
                Usuario_encapsulado = ejecute.GetString(1);
                Contra_encapsulado = ejecute.GetString(3);
            }
            conexion.Close();

            if (convertir1== Usuario_encapsulado && convertir2== Contra_encapsulado)
            {
                //Debug.Log("El usuario y contraseña coinciden, bienvenido ");
                mensaje.enabled = true;
                mensaje.text = "El usuario y contraseña coinciden, bienvenido ";
                SceneManager.LoadScene("Principales", LoadSceneMode.Single);
            }
            else
            {
                mensaje.enabled = true;
               // Debug.Log("El usuario o contraseña son incorrectos");
                mensaje.text = "El usuario o contraseña son incorrectos ";
                StartCoroutine(QuitarMError());
            } 
        }
        catch (MySqlException error)
        {
            Debug.Log(" no funcinaa "+error);
        }
    }

    // Update is called once per frame
    void Update()
    {
      //  Debug.Log(contraseña.text);
    }

    IEnumerator QuitarMError()
    {
        yield return new WaitForSeconds(5f);
        mensaje.enabled = false;
    }

    public void RedireccionaraPagLostEnergy()
    {
        Application.OpenURL(direccionLostEnergy);
    }
}
