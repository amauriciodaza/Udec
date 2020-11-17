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
            "Hace 20 años la raza humana se enfrentó a un enemigo que ella misma creo, la vida antigua se desarrollaba en pueblos" +
            " que pasaron a ser ciudades para convertirse en Megalópolis donde vivía una raza humana consumista enceguecida por el" +
            " entretenimiento y el poder económico, perforaban los yacimientos de los restos de los antiguos habitantes del planeta" +
            " en búsqueda de petróleo y carbón, los cuales descubrieron que podía ayudarlos en sus industrias y alimentar sus máquinas." +
            " Pero estos elementos y sus derivados crearon a Contaminación una entidad a la que hacían más fuerte con su uso desmedido" +
            " y al planeta cada vez más débil matando sus selvas, opacando el azul del cielo y acabando con el agua,",
          
            "el recurso más preciado y privilegiado del universo, el planeta cada vez era más incapaz de seguir cuidando y alimentado" +
            " a la raza humana. Aparecieron los guardianes que preocupadospor el hogar de la raza humana y su futuro, investigaron y " +
            " encontraron energías que como el petróleo y el carbón podía alimentar las industrias, máquinas y ciudades, energías que" +
            " no dañaban al planeta y que no le darían más poder a contaminación, energías que nunca se acabarían, energías renovables." +
            " Lastimosamente nadie escucho a los guardianes, los poderosos dueños del petróleo y el carbón no querían ayudar al planeta," +
            " solo querían ayudarse a sí mismos y le dijeron a todos los demás que el planeta era eterno," ,
          
            "que nada pasaría y que Contaminación era solo un invento de los Guardianes y que ellos estaban locos. Los Guardianes fueron" +
            " aislados, desterrados, olvidados y con ellos sus descubrimientos también, nunca más se supo de ellos. Y así avanzo la raza" +
            " humana creciendo más y más utilizando más petróleo y carbón debilitando el planeta, hasta que un día Contaminación se quiso" +
            " adueñar del hogar de la raza humana la naturaleza colapso, los ríos y lagos se secaron, el cielo dejo de brillar y Contaminación" +
            " se convirtió en un ente lleno de destrucción, un ser que odiaba la vida, siendo en sí mismo el portador de la muerte, el planeta" +
            " no pudo cuidar más de la raza humana," ,

            "fueron muy pocos lo que sobrevivieron encontrando en las profundidades del planeta un escondite al caos que habían creado." +
            " 20 años pasaron y los pocos sobrevivientes y sus descendientes han tenido que vivir bajo tierra, minando buscando agua y comida," +
            " viviendo una vida triste y vacía en medio de la oscuridad por sus actos. Einar un joven descendiente de los sobrevivientes estaba" +
            " minando en busca de algo de agua o de comer cuando por error o por fortuna cae por un sumidero que lo conduce a unas ruinas" +
            " subterráneas antiguas donde se encontrara con su destino. Después de caer lo primero que encuentra es una espada clavada en el" +
            " suelo, la cual al acercarse, se aferra a él como si de vida propia se tratara…",
        };
    }
}

