using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    #region Private Variables
    //Variables
    Transform _cam;// A reference to the main camera in the scenes transform
    Vector3 _camForward;// The current forward direction of the camera
    Vector3 cc_move;
    bool _isMoving;

    //Input Variables
    bool cc_canInteract = false;//if the player can interact with certain object
    public bool cc_hasInteracted = false;//if the Player has interacted with the object

    //Components
    Movement cc_movement;
    #endregion

    private void Start()
    {
        // get the transform of the main camera
        if (Camera.main != null)
        {
            _cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning(
                "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
            // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
        }

        cc_movement = GetComponent<Movement>();
    }
    private void Update()
    {
        if (cc_canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                cc_hasInteracted = true;
            }
            
        }
    }
    private void FixedUpdate()
    {
        if (cc_hasInteracted == false)
        {
            // read inputs
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            // calculate move direction to pass to character
            if (_cam != null)
            {
                // calculate camera relative direction to move:
                _camForward = Vector3.Scale(_cam.forward, new Vector3(1, 0, 1)).normalized;
                cc_move = v * _camForward + h * _cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                cc_move = v * Vector3.forward + h * Vector3.right;
            }
            cc_movement.Move(cc_move, _isMoving);
        }
        
    }

    #region Get & Set
    public bool GetCanInteract()
    {
        return cc_canInteract;
    }
    public void SetCanInteract(bool canInteract)
    {
        cc_canInteract = canInteract;
    }
    public bool GetHasInteracted()
    {
        return cc_hasInteracted;
    }
    public void SetHasInteracted(bool hasInteracted)
    {
        cc_hasInteracted= hasInteracted;
    }

    #endregion
}
