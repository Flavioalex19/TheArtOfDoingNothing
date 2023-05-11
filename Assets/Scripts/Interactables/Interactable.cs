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
    [Tooltip("Total numbers of interactions that the player can have")]
    [SerializeField] protected float _bonusTime;
    [SerializeField] protected int _animIndex;
    protected bool _canSendPoints = false;
    public bool _hasCompleted = false;

    public bool _hasAStep = false;//if the interactable has more than 1 step to be completed
    public bool _canProgress = false;
    [SerializeField] int _progressItemIndex;

    protected GameObject cc_player;
    protected TaskManager tg_taskManager;
    #endregion

    protected GameManager gm_gameManager;

    private void Start()
    {
        gm_gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        tg_taskManager = GameObject.Find("Task Manager").GetComponent<TaskManager>();

    }

    private void Update()
    {
        
        if (_hasAStep)
        {
            StepAction();
        }
        else Action();



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            cc_player = other.gameObject;
            other.GetComponent<PlayerInput>().SetCanInteract(true);

            
            //cc_player.GetComponent<PlayerManager>()._playerStates = (PlayerStates)_animIndex;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        CheckItem();
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
                        
                        gm_gameManager.AddToTotalPoints(_pointsSent);
                        gm_gameManager.EarnSecondsByActivity(_bonusTime);
                        tg_taskManager.SetTaskConcludedFromRoomIndex();
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
    public void CheckItem()
    {
        if (cc_player.GetComponent<PlayerManager>().GetItemIndex()>0 && _hasAStep == true)
        {
            if (_progressItemIndex == cc_player.GetComponent<PlayerManager>().GetItemIndex())
            {
                _canProgress = true;
                print("Pass");
            }
        }
        else cc_player.GetComponent<PlayerInput>().SetHasInteracted(false);


    }
}
