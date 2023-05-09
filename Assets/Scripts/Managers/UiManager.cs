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
    #endregion
    #region Interaction Text
    [Header("Interaction Text")]
    PlayerInput pi_playerInput;
    [SerializeField]Animator ui_textAnimator;
    
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        gm_gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        pi_playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
    }
    // Update is called once per frame
    void Update()
    {
        ui_textAnimator.SetBool("isOn", pi_playerInput.GetCanInteract());
    }
}
