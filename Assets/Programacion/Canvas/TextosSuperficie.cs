using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextosSuperficie : MonoBehaviour
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
            s = texto[i].Length - 1;//s=longitud de la posicion i-1 del array texto[]
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
                yield return new WaitForSeconds(0.1f * Time.deltaTime);
            }
            yield return new WaitForSeconds(0.5f);
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
                "Einar: ¡Es!... ¡impresionante!... ¿Esto es la superficie?, no me la imaginaba asi, si me dijeron que era muy bonito, pero es totalmente diferente",
                "LuxTerra: Antes era mas bello, era maginifico, esto es solo destruccion",
                "Einar: Si esto son solo ruinas y desastre entonces la belleza de antes era infinita",
                "LuxTerra: sin embargo tus antepasados no supieran valorar nada, y este es el resultado",
                "LuxTerra: Eso de alla es... ¡Es el tesoro del Sol!"
            };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }
        //Cuando llegan a las trampas
        else if (triggerAc == 1)
        {
            GetComponent<TranslationMovement>().DialogDetention();
            texto = new string[]
            {
                "Brazalete: 'Signus, la estrella del norte'...",
                "Einar: Es igual que con la espada...",
                "Signus: Ahora hago parte de tu energia, estoy vinculado a tu esencia... Igual que LuxTerra a quien portas en tu espalda",
                "Signus: Einar, ya sabras esto, pero tu eres quien ha sido esperado por decadas, aquel que puede salvar este mundo",
                "Signus: Yo te guiare en este lugar, y te hare mas fuerte a travez de la energia del Sol, de la que soy portador, y ahora hace parte de ti",
                "Signus: Mi guardiana descubrio algo importante respecto a Contaminacion, pero la energia que porta quien la tiene capturada no permite conectar con sus pensamientos",
                "Signus: Debes ayudarme a salvarla Einar. Esta muy cerca de aqui, tendras que enfrentar muchos obstaculos, pero confio en que lo lograras",
                "Einar: Lo hare!",
                "Signus: Entonces vamos"
            };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }
        //En la sala de la secuencia de botones
        else if (triggerAc == 2)
        {
            GetComponent<TranslationMovement>().DialogDetention();
            texto = new string[]
            {
                "Signus: Mira, esos son enemigos... Los soladados de contaminacion, aquel de color negro te atacara a distancia, debes tener cuidado los de ese tipo, no son faciles de eliminar",
                "Signus: Y aquel otro con esas enormes garras te tratara de destrozar a golpes y te perseguira, debes ser rapido para enfrentarlo",
                "Einar: Se ven bastante problematicos, sin embargo siento esta energia que ahora fluye en mi cuerpo... es como si fuera aun mas fuerte",
                "Signus: Y asi es Einar, ahora con las dos energias juntas tu fuerza esta completa",
                "Signus: Vamos a derrotarlos!!... Aunque si sientes que no puedes mas alejate y encuentra un arbol, te ayudara a sanar tus heridas y recuperar tus energias",
                "Einar: Bien, derrotaremos a contaminacion y sus monstruos... ¡Corregire los errores de mis antepasados!"
            };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }
        //Subiendo las escaleras luego de armas la secuencia
        else if (triggerAc == 3)
        {
            texto = new string[]
            {
                "Signus: Esta es una buena oportunidad de que entiendas mi poder... Yo te permitire atacar a distancia, asi:",
                "Signus(Instrucciones): Presiona Click Derecho en tu mouse para apuntar, luego Click Izquierdo para disparar, si deseas cancelar el ataque vuelve a presionar Click Derecho, ahora intentalo"
            };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }
        //Entrando al laberinto despues del punto de Guardado
        else if (triggerAc == 4)
        {
            texto = new string[]
            {
                "Einar: Que bien, es un arbol, podre recuperar la energia de LuxTerra y mis fuerzas"
            };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }

        //En la puerta del Templo Geotermico
        else if (triggerAc == 5)
        {
            texto = new string[]
            {
                "Einar: Oo o ohh ... Que.. Esta torreee, ¡es enorme!",
                "Signus: Debes subir para poder llegar al templo, pero debes observar bien, en esta torre hay runas que necesitaras para , debes obtenerlas"
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
                "Einar: Pero que demonios es eso!!",
                "LuxTerra: Es el destructor que atrapo a Feanor, ¡Mira al fondo, alla esta feanor!",
                "Einar: ¡Mira al fondo, alla esta alguien atrapado!",
                "LuxTerra: Al fin, es Feanor, debes derrotar al destructor para liberarlo",
                "Einar: Hoy me siento mas valiente de lo normal... Vamos!!!"
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
                "Einar: Con que estos son los servidores de contaminacion, ¡son unos demonios!",
                "Einar: ¡Debo ir a liberar al Guardian!"
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
                "Einar: Siento que puedo abrirla con solo tocarla!!",
                "LuxTerra: La puerta se mantiene cerrada por la fuerza de las energias no renovables, la pureza de las energias renovables que ahora portas, hace que puedas hacerlo"
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
                "Feanor: Es increible, derrotaste a ese monstruo tu solo... Y me has salvado, te agradezco mucho",
                "Feanor: Pude ver que portas a LuxTerra. Tu eres el joven guerrero que he esperado por tantos años.",
                "Einar: ¿Tu eres el guardian del que me ha estado hablado LuxTerra?",
                "Feanor: Asi es muchacho, yo soy Feanor, el guardian de la Energia Geotermica",
                "Feanor: Te he escuchado a travez de LuxTerra, eres Einar, un descendiente de los humanos que habitan bajo la tierra en las cercanias",
                "Feanor: Es un placer poder verte en persona al fin, y saber que vale la pena confiar en ti, tienes muchas agallas",
                "Einar: Que!... Osea que la puedes oir a la espada sin necesidad de que este contigo?",
                "Feanor: Esa espada esta basada en la energia geotermica, la energia de la tierra, y yo soy su guardian, nuestra esencia esta vinculada",
                "Einar: Sorprendente!",
                "Feanor: Ahora es tu espada, tu eres su portador, su maestro y ella tu guia, y su mision salvar a este mundo",
                "Feanor: Escuchame:" ,
                "Feanor: Desde hace 20 años la guardiana del sol y yo, hemos sido perseguidos por los destructores de Contaminacion",
                "Feanor: Ella y yo como guardianes de las energias somo los protectores de la vida, por eso desean acabar con nosotros",
                "Feanor: Pero desafortunadamente nuestra fuerza no es suficiente para enfrentarle solos",
                "Feanor: Sin embargo por ello estas tu, eres quien puede usar el poder completo de los tesoros, ya que tu corazon no esta lleno de ambicion y maldad, y tu sangre porta la conexion con la naturaleza y la vida",
                "Feanor: Eres quien nace de la naturaleza para protegerla",
                "Feanor: Al fin estas aqui, pero no puedo retenerte mas, debes seguir tu mision, yo tratare de apoyarte en tu mision alimentando la energia de tu espada a travez de los arboles de vida en la superficie",
                "Einar: Superficie?, pero como ire alla, ademas, siempre me han dicho que no podemos volver alla",
                "Einar: Que desde que todo aquello sucedio es un lugar lleno de muerte, el caos que la misma humanidad alimento con su ambicion e irresponsabilidad se convirtio en la esencia de la muerte misma",
                "Einar: Cualquiera que vaya alla no llegara muy lejos",
                "Feanor: Lo se, es de Contaminacion de quien hablas, la superficie esta poseida por ella, pero debes ir, el tiempo se agota, los recursos que quedan cada vez son menos",
                "Feanor: La esencia de la naturaleza aun sigue presente, debes evitar que desaparezca por completo o no habra vuelta atras, la vida de tu mundo esta en tus manos",
                "Einar: Pero... ¡¿Que deberia hacer yo?!",
                "Feanor: La energia que en este momento emanas es muy poderosa, tu conexion con la espada tiene una sinergia perfecta, tu esencia y la de la espada se hacen una misma",
                "Feanor: Esa energia que emana de ti es limpia y llena de vida, debes derrotar a los monstruos que habitan en la superficie, debes limpiar el mundo",
                "Feanor: A medida que vayas derrotando a los servidores de Contaminacion, la naturaleza empezara a recobrar fuerza, esos seres consumen la vida, son la encarnacion de aquel deseo en los humanos que creo a Contaminacion",
                "Einar: ¿Osea que los monstruos que atacan a mi pueblo son la forma de la maldad humana?, ese deseo de poder y placer que destruyo todo para su propia conveniencia",
                "Feanor: Asi es, esos monstruos nacieron del corazon de la humanidad misma, el corazon de los humanos primo el placer sobre la vida, usaron energias que dañaron la naturaleza, y el resultado de ello se hizo una calamidad tomo vida",
                "Einar: ¿Y entonces como lo hago?",
                "Feanor: Sal de este templo, vuelve por donde viniste, cuando lo veas sabras cual es tu camino",
                "Feanor: Cuando llegues a la superficie encuentra el amuleto de Lena, con el tendras la fuerza suficiente para derrotar a tus enemigos",
                "Feanor: Ese amuleto porta la energia solar, es aquella energia que alimento la vida de la humanidad por milenios, una energia muy pura y poderosa, te llenara de fuerzas",
                "Feanor: Luego los tesoros te guiaran en tu mision",
                "Feanor: Ve Guardian!!",
                "Einar: Lo hare, protegere este mundo!!"
           };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }
        //Conversacion con feanor
        else if (triggerAc == 11)
        {
            texto = new string[]
            {
                "Einar: Habian unas piedras alli, creo es a lo que se referia Feanor, debo ir por aquellas escaleras, y llegare a la superficie"
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
