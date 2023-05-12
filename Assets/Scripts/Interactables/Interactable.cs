using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    #region Visible Variables
    //Variables
    [Header("Variables")]
    [Tooltip("Points that the player will reveive from this interaction")]
    [SerializeField] protected float _pointsSent;
    [Tooltip("When Concluded the interaction, the time will increase")]
    [SerializeField] protected float _bonusTime;
    [SerializeField] protected int _animIndex;//animation that will be called
    protected bool _canSendPoints = false;
    public bool _hasCompleted = false;

    public bool _hasAStep = false;//if the interactable has more than 1 step to be completed
    public bool _canProgress = false;
    [Tooltip("Index of the item that is necessary to complete the task- if the task have multiple steps")]
    [SerializeField] int _progressItemIndex;//Index of the item that is necessary to complete the task- if the task have multiple steps
    [SerializeField] string _taskFinishedText;
    [SerializeField] string _taskRquiredItemText;
    #endregion

    [SerializeField]Transform _actionTransformPosition;

    protected GameObject cc_player;
    protected TaskManager tg_taskManager;
    protected GameManager gm_gameManager;
    protected UiManager uim_uiManager;

    private void Start()
    {
        gm_gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        tg_taskManager = GameObject.Find("Task Manager").GetComponent<TaskManager>();
        uim_uiManager = GameObject.Find("UI Manager").GetComponent<UiManager>();

    }

    private void Update()
    {
        

        if (_hasAStep)
        {
            StepAction();
        }
        else Action();
    }
    private void FixedUpdate()
    {
        if (_hasCompleted)
        {
            
            //cc_player.transform.forward += _actionTransformPosition.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            cc_player = other.gameObject;
            other.GetComponent<PlayerInput>().SetCanInteract(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        CheckInteraction();
        if (_hasCompleted == false)
        {
            other.GetComponent<PlayerInput>().SetCanInteract(true);
        }
        else
        {
            other.GetComponent<PlayerInput>().SetCanInteract(false);
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        cc_player = null;
        other.GetComponent<PlayerInput>().SetCanInteract(false);
        other.GetComponent<PlayerInput>().SetHasInteracted(false);
        _canSendPoints = false;
    }

    public bool GetHasCompleted()
    {
        return _hasCompleted;
    }

    protected virtual void Action()
    {
        if (cc_player != null)
        {
            if (_hasCompleted == false)
            {
                if (cc_player.GetComponent<PlayerInput>().GetHasInteracted())
                {
                    cc_player.GetComponent<PlayerManager>()._myStates = (PlayerStates)_animIndex;
                    if (_canSendPoints == false)
                    {
                        //cc_player.transform.position = _actionTransformPosition.position;
                        gm_gameManager.AddToTotalPoints(_pointsSent);
                        gm_gameManager.EarnSecondsByActivity(_bonusTime);
                        tg_taskManager.SetTaskConcludedFromRoomCount();
                        uim_uiManager.SetTextDisplayed(_taskFinishedText);
                        _hasCompleted = true;
                        _canSendPoints = true;
                    }
                    

                }
                
            }

        }
    }

    public void StepAction()
    {
        if (_canProgress)
        {
            Action();
            print("Quest is finished");
            _canProgress = false;
            
        }
        
         
    }
    public void CheckInteraction()
    {
        if (cc_player.GetComponent<PlayerManager>().GetItemIndex() > 0 && _hasAStep == true)
        {
            if (_progressItemIndex == cc_player.GetComponent<PlayerManager>().GetItemIndex())
            {
                _canProgress = true;
                
            }
        }
        if (_canProgress == false && _hasAStep)
        {
            cc_player.GetComponent<PlayerInput>().SetHasInteracted(false);
            uim_uiManager.SetTextDisplayed(_taskRquiredItemText);

        }


    }
}
