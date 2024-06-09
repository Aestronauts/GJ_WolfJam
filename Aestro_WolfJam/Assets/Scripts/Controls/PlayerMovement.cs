using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inputs for player movements as well as information like steps
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [Header("REFERENCE VARIABLES FOR MOVEMENT\n_______________________________________")]
    public Transform playerTransform;
    public Transform playerRotation;
    public Space moveSpace, rotateSpace;
    public float speedMove, rotateSpeed = 1.0f;

    private bool isMoving, isRotating;
    private Vector3 rotateVar = new Vector3(0, 90, 0);

    [Space]
    [Header("INPUTS FOR MOVEMENT CONTROLS\n_______________________________________")]
    [Space]
    public KeyCode moveForwardMain = KeyCode.W;
    public KeyCode moveBackwardMain = KeyCode.S;
    [Space]
    public KeyCode rotateRightMain = KeyCode.D;
    public KeyCode rotateLeftMain = KeyCode.A;
    [Space]
    public KeyCode FlashlightMain = KeyCode.Space;
    [Header("optional movement - keybinding")]
    public UiKeybinder ref_UiKeybinder;



    [Header("FOOTSTEP VARIABLES FOR MOVEMENT\n_______________________________________")]
    public float foostepRate = 0.25f;
    private float lastFootstep;

    public void Awake()
    {
        if (!playerTransform)
            playerTransform = this.transform;
        if (!playerRotation)
            playerRotation = playerTransform;
    }

    public void CheckForKeybindings()
    {
        if (ref_UiKeybinder)
        {
            moveForwardMain = ref_UiKeybinder.input_Forward;
            moveBackwardMain = ref_UiKeybinder.input_Backwards;
            rotateRightMain = ref_UiKeybinder.input_Right;
            rotateLeftMain = ref_UiKeybinder.input_Left;
            //FlashlightMain = ref_UiKeybinder.input (I DON'T KNOW HOW THIS IS SUPPOED TO WORK SORRY)
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckForMoveInputs();
        CheckForRotateInputs();
        CheckForFlashLightInputs();
        CalculateFootsteps();
    }

    private void CheckForMoveInputs()
    {
        if (Input.GetKey(moveForwardMain))
        {
            isMoving = true;
            playerTransform.transform.Translate(Vector3.forward * speedMove * Time.deltaTime, moveSpace);
        }

        if (Input.GetKey(moveBackwardMain))
        {
            isMoving = true;
            playerTransform.transform.Translate(Vector3.back * speedMove * Time.deltaTime, moveSpace);
        }

        if (!Input.GetKey(moveForwardMain) && !Input.GetKey(moveBackwardMain))
            isMoving = false;
    }

    private void CheckForFlashLightInputs()
    {
        if (Input.GetKey(FlashlightMain))
        {
            //Turn On Flashlight / Deactivate VFX
            if (UI_HP.instance.elapsedTime == 0)
            {
                UI_HP.instance.UpdateHP(-10);
            }
            else
            {
                Debug.Log("On Cooldown!");
            }
        }
    }

    private void CheckForRotateInputs()
    {
        if (Input.GetKey(rotateRightMain))
        {
            isRotating = true;
            playerTransform.transform.Rotate(rotateVar * rotateSpeed * Time.deltaTime, rotateSpace);
        }

        if (Input.GetKey(rotateLeftMain))
        {
            isRotating = true;
            playerTransform.transform.Rotate(rotateVar * -rotateSpeed * Time.deltaTime, rotateSpace);
        }

        if (!Input.GetKey(rotateRightMain) && !Input.GetKey(rotateLeftMain))
            isRotating = false;
    }

    private void CalculateFootsteps()
    {
        if(isMoving && Time.time > lastFootstep + foostepRate || isRotating && Time.time > lastFootstep + foostepRate)
        {
            //play foostep
            //reset foostep stamp
        }
    }


}// end of PlayerMovement class
