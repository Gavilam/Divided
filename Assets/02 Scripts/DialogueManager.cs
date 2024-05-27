using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public TextAsset file;
    [Header("UI elements")]
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TextMeshProUGUI speakerNameText;
    [SerializeField] TextMeshProUGUI dialogueText;
    [Header("Dialogue's properties")]
    [SerializeField] float dialogueSpeed = 0.1f;
    [HideInInspector]
    public bool isShowingDialogue = false;
    string tarjetDialogue = "";
    string currentSpeakerName;
    List<string> dialoguesData = new List<string>();

    private void Awake()
    {
        Instance = this;

        ReadData();
    }

    //Inicia la corrutina para monstrar un dialogo
    //además de cambiar el estado actual.
    public void StartDialogue(string dialogueCode)
    {
        isShowingDialogue = true;
        dialoguePanel.SetActive(true);
        SearchDialogue(dialogueCode);
        speakerNameText.text = currentSpeakerName;
        StartCoroutine(ShowDialogue());
    }

    //Detiene la(s) corrutina(s) para mostrar dialogos activas
    //y acompleta el dialogo que se estaba mostrando.
    public void CompleteDialogue()
    {
        if (!isShowingDialogue) return;

        if (tarjetDialogue != dialogueText.text)
        {
            StopAllCoroutines();
            dialogueText.text = tarjetDialogue;
            isShowingDialogue = false;
        }
    }

    //Oculta la UI de dialogos
    public void HideUI()
    {
        isShowingDialogue = false;
        dialoguePanel.SetActive(false);
        StopAllCoroutines();
        tarjetDialogue = "";
    }

    //Corrutina usada para mostrar dialogos caracter por caracter
    IEnumerator ShowDialogue()
    {
        dialogueText.text = "";

        foreach (char ch in tarjetDialogue)
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(dialogueSpeed);
        }
        isShowingDialogue = false;
    }

    void ReadData()
    {
        //Se lee el contenido de las celdas.
        string[] data = file.text.Split(new string[] { ",", "\n" }, System.StringSplitOptions.None);

        //Se realiza una correccion en los datos leidos.
        string aux = "";
        bool errorFounded = false;
        bool flag;
        foreach (string s in data)
        {
            flag = true;

            //Si encuentra un elemento con " significa que los siguientes elementos fueron separados erroneamente
            if (s.Contains('"') && !errorFounded)
                errorFounded = true;
            //Cuando encuentra el ultimo pedazo, guarda el valor correcto en lista
            else if (s.Contains('"') && errorFounded)
            {
                errorFounded = false;
                aux = aux + "" + s;
                aux = aux.Replace("\"", "");
                dialoguesData.Add(aux);
                aux = "";
                //Se usa para evitar un duplicado de informacion
                flag = false;
            }

            //Mientras haya error, se concatenan los elementos
            if (errorFounded)
                aux = aux + "" + s + ",";

            //Si no hay error se guarda la info en lista
            else
            {
                if (flag)
                    dialoguesData.Add(s);
            }
        }
    }

    void SearchDialogue(string code)
    {
        for (int i = 0; i < dialoguesData.Count; i++)
        {
            if (dialoguesData[i] == code)
            {
                currentSpeakerName = dialoguesData[i + 1];
                tarjetDialogue = dialoguesData[i + 2];
            }
        }
    }
}
