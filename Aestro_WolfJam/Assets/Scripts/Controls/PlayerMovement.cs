using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inputs for player movements as well as information like steps
/// </summary>
public class PlayerMovement : MonoBehaviour
{

    [Header("Player Stats")]
    public float HP;
    private float StayStillTimer = 0;
    private float LoseHPTimer = 0;
    public GameObject FlashLight;

    [Header("optional movement - keybinding")]
    public UiKeybinder ref_UiKeybinder;

    [Space]
    [Space]
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
    



    [Header("FOOTSTEP VARIABLES FOR MOVEMENT\n_______________________________________")]
    public float foostepRate = 0.25f;
    private float lastFootstep;

    public void Awake()
    {
        if (!playerTransform)
            playerTransform = this.transform;
        if (!playerRotation)
            playerRotation = playerTransform;

        CheckForKeybindings();
    }

    public void Start()
    {
        DialogueManager.instance.PlayDialogue(1);
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
        LoseHPTimer += Time.deltaTime;
        if (LoseHPTimer >= 6)
        {
            UI_HP.instance.UpdateHP(-1);
            LoseHPTimer = 0;
        }

        if (isMoving)
        {
            StayStillTimer = 0;
        }
        else
        {
            StayStillTimer += Time.deltaTime;
            if (StayStillTimer >= 5)
            {
                DialogueManager.instance.PlayDialogue(4);
                StayStillTimer = 0;
            }
        }
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
            if (!FlashLight.activeSelf)
            {
                HP -= 10;
                CheckHP();
                StartCoroutine("FlashlightSequence", 3);
                UI_HP.instance.UpdateHP(-10);
            }
            else
            {
                Debug.Log("On Cooldown!");
            }
        }
    }

    public void CheckHP()
    {
        if (HP < 0)
        {
            //Game Over
            StartCoroutine(FlashlightStrobeFX(.5f, 1.5f));
            DialogueManager.instance.PlayDialogue(6);
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

    public IEnumerator FlashlightSequence(int duration)
    {
        FlashLight.SetActive(true);
        yield return new WaitForSeconds(duration);
        FlashLight.SetActive(false);
    }

    public IEnumerator FlashlightStrobeFX(float minDuration,  float maxDuration)
    {
        while (true)
        {
            FlashLight.SetActive(!FlashLight.activeSelf);

            float interval = Random.Range(minDuration, maxDuration);
            yield return new WaitForSeconds(interval);
        }
    }


}// end of PlayerMovement class
