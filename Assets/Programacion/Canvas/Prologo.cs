using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prologo : MonoBehaviour
{
    public Text Dialogos;

   string[] texto;

    //Variables del ciclo for anidado que muestra los dialogos (i , s)
    int i;
    int s;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && i < texto.Length)
        {
            if (s == texto[i].Length)
            {
                i++;
            }
            s = texto[i].Length - 1;
            Dialogos.text = texto[i];
        }
    }

    IEnumerator MostrarDialogos()
    {
        yield return new WaitForSeconds(0.5f);
        int total = texto.Length;
        yield return null;//Seguridad de un null
        for (i = 0; i < total; i++)//Recorremos todas las frases
        {
            string res = "";
            for (s = 0; s < texto[i].Length; s++)//Recorremos char por char esa frase
            {
                res = string.Concat(res, texto[i][s]);
                Dialogos.text = res;
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(1f);
        }
        Dialogos.text = "";
        yield return new WaitForSeconds(0.5f);
    }

   //##################### Escritura de Dialogos ###########################
    void Dialogar()
    {
        //Inicio
        texto = new string[]
        {
            "Hace 400  años los humanos vivian en la superficie donde el consumo de energia era mmedido y todo se vivia" +
            "de la mejor manera hasta que fue tomado por la Contaminación un ente originado por los antiguos habitantes" +
            "y que solo busca destruir la vida en la superficie obligando a los habitantes de la superficie a vivir bajo" +
            "tierra." +
            "Alli vive un joven intrepido llamado Einar el cual lleva viviendo bajo tierra durante varios años, el labora" +
            "en una mina como todas los demas habitantes con las cuales convive." +
            "Hasta que un dia inesperado mientras estaba en medio de sus labores de minería sufre un accidente y llega a" +
            "una mina de cristal, en la que encuentra con un ser que jamas habia visto, este se encuentra atrapado cuyo" +
            "nombre es Sigur un antiguo guardián de las energías que le contara sobre lo que existio en la Superficie antes" +
            "que el quedara atrapado ahi, esto los llevara a vivir una aventura muy interesante."
           /* Sigur le cuenta que de unas energías que fueron atrapadas y de un mundo que existía
            arriba del todo, en la superficie, el cual fue tomado por la Contaminación, un ente
            originado por los antiguos habitantes y que solo busca destruir la vida, obligando a los
            habitantes de la superficie a vivir bajo tierra. " */
        };
    }
}

