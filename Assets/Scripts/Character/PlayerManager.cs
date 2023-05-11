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
    Sleeping,
    Watching,
}

public class PlayerManager : MonoBehaviour
{
    public PlayerStates _myStates;

    [SerializeField]float _activityDurationTimerReset;//how long the player will be locked in certain activity 
    public float _activityDurationTimer;

    public string _stateName;

    public int _itemIndex;

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
                Activity();
                break;
            case PlayerStates.Playing:
                Activity();
                break;
            case PlayerStates.Studying:
                Activity();
                break;
            case PlayerStates.Cooking:
                Activity();
                break;
            case PlayerStates.Sleeping:
                Activity();
                break;
            case PlayerStates.Watching:
                Activity();
                break;
            default: 
                break;
        }
    }

   public int GetItemIndex()
    {
        return _itemIndex;
    }
    
    public void SetItemIndex(int item)
    {
        _itemIndex = item;
    }
    void Activity()
    {
        if (_activityDurationTimer > 1)
        {
            _activityDurationTimer -= Time.deltaTime;
        }
        else
        {
            if(_itemIndex>0) _itemIndex = 0;//the item has been used
            _playerInput.SetHasInteracted(false);
            _myStates = PlayerStates.None;

        }
    }
    
}
