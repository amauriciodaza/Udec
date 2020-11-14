using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Prologo : MonoBehaviour
{
    public Text Dialogos;

    public Text txtButton;

    string[] texto;

    public GameObject Next;

    bool trasncurrir;

    //Variables del ciclo for anidado que muestra los dialogos (i , s)
    int i;
    int s;

    void Start()
    {
        Next.SetActive(false);
        txtButton.text = "Siguiente";
        i = 0;
        Dialogar();
        StartCoroutine(MostrarDialogos());
        Debug.Log(texto.Length);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            s = texto[i].Length - 1;
            Dialogar();
        }
    }

    IEnumerator MostrarDialogos()
    {
        Next.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        yield return null;//Seguridad de un null
            string res = "";
            for (s = 0; s < texto[i].Length; s++)//Recorremos char por char esa frase
            {
                res = string.Concat(res, texto[i][s]);
                Dialogos.text = res;
                yield return new WaitForSeconds(0.025f);
            }
        yield return new WaitForSeconds(2f);
        Next.SetActive(true);

        //Texto del Button
        if (i == texto.Length-1)
        {
            txtButton.text = "Comenzar Aventura";
        }
        else
        {
            txtButton.text = " Siguiente";
        }
    }

    public void SelectDialog()
    {
        if (i < texto.Length-1)
        {
            i++;
            Dialogos.text = "";
            StartCoroutine(MostrarDialogos());
        }
        else
        {
            SceneManager.LoadScene("Principal Scene", LoadSceneMode.Single);
        }
        
    }

   //##################### Escritura de Dialogos ###########################
    void Dialogar()
    {
        texto = new string[]
        {
            "Hace 400  años los humanos vivian en la superficie, donde el consumo de energia era medido y todo se vivia " +
            "de la mejor manera hasta que fue tomado por 'Contaminación' un ente originado por los antiguos habitantes " +
            "y que solo busca destruir la vida en la superficie, obligando a los habitantes de la superficie a vivir bajo " +
            "tierra.",

            "Alli vive un joven intrepido llamado Einar, el cual lleva viviendo bajo tierra durante varios años el trabaja " +
            "en una mina como todas los demas habitantes con las cuales convive. ",

            "Hasta que un dia inesperado mientras estaba en medio de sus labores de minería sufre un accidente y llega a " +
            "una mina de cristal, en la que encuentra con un ser que jamas habia visto, este se encuentra atrapado cuyo " +
            "nombre es Sigur un antiguo guardián de las energías que le contara sobre lo que existio en la Superficie antes " +
            "que el quedara atrapado ahi, esto los llevara a vivir una aventura muy interesante."
        };
    }
}

