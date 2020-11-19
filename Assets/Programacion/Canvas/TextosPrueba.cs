using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextosPrueba : MonoBehaviour
{
    public Text Dialogos;
    public GameObject Panel;

    int triggerAc;

    string[] texto;

    public GameObject[] triggers;

    GameObject CarceleroGeo;

    //Variables del ciclo for anidado que muestra los dialogos (i , s)
    int i;
    int s;

    void Start()
    {
        Panel.SetActive(false);
        CarceleroGeo = GameObject.Find("CarceleroGeo");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && i < texto.Length)
        {
            if (s == texto[i].Length)
            {
                i++;
            }
            s = texto[i].Length-1;
            //Dialogos.text = texto[i];
        }
    }

    IEnumerator MostrarDialogos()
    {
        Panel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        int total = texto.Length;
        yield return null;//Seguridad de un null
        //GetComponent<TranslationMovement>().enabled = false;
        for (i = 0; i < total; i++)//Recorremos todas las frases
        {
            string res = "";
            for (s = 0; s < texto[i].Length; s++)//Recorremos char por char esa frase
            {
                res = string.Concat(res, texto[i][s]);
                Dialogos.text = res;
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(1f);
        }
        GetComponent<TranslationMovement>().enabled = true;
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
                
                triggerAc = j+1;
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
        //Dialogo con LuxTerra al encontrarla.
        if (triggerAc == 1)
        {
            GetComponent<TranslationMovement>().FinishMovement();
            GetComponent<TranslationMovement>().enabled = false;
            GetComponent<Animator>().SetInteger("Estado", 0);
            texto = new string[]
            {
                "Einar: ¡¿Qué es esto?!, de repente esa espada llameante salto a mi espalda, pensé que me quemaría, pero… Se siente una energía increíble en mi cuerpo...",
                "Einar: ¿Que acabo de escuchar en mi mente?…El sable?… esta espada…",
                "LuxTerra: Joven guerrero, no temas, el destino te ha elegido para portar los tesoros de los guardianes… Y la misión de recuperar el mundo que hace 20 años se perdió por los errores de tus antepasados… En este sable esta la esencia viva de la tierra misma, porta su energía, y su poder, como ya tu mismo lo pudiste sentir.",
                "Einar: Osea que este es… El sable del que mi padre me contaba en sus historias. Pero si se supone eran solo historias.",
                "LuxTerra: A veces la realidad pasa a ser solo un cuento ya que no hay como o quien la atestigüe.",
                "Einar: Es increíble… Mi padre me contaba que en el pasado la humanidad estaba llena de codicia y consumismo, destruían la naturaleza solo pensando en si mismos, y esto alimentaba a la esencia del caos, a Contaminación… Sin embargo entre ellos habían personas que luchaban incansablemente para hacer entender a la humanidad el daño que estaban haciendo, sin embargo fueron ignorados y al final contaminacion cobro una fuerza descomunal y destruyo todo…",
                "LuxTerra: Así es muchacho, Contaminación ha esperado por milenios para romper el equilibrio natural y alimentar el caos que porta, al final hace 20 años lo logro… Sin embargo no todo está perdido, supongo que también sabes del origen de los tesoros de los guardianes.",
                "Einar: Por lo que me han y me has contado, solo se que existe una espada legendaria que nació del fuego y se perdió entre la tierra.",
                "LuxTerra: Naci del fuego o más bien, fui creada del fuego de la tierra por la esencia de la naturaleza… Hace más de 20 años cuando el caos estaba cerca, la naturaleza premio a dos guardianes por su luchar incansable y su amor inconmensurable por la vida en el mundo, los convirtió en seres trascendentales denominados Guardianes de las Energías, uno de ellos representa a la energía de la tierra, el otro a la energía del sol.",
                "LuxTerra: Asi mismo les entrego a cada uno un tesoro, yo fui entregado a Feanor, Guardián de la Tierra; el tesoro del sol Sidus, fue entregado a Lena, la Guardiana del Sol.",
                "LuxTerra: La naturaleza al entregarles los tesoros también les dio una profecía: Al pasar las décadas una nueva luz se levantara en la humanidad, su propio brillo le permitirá llegar a los tesoros que os he encomendado y la vida volverá nuevamente al mundo.",
                "LuxTerra: Einar, eres la esperanza de este mundo, debes ayudarme a encontrar a mi Guardián antes de que se entregado a Contaminación, lo necesitamos para poder enfrentar a ese monstruo. Siento que está cerca… en algún lugar de estos pasillos.",
                "Einar: Esta bien, vamos!!"

            };
            
        }
        //Cuando llegan a las trampas
        else if (triggerAc == 2)
        {
            texto = new string[] 
            {
                "Einar: ¿Trampas?, esto cada vez se pone mas raro y siniestro"
            };
        }
        //En la sala de la secuencia de botones
        else if (triggerAc == 3)
        {
            texto = new string[]
            {
                "LuxTerra: Estas son Runas, tomala, puede que la necesitemos"
            };
        }
        //Subiendo las escaleras luego de armas la secuencia
        else if (triggerAc == 4)
        {
            texto = new string[]
            {
                "Einar: Parecen ser botones, supongo debo hacer algo aqui para poder pasar al otro lado"
            };
        }
        //Entrando al laberinto despues del punto de Guardado
        else if (triggerAc == 5)
        {
            texto = new string[]
            {
                "Einar: Bien logre salir, ¿y ahora que sigue?... Parece ser un laberinto. A ver a donde llego"
            };
        }
        
        //En la puerta del Templo Geotermico
        else if (triggerAc == 6 && GetComponent<PropiedadesScript>().runas == 4)
        {
            texto = new string[]
            {
                "Einar: Bien las runas me permitieron abrir la puerta"
            };
        }
        //Poco despues de la mitad del pasillo a la puerta del tiempo
        else if (triggerAc == 7)
        {
            texto = new string[]
            {
                "Einar: Que extraño, parece la entrada a un templo..." 
            };
        }
        //Al entrar al Templo
        else if (triggerAc == 8)
        {
            GetComponent<TranslationMovement>().FinishMovement();
            GetComponent<TranslationMovement>().enabled = false;
            GetComponent<Animator>().SetInteger("Estado", 0);
            texto = new string[]
            {
                "Einar: Pero que demonios es eso!!",
                "LuxTerra: Es el destructor que atrapo a Feanor, ¡Mira al fondo, alla esta feanor!",
                "Einar: ¡Mira al fondo, alla esta alguien atrapado!",
                "LuxTerra: Al fin, es Feanor, debes derrotar al destructor para liberarlo",
                "Einar: Hoy me siento mas valiente de lo normal... Vamos!!!"
            };
        }
        //Al romperse el escudo del Enemigo y acercarse a la puerta de la prision de Feanor
        else if (triggerAc == 9)
        {
            texto = new string[]
                {
                    "Carcelero: No puede ser, quien es este humano",
                    "Einar: Que monstruo mas complicado!",
                    "Einar: ¿Una llave?, si este es un carcelero, esta debe abrir la prsion del Guardián  "
                };
        }
        //Finalizacion de batalla con el Carcelero Geotermico
        else if (triggerAc == 11)
        {
             
        }
        //Acercandose a la llave
        else if (triggerAc == 12)
        {

        }
        //Conversacion con feanor
        else if (triggerAc == 13)
        {
            texto = new string[]
            {
                "Feanor: Gracias, me han salvado, desde aquella gran catástrofe he estado muy débil, dormido durante muchos años, y ese Carcelero me encontró y me atrapo hace poco tiempo, y estaba esperando el momento para llevarme con Contaminación… ",

                "Sigurd: Feanor, Guardián de la energía Geotérmica, necesitamos ayuda para acabar con esto.",

                "Feanor: Deseo lo mismo, pero… ¿Quién es ese muchacho?",

                "Einar: Soy Einar, un habitante de la sociedad subterránea, la que es por lo que me cuenta Sigurd, el último bastión de la humanidad, estoy aquí para defender esa última esperanza, quiero que me ayuden a derrotar a Contaminación.",

                "Sigurd: Es un muchacho muy decidido… Tengo mis esperanzas puestas en él desde que lo conocí.",

                "Feanor: Sigurd, confió en tu juicio, si decidiste confiar en este muchacho es porque ves algo muy importante, los ayudare.",
                "Feanor: Muchacho, como sabrás, estamos muy débiles y por ello solo podemos ofrecerte las herramientas mientras ponemos nuestra completa confianza en ti.",
                "Feanor: Debo pedirte algo muy importante, el Guardián de la Energía Solar está en una condición igual a la que yo estaba hace un momento, debes liberarlo antes de que sea entregado a Contaminación. ",
                "Su ayuda es fundamental para poder derrotar a ese mal que azota el mundo.",
                "Feanor: Para ello te dejo como regalo esa espada y te entrego esta llave, una de tres necesarias para poder abrir la puerta que libera a tu pueblo… ",
                "Si, puedo sentirlos y se de una salida para ellos, la cual veras en medio de las escaleras hacia la superficie.",
                "Sal por el camino a tu izquierda y avanza recto, luego usa la espada para destruir el muro que veras al fondo, podrás ver las escaleras de que te hablo.",
                "Feanor: Ten mucho cuidado, allá afuera enfrentaras muchos peligros, y recuerda, solo con la ayuda de Lena, la Guardiana de la Energía Solar, podremos enfrentar a Contaminación.",
                "Feanor: En la salida a la superficie podrás encontrar un brazalete sagrado que dispara cargas solares, el cual perteneciente a Lena,",
                "mientras no llegues a donde esta ella, las cargas que podrás usar son limitadas, úsalas sabiamente.",
                "Feanor: Ahh, por cierto, deberás recargar tu espada, y eso solo podrás hacerlo conmigo lo cual lo puedo hacer sin cargo alguno o en la forja, siendo en la forja necesarias rocas de lava. ",
                "De la misma forma también serán necesarias rocas de lava para mejorarla ya sea conmigo o en la forja. Mientras no desenvaines tu espada esta no perderá su energía.",
                "Feanor: Yo no podre acompañarte ya que me quedare recuperando mi fuerza para cuando llegue el momento, pero si me necesitas ven a buscarme. ",
                "Feanor: ¡Mucha suerte en tu misión!. ",

                "Sigurd: Muchas gracias Feanor.",

                "Einar: No te fallare."
            };
        }
        //Saliendo del templo del Sol
        else if (triggerAc == 14)
        {
            texto = new string[]
            {
                "Sigurd: Mira, volvimos al principio.",
                "Sigurd: Y pensar que estaba tan cerca…",
                "Sigurd: Vamos"
            };
        }
        //Frente al muro de las escaleras
        else if (triggerAc == 15)
        {
            texto = new string[]
            {
                "Sigurd: Golpéalo con la espada",
                //Luego de romper el muro
                "Sigurd: Bien, ahí están las escaleras, vamos."
            };
        }
        else if (triggerAc == 16)
        {
            texto = new string[]
            {
                "Sigurd: Mira, ahí está la puerta de la que hablaba Feanor… Por ahora no podrás abrirla, necesitas tres llaves… Debemos seguir."
            };
        }
        else if (triggerAc == 17)
        {
            texto = new string[]
            {
                "Sigurd: Ahh hace tanto que no veo la superficie, tengo curiosidad… Aunque no espero que este nada bien."
            };
        }
    }
}
