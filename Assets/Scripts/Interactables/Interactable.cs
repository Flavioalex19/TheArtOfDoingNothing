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
    [SerializeField] protected float _cooldownTimerReset;
    protected float _cooldownTimer;
    [Tooltip("Total numbers of interactions that the player can have")]
    [SerializeField] protected int _numberOfInteractions;
    [SerializeField] protected int _animIndex;
    bool _canSendPoints = false;
    protected GameObject cc_player;
    #endregion

    protected GameManager gm_gameManager;

    private void Start()
    {
        gm_gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        _cooldownTimer = _cooldownTimerReset;
    }

    private void Update()
    {
        Action();
        
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

    private void OnTriggerExit(Collider other)
    {
        cc_player = null;
        other.GetComponent<PlayerInput>().SetCanInteract(false);
        _canSendPoints = false;
    }

    void Action()
    {
        if (cc_player != null)
        {
            if (cc_player.GetComponent<PlayerInput>().GetHasInteracted())
            {
                cc_player.GetComponent<PlayerManager>()._myStates = (PlayerStates)_animIndex;
                if (_canSendPoints == false)
                {
                    gm_gameManager.AddToTotalPoints(_pointsSent);
                    _canSendPoints=true;
                }
                
            }
        }
    }

}
