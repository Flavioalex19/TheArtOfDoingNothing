using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    PlayerManager playerManager;
    PlayerInput cc_input;
    Movement cc_player;

    Animator cc_animator;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        cc_player = GetComponent<Movement>();
        cc_input = GetComponent<PlayerInput>();
        cc_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cc_animator.SetFloat("Forward", cc_player._forwardAmount);
        cc_animator.SetBool("inAction", cc_input.GetHasInteracted());
        cc_animator.SetInteger("Action", (int)playerManager._myStates);

    }
}
