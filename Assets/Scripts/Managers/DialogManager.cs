using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogFieldPlayer;
    public GameObject dialogFieldNPC;
    public GameObject skipButton;
    public Text dialogsTextPlayer;
    public Text dialogsTextNPC;
    public string[] sentencesPlayer;
    public string[] sentencesNPC;
    public bool isPlayerStartingDialog;
    private int dialogNPCCounter;
    private int dialogPlayerCounter;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        dialogNPCCounter = 0;
        dialogPlayerCounter = 0;
        if (isPlayerStartingDialog)
        {
            dialogFieldPlayer.SetActive(true);
            dialogsTextPlayer.text = sentencesPlayer[dialogPlayerCounter].ToString();
            dialogPlayerCounter++;
        }
        else {
            dialogFieldNPC.SetActive(true);
            dialogsTextNPC.text = sentencesNPC[dialogNPCCounter].ToString();
            dialogNPCCounter++;
        }
    }

 

    public void skipOneSentence()
    {
        if (!(isPlayerDialogsEnd() && isNPCDialogsEnd()))
        {
            switchDialogField();
            if (isPlayerTurn())
            {;
                dialogsTextNPC.text = "";
                dialogsTextPlayer.text = sentencesPlayer[dialogPlayerCounter];
                dialogPlayerCounter++;
            }
            else
            {
                dialogsTextPlayer.text = "";
                dialogsTextNPC.text = sentencesNPC[dialogNPCCounter];
                dialogNPCCounter++;
            }
        }
        else
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    private void switchDialogField()
    {
        if (dialogFieldPlayer.active)
        {
            dialogFieldPlayer.SetActive(false);
            dialogFieldNPC.SetActive(true);
        }
        else
        {
            dialogFieldPlayer.SetActive(true);
            dialogFieldNPC.SetActive(false);
        }
    }

    private bool isPlayerTurn()
    {
        return dialogFieldPlayer.active;
    }

    private bool isPlayerDialogsEnd()
    {
        if (sentencesNPC.Length <= dialogNPCCounter) return true;
        else return false;
    }
    private bool isNPCDialogsEnd()
    {
        if (sentencesPlayer.Length <= dialogPlayerCounter) return true;
        else return false;
    }
}
