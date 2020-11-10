using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextosSuperficie : MonoBehaviour
{
    public Text Dialogos;
    public GameObject Panel;

    int triggerAc;

    string[] texto;

    public GameObject[] triggers;

    //Variables del ciclo for anidado que muestra los dialogos (i , s)
    int i;
    int s;

    void Start()
    {
        Panel.SetActive(false);
    }

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
        Panel.SetActive(true);
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
        Panel.SetActive(false);
    }

    //##################### Validacion de Triggers ##########################
    void OnTriggerEnter(Collider Other)
    {
        for (int j = 0; j < triggers.Length; j++)
        {
            if (Other.name == triggers[j].name)
            {
                triggerAc = j + 1;
                Dialogar();
                StartCoroutine(MostrarDialogos());
                Destroy(triggers[j].gameObject.GetComponent<Collider>());
                Debug.Log(triggerAc);
                break;
            }
        }
    }

    //##################### Escritura de Dialogos ###########################
    void Dialogar()
    {
        //Inicio en la superficie
        if (triggerAc == 1)
        {
            texto = new string[]
            {
                "Einar: Es increíble, todo está desolado, me sorprende todo el daño que le hicimos a la tierra para que se encuentre así... ",
                "necesitamos ir al templo del sol y derrotar a la malvada contaminación para liberar la tierra y que recobre vida de nuevo.",
                "Vamos Sigurd!! No podemos perder más tiempo.",
                "Einar: Mira un brazalete…",
                "Sigurd: Ese brazalete le pertenecía a Lena la guardiana de la energía solar… si lo usas podrás lanzar cargas solares…"
            };
        }
        //Einar se pone el brazalete
        else if (triggerAc == 2)
        {
            texto = new string[]
            {
                "Sigurd: Tu espada se apaga debemos encontrar piedras volcánicas estas te ayudaran a recargar la espada para que la puedas seguir utilizando…",
                "Einar: ohh…Mira una salida creo que debemos continuar por allá…. Veo algo extraño."
            };
        }
        //Llegando al encuentro con los enemigos
        else if (triggerAc == 3)
        {
            texto = new string[]
            {
                "Sigurd: Son enemigos enviados por contaminación… Derrótalos y así podremos seguir…"

            };
        }
        //Lucha contra soldados
        else if (triggerAc == 4)
        {
            bool Enemigos = false;//con un GetComponent podemos terminarlo
            if (Enemigos)
            {
                texto = new string[]
                {
                    "Soldados: Lo sabíamos… se necesita más para derrotarnos..",
                    "Sigurd: Vaya fallamos."
                };
            }
            else
            {
                texto = new string[]
                {
                    "Soldados: ¡Noooo! no pensamos que nos podrías derro……",
                    "Sigurd: Vaya pensé que nos iban a derrotar",
                    
                };
            }
        }
        //Camino a las plataformas
        else if (triggerAc == 5)
        {
            texto = new string[]
            {
                "Sigurd: Lo lograste!...Continuemos debemos llegar hasta el templo del sol.",
                "Einar: Me siento cansado necesito recuperar energía…",
                "Sigurd: Mas adelante encontraras un árbol sano… podrás recuperar tu energía y salud allí."
            };
        }
        //En el punto de curacion
        else if (triggerAc == 6)
        {
            texto = new string[]
            {
                "Sigurd: Mira un punto de curación. Podrás recuperar tu salud siempre que encuentres uno",
                "Einar: Lo necesitaba la lucha anterior me dejo demasiado débil.",

                "Einar: Estoy listo… debemos continuar "

            };
        }
        //Al llegar a la fosa
        else if (triggerAc == 7)
        {
            texto = new string[]
            {
                "Einar: ¿Qué es esto? …. ¡Es una fosa que extraño!",
                "Sigurd: Así es. Vamos tenemos que pasarla para llegar al templo del sol.",
                "Einar: ¿Qué es eso? Parecen ser…",
                "Sigurd: Son unas plataformas… deberás saltar sobre ellas hasta llegar al punto más alto…",

            };
        }
       
        //En la cima de las plataformas
        else if (triggerAc == 8)
        {
            texto = new string[]
            {
                "Einar: ¡Vaya que complicado… pero lo hemos logrado!",

            };
        }
        //Encuentro panel solar
        else if (triggerAc == 9)
        {
            texto = new string[]
            {
                "Sigurd: Hemos encontrado el primer panel solar. Aquí podrás recargar la energía del brazalete para seguir utilizándolo….",
                "Einar: ¿Panel solar? ¿Qué es eso?...",
                "Sigurd: Es un dispositivo que aprovecha la energía del sol, generando electricidad, ",
                "esto lo hace mediante el almacenamiento y la conversión de la radiación.. Generando cargas positivas y negativas,",
                "lo que genera un campo eléctrico que producirá corriente eléctrica…",
                "Einar: Vaya es muy interesante a puesto que esto le hace muy bien a la tierra",
                "Sigurd: Es una energía limpia, inagotable y su uso no le trae consecuencias negativas al planeta.",
                "Sigurd: Sigamos el camino… estamos muy cerca."
            };
        }
        //Lllegando a la botalla con los solados cuerpo a cuerpo y a distancia
        else if (triggerAc == 10)
        {
            texto = new string[]
            {
                "Einar: Parece que tendremos otra batalla… Veo seres extraños",
                "Sigurd: Son soldados cuerpo a cuerpo y a distancia… Tienes que derrotarlos",
                "Sigurd: Destruye los enemigos del primer nivel… Luego derrota los del segundo nivel con tu arco."
            };
        }
        //Finalizacion de batalla con soldados cuerpo a cuerpo y a distancia
        else if (triggerAc == 11)
        {
            bool Soldadosd = false;//con un GetComponent podemos terminarlo
            if (Soldadosd )
            {
                texto = new string[]
                {
                    "Soldados: Se necesita de mucho más para vencernos ",
                    "Sigurd: Hemos fallado."
                };
            }
            else
            {
                texto = new string[]
                {
                    "Soldados: Vaya no pensé que pudieran derro-tar..",
                    "Sigurd: ¡Lo sabía! Pudimos derrotarlos.",
                   
                };
            }
        }
        //Llegando a la forja
        else if (triggerAc == 12)
        {
            texto = new string[]
            {
                "Sigurd: ¡¡Muy bien Einar!! Lograste derrotarlo, continúa escalando y encontraras una forja donde podrás mejorar tu arma y además recargar la espada, ",
                "no olvides recoger todas las runas.",

                "Sigurd: Mira también puedes curarte…",

            };
        }
        //Llegando a la entrada del templo del sol
        else if (triggerAc == 13)
        {
            texto = new string[]
            {
                "Einar: Mira Sigurd veo algo al fondo. Parece que llegamos.",
                "Sigurd: Así es… Pero primero tienes que escalar y recoger la runa solar. Sabes que son muy importantes para continuar",


            };
        }
        
         
       
    }
}
