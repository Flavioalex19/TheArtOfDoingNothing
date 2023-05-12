using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    //UI Variables
    #region Game Manager UI
    [Header("Time Variables/ Clock")]
    GameManager gm_gameManager;
    [SerializeField] TextMeshProUGUI ui_gm_GameHour;//Hour in the game
    [SerializeField] TextMeshProUGUI ui_gm_GameMinutes;//Minutes in the game
    #endregion
    #region Interaction Text
    [Header("Interaction Text")]
    PlayerInput pi_playerInput;
    [SerializeField]Animator ui_textAnimator;
    #endregion
    [Header("Points Text")]
    [SerializeField] TextMeshProUGUI ui_currentPointsText;

    #region Task Manager UI
    TaskManager tm_taskManager;
    [SerializeField] TextMeshProUGUI ui_tm_TaskCount;//Number of the quest complited

    #endregion
    #region DialogueBox
    [SerializeField] Animator ui_dialogueBoxAnimator;
    [SerializeField] TextMeshProUGUI ui_dialogueText;
    string _textDisplayed;//Variable thta will receive the string of the interacted object
    float _dialogueBoxTimerReset = 5f;//Time of the dialogue boxz is visible/on10
    public float dialogueBoxTimer;
    bool _startCountdown = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        gm_gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        pi_playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        tm_taskManager = GameObject.Find("Task Manager").GetComponent<TaskManager>();

        dialogueBoxTimer = _dialogueBoxTimerReset;
    }
    // Update is called once per frame
    void Update()
    {
        #region Text Update
        ui_gm_GameHour.text = gm_gameManager.GetGameHour().ToString();
        ui_gm_GameMinutes.text = gm_gameManager.GetGameTimer().ToString("F0");
        ui_currentPointsText.text = gm_gameManager.GetTotalPoints().ToString();
        ui_tm_TaskCount.text = tm_taskManager.GetTaskConcludedFromRoomCount().ToString();
        UiDialogueTextDisplay();


        #endregion

        #region UI Animations Update
        ui_textAnimator.SetBool("isOn", pi_playerInput.GetCanInteract());
        DialogueBoxTimerOn();
        #endregion
    }

    public void SetTextDisplayed(string text)
    {
        _textDisplayed = text;
    }
    void DialogueBoxTimerOn()
    {
        if (pi_playerInput.GetHasInteracted())
        {
            _startCountdown = true;
        }
        if (_startCountdown)
        {
            dialogueBoxTimer-=Time.deltaTime;
            
            if (dialogueBoxTimer > 0)
            {
                ui_dialogueBoxAnimator.SetBool("isOn", true);
            }
            else
            {
                
                ui_dialogueBoxAnimator.SetBool("isOn", false);
                dialogueBoxTimer = _dialogueBoxTimerReset;
                _startCountdown =false;
            }
        }
    }
    void UiDialogueTextDisplay()
    {
        if (_textDisplayed != null)
        {

            ui_dialogueText.text = _textDisplayed;
        }
        /*
        if(pi_playerInput.GetHasInteracted() == false)
        {
            _textDisplayed = "";
        }
        */
        
        
    }
}
