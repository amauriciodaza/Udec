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
            s = texto[i].Length-1;
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
        //Inicio
       /* if (triggerAc == 1)
        {
            texto = new string[] 
            {
                "Einar: A donde he llegado, que es este lugar tan extraño, nunca había visto una mina como esta.",
                "Einar: Que es eso… Un… Se parece un humano.",
                "Einar: Que extraño, está dormido, y atrapado entre esos cristales.",
                "Einar: Voy a tratar de romper ese cristal."
            } ;
        }*/
        //Conversacion con Sigurd cuando este Despierta
        if (triggerAc == 1)
        {
            texto = new string[] 
            {
                //"Sigurd: (Despertando) ¿Qué es esto?, ¿Cuánto llevo aquí?...",
                "Sigurd: ¿Quién eres tú?... Eres un humano, pensé que Contaminación los había destruido a todos.",

                "Einar: Ósea que es verdad, mi abuelo me había contado una historia, me dijo que hace muchos años los humanos vivían en un mundo muy diferente, ",
                "uno en el que había algo llamado cielo, donde no teníamos que usar antorchas para poder ver,",
                "en donde los días eran mitad llenos de luz, iluminados por un lucero inmenso e inalcanzable al que llamaban sol,",
                " y que al dormirse este es su reemplazo llegaba un lucero menos brillante pero no menos hermoso, el que llamaban luna,",
                "el cual cambiaba de forma continuamente y que en la mitad oscura del día, junto con incontables y pequeñas luces te acompañaba a esta el despertar del sol, un mundo donde habían vientos frescos e interminables… ",
                "Podías ver bastas ciudades de torres inmensas y algo que llamaban bosques llenos de plantas enormes donde podías perderte… Siempre pensé que eran solo historias.",
                
                "Einar: Me llamo Einar, y este es el año 2470, o eso dice el viejo de los relojes.",

                "Sigurd: Ohh entiendo, Pero… No estamos en la superficie, esto es, una mina… ",

                "Einar: Por estos lados se le conoce como la Sociedad Subterránea.",

                "Sigurd: Ahora entiendo por qué siguen vivos, llevan más de 400 años viviendo bajo la tierra, llevan 400 años atrapados aquí en su propio castigo por crear a ese ente maldito llamado Contaminación.",

                "Einar: ¿Qué es Contaminación?",

                "Sigurd: En el pasado, cuando tu civilización aún estaba en la superficie, que es a lo que te referías con lo que me dijiste, esta estaba en el pico de su desarrollo, su crecimiento parecía ilimitado,",
                "ellos crearon maquinas e instalaciones con el objetivo de satisfacer sus necesidades, pero no solo eso, estaban llenos de codicia,",
                " esa naturaleza hermosa de la que hablaban la destruían en nombre de crear esas máquinas e instalaciones,",
                "todos estos sucesos y creaciones hacían mucho más fácil todo para los humanos, sin embargo estas generaban residuos en las cantidades enormes dada la cantidad descomunal de humanos, comenzó a intoxicar la naturaleza,",
                "las fuentes de energías que esas creaciones usaban, generaban estos residuos los cuales se acumulaban en diferentes formas y lugares y al final la misma naturaleza colapso, ",
                "y se creó este ente llamado contaminación el cual es la representación de la decadencia. ",
                "Este ente odia la vida, es la destrucción y desolación en sí mismo, ataco a todos los seres vivos de la superficie, los humanos no fueron la excepción, de hecho fueron el blanco de Contaminación, ",
                "todas y cada una de las ciudades de la humanidad cayeron y hasta ahora ustedes son los únicos sobrevivientes que veo.",

                "Einar: ¿Entonces los humanos fuimos los culpables de todo?",

                "Sigurd: Así es, todo se destruyó debido a su codicia y deseo de poder… ",
                "Creyeron que este mundo era suyo, nada más alejado de la realidad, ustedes solo son una fracción del tiempo, materia y espacio de un universo implacable y lleno de caos,",
                "en donde este mundo es un paraíso… Y ustedes los únicos culpables de la decadencia de su propio hogar.",

                "Sigurd: En el pasado existieron seres trascendentales que representaban las esencias de la naturaleza. Cada uno de ellos fue destruido por Contaminación, solo quedan dos de ellos, que ",
                "representan a la energía del Sol y de la Tierra, estos quedaron dormidos debido a la afección natural que causo Contaminación.",

                "Sigurd: Debemos despertarlos y ayudarles a recuperar su poder… Tal vez con la ayuda de ellos lograremos vencer a Contaminación y recuperar el mundo. ¿Estás conmigo?",
                "Einar: Si realmente fue nuestra culpa, debo ayudar a cambiar esto, quiero llevar a mi pueblo a ese mundo increíble que me relataba mi abuelo.",

                "Sigurd: Entonces lo haremos juntos. Yo estoy muy débil, no puedo enfrentarme a los peligros y dificultades solo. Entonces solo podre guiarte.",

                "Sigurd: Debemos buscar al guardián de la energía Geotérmica, siento que está muy cerca."
            };
        }
        //Cuando llegan a las trampas
        else if (triggerAc == 2)
        {
            texto = new string[] 
            {
                "Sigurd: ¿Qué es esto?, ¡Son Trampas!, Einar, debes ser muy cuidadoso al pasar."
            };
        }
        //En la sala de la secuencia de botones
        else if (triggerAc == 3)
        {
            texto = new string[]
            {
                "Sigurd: Oh no, este piso era falso, debemos buscar una forma de salir.",
                "Sigurd: Eso de allá es… Es una Runa Geotérmica, tómala, probablemente nos va a servir de mucho.",
                "Sigurd: Einar, parece haber un mecanismo, y aquí hay una especie de secuencia."
            };
        }
        //Subiendo las escaleras luego de armas la secuencia
        else if (triggerAc == 4)
        {
            texto = new string[]
            {
                "Sigurd: Bien hecho, logramos salir, ahora debemos continuar, debemos seguir moviéndonos por estos túneles."
            };
        }
        //Entrando al laberinto despues del punto de Guardado
        else if (triggerAc == 5)
        {
            texto = new string[]
            {
                "Sigurd: Esto… ¿Parece ser un laberinto?, ahh lo que faltaba, debemos entrar y ver a donde logramos llegar, debemos estar atentos para no perdernos"
            };
        }
        //Al recoger las Runas **Debemos colocar un condicional para que este codigo se ejecute mientras no se hayan encontrado todas las runas
        else if (triggerAc == 6)
        {
            texto = new string[]
            {
                "Sigurd: Otra runa más!!"
            };
        }
        //En la puerta del Templo Geotermico
        else if (triggerAc == 7)
        {
            //Si aun no esta abierta
            bool puerta = false;// Si implementamos GetComponent con un booleano en el codigo de la puerta quedaria listo

            if (puerta == false)
            {
                texto = new string[]
                {
                    "Sigurd: Parece ser que… las runas son las piezas que faltan en el Mecanismo para abrir la puerta.",
                    "Sigurd: Aun nos faltan algunas Runas."
                };
            }
            //Si ya se abrio
            else
            {
                texto = new string[]
                {
                    "Sigurd: Ohh se ha abierto la puerta, esto parece ser… Una especie de templo, tengo un buen y un mal presentimiento sobre esto."
                };
            } 
        }
        //Poco despues de la mitad del pasillo a la puerta del tiempo
        else if (triggerAc == 8)
        {
            texto = new string[]
            {
                "Sigurd: Mira, una sala y allá parece haber un ser… Extraño"
            };
        }
        //Al entrar al Templo
        else if (triggerAc == 9)
        {
            texto = new string[]
            {
                "Sigurd: Oh no, es uno de los grandes servidores de Contaminación, El Carcelero Geotérmico, debemos salir de aquí…",
                "Sigurd: No puede ser, la entrada esta sellada… Einar, debes derrotarlo.",
                "Einar: Ggggg, ¡Lo intentare, pero es un oponente muy complicado!"
            };
        }
        //Al romperse el escudo del Enemigo y acercarse a la puerta de la prision de Feanor
        else if (triggerAc == 10)
        {
            texto = new string[]
            {
                "Feanor: ¡Humano!, Toma esta espada, te servirá para derrotarlo"
            };
        }
        //Finalizacion de batalla con el Carcelero Geotermico
        else if (triggerAc == 11)
        {
            bool CarceleroG = false;//con un GetComponent podemos terminarlo
            if (CarceleroG)
            {
                texto = new string[]
                {
                    "Carcelero: Así que aún quedan humanos, es hora de terminar con esto.",
                    "Sigurd: ¡Ohh no!, hemos fallado."
                };
            }
            else
            {
                texto = new string[]
                {
                    "Carcelero: No puede ser, quienes son… Sigurd?, aun sigues vi-vo…",
                    "Sigurd: No creí que pudiéramos con este monstruo…",
                    "Einar: Que falta de fe",
                    "Sigurd: Lo siento... Ufff!! Aun sigo sorprendido"
                };
            } 
        }
        //Acercandose a la llave
        else if (triggerAc == 12)
        {
            texto = new string[]
            {
                "Sigurd: Mira Einar, el Carcelero dejo caer una llave, puede que con ella liberemos al guardián."
            };
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
