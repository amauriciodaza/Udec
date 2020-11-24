using UnityEngine;
using MySql.Data.MySqlClient;

public class MySQLManager : MonoBehaviour
{
    public string servidorBaseDatos;
    public string nombreBaseDatos;
    public string usuarioBaseDatos;
    public string contraseñaBaseDatos;

    private string datosConexion;
    private MySqlConnection conexion;
    // Start is called before the first frame update
    void Start()
    {
        datosConexion = "Server = " + servidorBaseDatos
                        + ";Database = " + nombreBaseDatos
                        + ";Uid = " + usuarioBaseDatos
                        + ";Pwd = " + contraseñaBaseDatos
                        + ";";

        ConectarConServidorBD();
    }

    private void ConectarConServidorBD()
    {
        conexion = new MySqlConnection(datosConexion);

        try
        {
            conexion.Open();
            Debug.Log("Conexion establecida");
        }
        catch(MySqlException error)
        {
            Debug.Log("imposible conectar con base de datos: " + error);
        }
    }

    public MySqlDataReader Select(string _select)
    {
        MySqlCommand cmd = conexion.CreateCommand();
        cmd.CommandText = "SELECT * FROM" + _select;
        MySqlDataReader Resultado = cmd.ExecuteReader();
        return Resultado;
    }
}
