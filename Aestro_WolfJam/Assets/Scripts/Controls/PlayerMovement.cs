using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inputs for player movements as well as information like steps
/// </summary>
public class PlayerMovement : MonoBehaviour
{

    public Transform playerTransform;
    public Transform playerRotation;
    public Space moveSpace, rotateSpace;
    public float speedMove, rotateSpeed = 1.0f;

    private Vector3 rotateVar = new Vector3(0, 90, 0);

    [Space]
    [Header("INPUTS FOR MOVEMENT CONTROLS\n_________________________")]
    [Space]
    public KeyCode moveForwardMain = KeyCode.W;
    public KeyCode moveBackwardMain = KeyCode.S;
    [Space]
    public KeyCode rotateRightMain = KeyCode.D;
    public KeyCode rotateLeftMain = KeyCode.A;

    public void Awake()
    {
        if (!playerTransform)
            playerTransform = this.transform;
        if (!playerRotation)
            playerRotation = playerTransform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckForMoveInputs();
        CheckForRotateInputs();
    }

    public void CheckForMoveInputs()
    {
        if (Input.GetKey(moveForwardMain))
            playerTransform.transform.Translate(Vector3.forward * speedMove * Time.deltaTime, moveSpace);

        if (Input.GetKey(moveBackwardMain))
            playerTransform.transform.Translate(Vector3.back * speedMove * Time.deltaTime, moveSpace);
    }

    public void CheckForRotateInputs()
    {
        if (Input.GetKey(rotateRightMain))
            playerTransform.transform.Rotate(rotateVar * rotateSpeed * Time.deltaTime, rotateSpace);

        if (Input.GetKey(rotateLeftMain))
            playerTransform.transform.Rotate(rotateVar * -rotateSpeed * Time.deltaTime, rotateSpace);
    }

}// end of PlayerMovement class
