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
    [SerializeField] protected int _numberOfInteractions;
    [SerializeField] protected int _animIndex;
    bool _canSendPoints = false;
    public bool _hasCompleted = false;
    protected GameObject cc_player;
    #endregion

    protected GameManager gm_gameManager;

    private void Start()
    {
        gm_gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

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
    private void OnTriggerStay(Collider other)
    {
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
        _canSendPoints = false;
    }

    void Action()
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
                        _hasCompleted = true;
                        _canSendPoints = true;
                    }

                }
            }
            


        }
    }

}
