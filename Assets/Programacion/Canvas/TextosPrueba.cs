using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextosPrueba : MonoBehaviour
{
    //Se le asigna el panel y el texto de dialogos en el inspector
    public Text Dialogos;
    public GameObject Panel;

    //Esta variable indicara el trigger de dialogo en el que entro el personaje, y sera usado en la funcion Dialogar()
    int triggerAc;

    //Este estring se llenara con los dialogos. esto se hara en la funcion Dialogar()
    string[] texto;

    //Es un array de objetos el cual se llenara con los triggers que se van a usar para los dialogos, se hara desde el inspector
    public GameObject[] triggers;

    //Esta variable es alternativa de mi codigo. Innecesaria
    GameObject CarceleroGeo;

    //Variables del ciclo for anidado que muestra los dialogos en la corrutina(i , s)
    int i;
    int s;

    //Booleano para la activacion del paso de dialogos
    bool next;
    bool habilitar;

    //Inicia el objeto panel desactivado
    void Start()
    {
        Panel.SetActive(false);
        CarceleroGeo = GameObject.Find("CarceleroGeo");
        next = true;
        // Seccion de deshabilitacion de triggers
        habilitar = true;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && i < texto.Length)//Si se oprime Q y en la corrutina MostrarDialogos(), i es menor al valor de la longitud del array texto[]
        {
            if (s == texto[i].Length)//Si s es igual a la longitud de la posicion i del arreglo texto, incrementa i
            {
                i++;
            }
            s = texto[i].Length-1;//s=longitud de la posicion i-1 del array texto[]
            Dialogos.text = texto[i];//Mostrar texto completo de la posicion i
        }
        EnableTriggers();
    }

    //Esta corrutina muestra los dialogos bajo restricciones de tiempo en segundos
    IEnumerator MostrarDialogos()
    {
        int trig = triggerAc;
        Panel.SetActive(true);//Activa panel de dialogos
        yield return new WaitForSeconds(0.5f);
        int total = texto.Length;//se le asigna el tamaño del array texto a la variable total
        yield return null;//Seguridad de un null
        for (i = 0; i < total; i++)//Recorremos todas las frases
        {
            string res = "";
            for (s = 0; s < texto[i].Length; s++)//Recorremos char por char esa frase
            {
                res = string.Concat(res, texto[i][s]);//Concatena letra por letra en la variable res
                Dialogos.text = res;//Muestra las letras concatenadas
                yield return new WaitForSeconds(0.5f * Time.deltaTime);
            }
            yield return new WaitForSeconds(3f);
        }
        GetComponent<TranslationMovement>().detention = false;//Esto reactiva los movimientos del personaje, funcion propia de lost energy
        Dialogos.text = "";//Vacia el texto
        yield return new WaitForSeconds(0.5f);
        Panel.SetActive(false);//Deasactiva el panel de dialogos
        next = true;
    }

    //##################### Validacion de Triggers ##########################
    void OnTriggerStay(Collider Other)
    {
        if (next)
        {
            for (int j = 0; j < triggers.Length; j++)//Recorre el array de triggers
            {
                if (Other.name == triggers[j].name)//Si el nombre del objeto en el que personaje entro es igual al del array trigger en su posicion j, ejecuta
                {
                    triggerAc = j;//Como j arranca de cero y triggerAc funciona desde 1, entonces se le asigna el valor j+1
                    Dialogar();
                    StartCoroutine(MostrarDialogos());
                    break;
                }
            }
        }
    }
    //##################### Escritura de Dialogos ###########################
    void Dialogar()//Se asignan los dialogos al array segun la variable triggerAc
    {
        //Dialogo con LuxTerra al encontrarla.
        if (triggerAc == 0)
        {
            GetComponent<TranslationMovement>().DialogDetention();//funciones lost energy(Desactiva movimientos), no funciona bien
            texto = new string[]
            {
                "Einar: ¡¿Qué es esto?!, de repente esa espada llameante salto a mi espalda, pensé que me quemaría, pero… Se siente una energía increíble en mi cuerpo...",
                "Espada: 'LuxTerra, Luz de la tierra es mi nombre y tú eres mi destino'",
                "Einar: ¿Que acabo de escuchar en mi mente? …El sable?… esta espada…",
                "LuxTerra: Joven guerrero, no temas, el destino te ha elegido para portar los tesoros de los guardianes…", 
                "Y la misión de recuperar el mundo que hace 20 años se perdió por los errores de tus antepasados… En este sable esta la esencia viva de la tierra misma, porta su energía, y su poder, como ya tú mismo lo pudiste sentir.",
                "Einar: Es increíble… Mi padre me contaba que en el pasado la humanidad estaba llena de codicia y consumismo, destruían la naturaleza solo pensando en sí mismos, y esto alimentaba a la esencia del caos, a Contaminación…",
                "Einar: Sin embargo, entre ellos había personas que luchaban incansablemente para hacer entender a la humanidad el daño que estaban haciendo",
                "sin embargo, fueron ignorados y al final contaminación cobro una fuerza descomunal y destruyo todo…",
                "LuxTerra: Así es muchacho, Contaminación ha esperado por milenios para romper el equilibrio natural y alimentar el caos que porta, al final hace 20 años lo logro…", 
                "Sin embargo, no todo está perdido, supongo que también sabes del origen de los tesoros de los guardianes.",
                "LuxTerra: Hace más de 20 años cuando el caos estaba cerca, la naturaleza premio a dos guardianes por su luchar incansable y su amor inconmensurable por la vida en el mundo", 
                "los convirtió en seres trascendentales denominados Guardianes de las Energías, uno de ellos representa a la energía de la tierra, el otro a la energía del sol.",
                "LuxTerra: les entrego a cada uno un tesoro, yo fui entregado a Feanor, el Guardián de la Tierra, y el tesoro del sol Sidus, fue entregado a Lena, la Guardiana del Sol.",
                "LuxTerra: y les dejo esta profecía: Al pasar las décadas una nueva luz se levantará en la humanidad, su propio brillo le permitirá llegar a los tesoros que os he encomendado y la vida volverá nuevamente al mundo.            ",
                "LuxTerra: Einar, eres la esperanza de este mundo, debes ayudarme a encontrar a mi Guardián antes de que se entregado a Contaminación", 
                "lo necesitamos para poder enfrentar a ese monstruo. Siento que está cerca… en algún lugar de estos pasillos.",
                "Einar: Esta bien, ¡vamos!"
            };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }
        //Cuando llegan a las trampas
        else if (triggerAc == 1)
        {
            texto = new string[] 
            {
                "Einar: ¿Trampas?, esto cada vez se pone más raro y siniestro"
            };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }
        //En la sala de la secuencia de botones
        else if (triggerAc == 2)
        {
            texto = new string[]
            {
                "LuxTerra: Estas son Runas, tómala, puede que la necesitemos"
            };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }
        //Subiendo las escaleras luego de armas la secuencia
        else if (triggerAc == 3)
        {
            texto = new string[]
            {
                "Einar: Parecen ser botones, supongo debo hacer algo aquí para poder pasar al otro lado"
            };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }
        //Entrando al laberinto despues del punto de Guardado
        else if (triggerAc == 4)
        {
            texto = new string[]
            {
                "Einar: Bien logre salir, ¿y ahora qué sigue?... Parece ser un laberinto. A donde llegare..."
            };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }
        
        //En la puerta del Templo Geotermico
        else if (triggerAc == 5)
        {
            texto = new string[]
            {
                "Einar: Bien las runas me permitieron abrir la puerta"
            };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }
        //Poco despues de la mitad del pasillo a la puerta del tiempo
        else if (triggerAc == 6)
        {
            GetComponent<TranslationMovement>().DialogDetention();
            texto = new string[]
            {
                "Einar: Que extraño, parece la entrada a un templo..." 
            };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }
        //Al entrar al Templo
        else if (triggerAc == 7)
        {
            GetComponent<TranslationMovement>().DialogDetention();
            texto = new string[]
            {
                "Einar: ¡Pero qué demonios es eso!",
                "LuxTerra: Es el destructor que atrapo a Feanor, ¡Mira al fondo, allá esta Feanor!",
                "Einar: ¡Mira al fondo, allá esta alguien atrapado!",
                "LuxTerra: Al fin, es Feanor, debes derrotar al destructor para liberarlo",
                "Einar: ¡Hoy me siento más valiente de lo normal... Vamos!"

            };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }
        //Al derrotar al carcelero
        else if (triggerAc == 8 && CarceleroGeo.GetComponent<EnemyLife>().life < 1)
        {
            GetComponent<TranslationMovement>().DialogDetention();
            texto = new string[]
            {
                "Carcelero: No puede ser, quien es este humano",
                "Einar: Con que estos son los servidores de contaminación, ¡¡son unos demonios!!",
                "Einar: ¡Debo ir a liberar al Guardián!"
            };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }
        //Al acercarse a la puerta con la llave
        else if (triggerAc == 9)
        {
            GetComponent<TranslationMovement>().DialogDetention();
            texto = new string[]
           {
                "Einar: ¡Siento que puedo abrirla con solo tocarla!",
                "LuxTerra: La puerta se mantiene cerrada por la fuerza de las energías no renovables, la pureza de las energías renovables que ahora portas, hace que puedas hacerlo"
           };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }
        //Conversacion con el guardian
        else if (triggerAc == 10)
        {
            GetComponent<TranslationMovement>().DialogDetention();
            texto = new string[]
           {
                "Feanor: Es increíble, derrotaste a ese monstruo tu solo... Y me has salvado, te agradezco mucho",
                "Feanor: Pude ver que portas a LuxTerra. Tú eres el joven guerrero que he esperado por tantos años.",
                "Einar: ¿Tu eres el guardián del que me ha estado hablado LuxTerra?",
                "Feanor: Así es muchacho, yo soy Feanor, el guardián de la Energía Geotérmica",
                "Feanor: Te he escuchado a través de LuxTerra, eres Einar, un descendiente de los humanos que habitan bajo la tierra en las cercanías",
                "Feanor: Es un placer poder verte en persona al fin, y saber que vale la pena confiar en ti, tienes muchas agallas",
                "Feanor: Escúchame:",
                "Feanor: Desde hace 20 años la guardiana del sol y yo, hemos sido perseguidos por los destructores de Contaminación",
                "Feanor: Ella y yo como guardianes de las energías somos los protectores de la vida, por eso desean acabar con nosotros",
                "Feanor: Pero desafortunadamente nuestra fuerza no es suficiente para enfrentarle solos",
                "Feanor: Sin embargo, para ello estas tú, eres quien puede usar el poder completo de los tesoros", 
                "ya que tu corazón no está lleno de ambición y maldad, y tu sangre porta la conexión con la naturaleza y la vida",
                "Feanor: Eres quien nace de la naturaleza para protegerla",
                "Feanor: Al fin estas aquí, pero no puedo retenerte más, debes seguir tu misión, yo tratare de apoyarte en tu misión alimentando la energía de tu espada a través de los árboles de vida en la superficie",
                "Einar: ¿Superficie?, pero como iré allá, además, siempre me han dicho que no podemos volver allá",
                "Einar: Que desde que todo aquello sucedió es un lugar lleno de muerte",
                "Feanor: Lo sé, es de Contaminación de quien hablas, la superficie esta poseída por ella, pero debes ir, el tiempo se agota, los recursos que quedan cada vez son menos",
                "Feanor: La esencia de la naturaleza aún sigue presente, debes evitar que desaparezca por completo o no habrá vuelta atrás, la vida de tu mundo está en tus manos",
                "Einar: Pero... ¡¿Que debería hacer yo?!",
                "Feanor: Sal de este templo, vuelve por donde viniste, cuando lo veas sabrás cuál es tu camino",
                "Feanor: Cuando llegues a la superficie encuentra el amuleto de Lena, con el tendrás la fuerza suficiente para derrotar a tus enemigos",
                "Feanor: Ese amuleto porta la energía solar, es aquella energía que alimento la vida de la humanidad por milenios, una energía muy pura y poderosa, te llenara de fuerzas",
                "Feanor: Luego los tesoros te guiaran en tu misión",
                "Feanor: ¡Ve Guardián!",
                "Einar: ¡Lo hare, protegeré este mundo!"
           };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }
        //Conversacion con feanor
        else if (triggerAc == 11)
        {
            texto = new string[]
            {
                "Einar: Había unas piedras allí, creo es a lo que se refería Feanor, debo ir por aquellas escaleras, y llegare a la superficie"
            };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }
    }


    bool a = true;
    bool b = true;
    bool c = true;
    void EnableTriggers()
    {
        if (habilitar)
        {
            triggers[5].GetComponent<Collider>().enabled = false;
            triggers[8].GetComponent<Collider>().enabled = false;
            triggers[9].GetComponent<Collider>().enabled = false;
            triggers[11].GetComponent<Collider>().enabled = false;
            habilitar = false;
        }

        else if (CarceleroGeo.GetComponent<EnemyLife>().life < 1 && a)
        {
            triggers[8].GetComponent<Collider>().enabled = true;
            triggers[9].GetComponent<Collider>().enabled = true;
            triggers[11].GetComponent<Collider>().enabled = true;
            a = false;
        }

        else if (GetComponent<PropiedadesScript>().runas == 4 && b)
        {
            triggers[5].GetComponent<Collider>().enabled = true;
            b = false;
        }
    }
}
