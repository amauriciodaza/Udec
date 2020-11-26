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
    GameObject CarceleraSun;

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
        CarceleraSun = GameObject.Find("SunEnemyMelee");
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
                yield return new WaitForSeconds(0.2f * Time.deltaTime);
            }
            yield return new WaitForSeconds(2f);
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
        //Entrada
        if (triggerAc == 0)
        {
            GetComponent<TranslationMovement>().DialogDetention();//funciones lost energy(Desactiva movimientos), no funciona bien
            texto = new string[]
            {
                "Einar: ¡Es!... ¡impresionante!... ¿Esto es la superficie?, no me la imaginaba así, si me dijeron que era muy bonito, pero es totalmente diferente",
                "LuxTerra: Antes era más bello, era magnifico, esto es solo destrucción",
                "Einar: Si esto son solo ruinas y desastre entonces la belleza de antes era infinita",
                "LuxTerra: sin embargo tus antepasados no supieran valorar nada, y este es el resultado",
                "LuxTerra: Eso de allá es... ¡Es el tesoro del Sol!"
            };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }
        //Brazalete
        else if (triggerAc == 1)
        {
            GetComponent<TranslationMovement>().DialogDetention();
            texto = new string[]
            {
                "Brazalete: 'Signus, la estrella del norte'...",
                "Einar: Es igual que con la espada...",
                "Signus: Ahora hago parte de tu energía, estoy vinculado a tu esencia... Igual que LuxTerra a quien portas en tu espalda",
                "Signus: Einar, ya sabrás esto, pero tú eres quien ha sido esperado por decadas, aquel que puede salvar este mundo",
                "Signus: Yo te guiare en este lugar, y te hare más fuerte a través de la energia del Sol, de la que soy portador, y ahora hace parte de ti",
                "Signus: Mi guardiana descubrió algo importante respecto a Contaminación, pero la energía que porta quien la tiene capturada no permite conectar con sus pensamientos",
                "Signus: Debes ayudarme a salvarla Einar. Está muy cerca de aquí, tendrás que enfrentar muchos obstáculos, pero confío en que lo lograras",
                "Einar: ¡Lo hare!",
                "Signus: Entonces vamos"
            };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }
        //Enemigos
        else if (triggerAc == 2)
        {
            GetComponent<TranslationMovement>().DialogDetention();
            texto = new string[]
            {
                "Signus: Mira, esos son enemigos... Los soldados de contaminación, aquel de color negro te atacara a distancia, debes tener cuidado los de ese tipo, no son fáciles de eliminar",
                "Signus: Y aquel otro con esas enormes garras te tratara de destrozar a golpes y te perseguirá, debes ser rápido para enfrentarlo",
                "Einar: Se ven bastante problemáticos, sin embargo siento esta energía que ahora fluye en mi cuerpo... es como si fuera aún más fuerte",
                "Signus: Y así es Einar, ahora con las dos energías juntas tu fuerza está completa",
                "Signus: ¡Vamos a derrotarlos!... Aunque si sientes que no puedes más aléjate y encuentra un árbol, te ayudara a sanar tus heridas y recuperar tus energías",
                "Einar: Bien, derrotaremos a contaminación y sus monstruos... ¡Corregiré los errores de mis antepasados!"
            };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }
        //Subiendo las escaleras luego de armas la secuencia
        else if (triggerAc == 3)
        {
            texto = new string[]
            {
                "Signus: Esta es una buena oportunidad de que entiendas mi poder... Yo te permitiré atacar a distancia, así:",
                "Signus (Instrucciones): Presiona Click Derecho en tu mouse para apuntar, luego Click Izquierdo para disparar, si deseas cancelar el ataque vuelve a presionar Click Derecho, ahora inténtalo"
            };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }
        //Entrando al laberinto despues del punto de Guardado
        else if (triggerAc == 4)
        {
            texto = new string[]
            {
                "Einar: Que bien, es un árbol, podre recuperar la energía de LuxTerra y mis fuerzas"
            };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }

        //En la puerta del Templo Geotermico
        else if (triggerAc == 5)
        {
            texto = new string[]
            {
                "Einar: Oo o ohh... Que... Esta torreee, ¡es enorme!",
                "Signus: Debes subir para poder llegar al templo, pero debes observar bien, en esta torre hay runas que necesitaras, debes obtenerlas"
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
                "Einar: Eso fue difícil",
                "Signus: Debemos seguir, siento que Lena está cerca",
                "Signus: Ten cuidado, se ven más enemigos al frente"
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
                "Signus: Este es el templo de la Guardiana del Sol, sus mecanismos de defensa se activaron cuando los soldados de Contaminación la atacaron y aprisionaron",
                "Einar: Creo que no será tan sencillo salvarla, si caigo allá abajo definitivamente estoy muerto",
                "Signus: Siento que hay más runas cerca, debes estar atento para conseguirlas"
            };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }
        //Al derrotar al carcelero
        else if (triggerAc == 8 )
        {
            GetComponent<TranslationMovement>().DialogDetention();
            texto = new string[]
            {
                "Signus: Lena esta aprisionada en este lugar, siento que hay un enemigo muy poderoso aquí dentro",
                "Signus: Utiliza las runas para abrir la puerta",
                "Signus: Salva a Lena",
                "Einar: ¡Lo hare!"
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
                        "Signus: Es uno de los grandes soldados de Contaminación, tiene el poder de atacar a distancia con cargas de energía negativa",
                        "Signus: Posee un escudo que se alimenta de los orbes solares, debes desactivarlos",
                        "Signus (Instrucción): Acércate a los orbes y presiona F para interactuar con los orbes y desactivarlos"
                    };
                    triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
                    next = false;
        }
        //Conversacion con el guardian
        else if (triggerAc == 10 && CarceleraSun)
        {
            if (CarceleraSun.GetComponent<EnemyLife>().life < 1)
            {
                GetComponent<TranslationMovement>().DialogDetention();
                texto = new string[]
               {
                "Carcelera: Quien este humano tan fuerte...",
                "Signus: Al fin hemos terminado con ese monstruo",
                "Signus: Al fin puedo sentir claramente la energía y los pensamientos de Lena",
                "Signus: Ve a esa plataforma y úsala para llegar a la planta superior, Lena se encuentra allá"
               };
                triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
                next = false;
            }
        }
        //Conversacion con feanor
        else if (triggerAc == 11)
        {
            GetComponent<TranslationMovement>().DialogDetention();
            texto = new string[]
            {
                "Lena: Einar, gracias por salvarme, me has liberado, como hiciste con el Guardián de la Energía Geotérmica, y al fin tenemos una nueva oportunidad de salvar este mundo",
                "Lena: Esta lucha apenas comienza, ahora tu misión será utilizar estas energías para curar el planeta, eres el nuevo Guardián de las Energías"
            };
            triggers[triggerAc].gameObject.GetComponent<Collider>().enabled = false;
            next = false;
        }
    }


    bool a = true;
    bool b = true;
    void EnableTriggers()
    {
        if (habilitar)
        {
            triggers[1].GetComponent<Collider>().enabled = false;
            triggers[10].GetComponent<Collider>().enabled = false;
            habilitar = false;
        }
        else if (CarceleraSun && a)
        {
            if (CarceleraSun.GetComponent<EnemyLife>().life < 1)
            {
                triggers[10].GetComponent<Collider>().enabled = true;
                a = false;
            }
        }
        else if (GetComponent<BracerFunction>().bracerCollected && b)
        {
            triggers[1].GetComponent<Collider>().enabled = true;
            b = false;
        }
    }
}
