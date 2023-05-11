using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    //UI Variables
    #region Game Manager UI
    GameManager gm_gameManager;
    [SerializeField] TextMeshProUGUI ui_gm_GameHour;
    [SerializeField] TextMeshProUGUI ui_gm_GameMinutes;
    #endregion
    #region Interaction Text
    [Header("Interaction Text")]
    PlayerInput pi_playerInput;
    [SerializeField]Animator ui_textAnimator;
    #endregion
    [Header("Points Text")]
    [SerializeField] TextMeshProUGUI ui_currentPointsText;
    // Start is called before the first frame update
    void Start()
    {
        gm_gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        pi_playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
    }
    // Update is called once per frame
    void Update()
    {
        #region Text Update
        ui_gm_GameHour.text = gm_gameManager.GetGameHour().ToString();
        ui_gm_GameMinutes.text = gm_gameManager.GetGameTimer().ToString("F0");
        ui_currentPointsText.text = gm_gameManager.GetTotalPoints().ToString();
        #endregion

        #region UI Animations Update
        ui_textAnimator.SetBool("isOn", pi_playerInput.GetCanInteract());
        #endregion
    }
}
