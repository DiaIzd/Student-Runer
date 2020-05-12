using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogFieldPlayer;
    public GameObject dialogFieldNPC;
    public GameObject skipButton;
    public GameObject[] dialogsTextPlayer;
    public GameObject[] dialogsTextNPC;
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
            dialogsTextPlayer[dialogPlayerCounter].SetActive(true);
            dialogPlayerCounter++;
        }
        else {
            dialogFieldNPC.SetActive(true);
            skipButton.SetActive(false);
            dialogsTextNPC[dialogNPCCounter].SetActive(true);
            dialogNPCCounter++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void skipOneSentence()
    {
        if (!(isPlayerDialogsEnd() && isNPCDialogsEnd()))
        {
            switchDialogField();
            if (isPlayerTurn())
            {
                dialogsTextNPC[dialogNPCCounter - 1].SetActive(false);
                dialogsTextPlayer[dialogPlayerCounter].SetActive(true);
                dialogPlayerCounter++;
            }
            else
            {
                dialogsTextPlayer[dialogPlayerCounter - 1].SetActive(false);
                dialogsTextNPC[dialogNPCCounter].SetActive(true);
                dialogNPCCounter++;
            }
        }
        else
        {
            dialogFieldPlayer.SetActive(false);
            dialogFieldNPC.SetActive(false);
            dialogsTextPlayer[dialogPlayerCounter-1].SetActive(false);
            dialogsTextNPC[dialogNPCCounter-1].SetActive(false);
            skipButton.SetActive(false);
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
        if (dialogsTextNPC.Length <= dialogNPCCounter) return true;
        else return false;
    }
    private bool isNPCDialogsEnd()
    {
        if (dialogsTextPlayer.Length <= dialogPlayerCounter) return true;
        else return false;
    }
}
