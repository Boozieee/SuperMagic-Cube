using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessaggIncoraggiamento : MonoBehaviour
{
    public GameObject myText;
    List<string> myList;

    private int textNumber;
    private int textMaxN = 10;

    public float durataEffetto;

    private void Start()
    {
        myList = new List<string>();

        myList.Add("Ho sempre tentato. Ho sempre fallito. Non discutere. Prova ancora. Fallisci ancora. Fallisci meglio. (Samuel Beckett)");
        myList.Add("L’unico vero fallimento sta, in realtà, nel permettere alla sconfitta di avere la meglio su di noi. (Anthony Clifford Grayling)");
        myList.Add("Non ho fallito. Ho solamente provato 10.000 metodi che non hanno funzionato. (Thomas Alva Edison)");
        myList.Add("Il successo è al 99% fatto di fallimenti (Soichiro Honda)");
        myList.Add("Il successo non è definitivo, il fallimento non è fatale: ciò che conta è il coraggio di andare avanti. (Winston Churchill)");
        myList.Add("Un che di divino affiora un attimo prima del trionfo e un attimo dopo il fallimento. (Nicolás Gómez Dávila)");
        myList.Add("Non maledire un fallimento. E’ il terreno dove vive l’umiltà. (Yasmin Mogahed)");
        myList.Add("Il fallimento ti cambia in meglio, il successo in peggio. (Lucio Anneo Seneca)");
        myList.Add("Ogni fallimento è semplicemente un’opportunità per diventare più intelligente. (Henry Ford)");
        myList.Add("Accettare il fallimento è un’attitudine da vincenti. (Alain Robert)");
    }

    public void SetText()
    {
        textNumber = Random.Range(0, textMaxN);
        Text text = myText.GetComponent<Text>();
        text.text = myList[textNumber];
        StartCoroutine("Timer");
    }

    private void DelText()
    {
        Text text = myText.GetComponent<Text>();
        text.text = "";
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(durataEffetto);
        DelText();
    }
}
