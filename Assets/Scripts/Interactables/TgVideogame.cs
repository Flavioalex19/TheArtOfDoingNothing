using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TgVideogame : Interactable
{

    private void Update()
    {
        
        if(cc_player != null)
        {
            if (cc_player.GetComponent<PlayerInput>().GetHasInteracted())
            {
                cc_player.GetComponent<PlayerManager>()._myStates = (PlayerStates)_animIndex;
            }
        }
        
        
    }

    void PlayVideoGame()
    {

    }
}
