using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Game Time Variables
    [Header("Game Time Variables")]
    [SerializeField] int _gameHour = 12;
    [SerializeField] float _gameTimer;
    [Tooltip("Seconds tha will be needed to make 1h in the game")]
    [SerializeField] float _gameSecondsForAnHour;
    #endregion
    #region Points Variables
    [Header("Points Variables")]
    [SerializeField] float _totalPoints;//Points that will the character earn from doing interactions
    [SerializeField] float _truePoints;//Points for the conclusion
    [SerializeField] float _pointsLostByTime;
    float _truePointsRequired;
    public bool _hasPoints = false;
    
    [Header("Points Timer Decrease")]
    [SerializeField] float _decreasePointsTimerReset;
    public float _decreasePointsTimer;//after receive the first points, if the player dont do nothing, the oints will be decreased, not the true points
    #endregion

    PlayerInput _playerInput;

    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        _decreasePointsTimer = _decreasePointsTimerReset;
    }

    // Update is called once per frame
    void Update()
    {
        GameProgressionTime();
        if ( _totalPoints>0) _hasPoints = true;
        else _hasPoints = false;
        DecreasePointsByTime();
    }

    #region Get & Set
    public float GetTotalPoints()
    {
        return _totalPoints;
    }

    #endregion
    public void AddToTotalPoints(float totalPoints)
    {
        _totalPoints += totalPoints;
    }
    void GameProgressionTime()
    {
        _gameTimer += Time.deltaTime;

        if (_gameTimer > _gameSecondsForAnHour)
        {
            _gameTimer = 0;
            _gameHour++;
        }
    }
    void DecreasePointsByTime()
    {
        if (_hasPoints)
        {
            if (_decreasePointsTimer>0)
            {
                _decreasePointsTimer-= Time.deltaTime;
                
            }
            else
            {
                _hasPoints = false;
                _decreasePointsTimer = _decreasePointsTimerReset;
                _totalPoints -= _pointsLostByTime;
            }
        }
        else _decreasePointsTimer = _decreasePointsTimerReset;
    }
}
