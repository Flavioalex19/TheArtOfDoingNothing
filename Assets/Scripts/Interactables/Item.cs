using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : Interactable
{
    [SerializeField]int _itemIndex;


    private void Update()
    {
        Action();
    }

    protected override void Action()
    {
        if (cc_player != null)
        {
            if (cc_player.GetComponent<PlayerInput>().GetHasInteracted())
            {
                if(cc_player.GetComponent<PlayerManager>().GetItemIndex() == 0)
                {
                    cc_player.GetComponent<PlayerInput>().SetHasInteracted(false);
                    cc_player.GetComponent<PlayerManager>().SetItemIndex(_itemIndex);
                    Destroy(gameObject);
                }
                
                
            }
        }
       
    }

    public int GetItemIndex()
    {
        return _itemIndex;
    }
}
