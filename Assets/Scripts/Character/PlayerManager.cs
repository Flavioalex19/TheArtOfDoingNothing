using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStates
{
    None,
    Dancing,
    Playing,
    Studying,
    Cooking,
    Eating,
    Sleeping
}

public class PlayerManager : MonoBehaviour
{
    public PlayerStates _myStates;

    [SerializeField]float _activityDurationTimerReset;//how long the player will be locked in certain activity 
    public float _activityDurationTimer;

    public string _stateName;

    PlayerInput _playerInput;

    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();

        _activityDurationTimer = _activityDurationTimerReset;
    }

    // Update is called once per frame
    void Update()
    {

        

        switch (_myStates)
        {
            case PlayerStates.None:
                _activityDurationTimer = _activityDurationTimerReset;
                break;
            case PlayerStates.Dancing:
                if (_activityDurationTimer > 0)
                {
                    _activityDurationTimer -= Time.deltaTime;
                }
                else
                {
                    _activityDurationTimer = _activityDurationTimerReset;
                    _myStates = PlayerStates.None;

                }
                break;
            case PlayerStates.Playing:
                Activity();
                break;
            case PlayerStates.Studying:
                Activity();
                break;
            case PlayerStates.Cooking:
                break;
            case PlayerStates.Sleeping:
                break;
            default: 
                break;
        }
    }

   
    void Activity()
    {
        if (_activityDurationTimer > 1)
        {
            _activityDurationTimer -= Time.deltaTime;
        }
        else
        {
            _playerInput.SetHasInteracted(false);
            _myStates = PlayerStates.None;

        }
    }
    
}
