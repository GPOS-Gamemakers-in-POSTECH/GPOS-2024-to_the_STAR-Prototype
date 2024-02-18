using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Input KeyCodes")]
    [SerializeField]
    private KeyCode keyCodeGoLeft = KeyCode.A;
    [SerializeField]
    private KeyCode keyCodeGoRight = KeyCode.D;
    [SerializeField]
    private KeyCode keyCodeInteraction = KeyCode.E;
    [SerializeField]
    private KeyCode keyCodeUnarm = KeyCode.X;
    [SerializeField]
    private KeyCode keyCodeSelectArm = KeyCode.Z;
    [SerializeField]
    private KeyCode keyCodeFlameThrowerAlpha = KeyCode.Alpha1;
    [SerializeField]
    private KeyCode keyCodeFlameThrowerNumpad = KeyCode.Keypad1;
    [SerializeField]
    private KeyCode keyCodeGrabAlpha = KeyCode.Alpha2;
    [SerializeField]
    private KeyCode keyCodeGrabNumpad = KeyCode.Keypad2;
    [SerializeField]
    private KeyCode keyCodeHammerAlpha = KeyCode.Alpha3;
    [SerializeField]
    private KeyCode keyCodeHammerNumpad = KeyCode.Keypad3;
    [SerializeField]
    private KeyCode keyCodeWeaponPrimaryUse = KeyCode.Mouse1;
    [SerializeField]
    private KeyCode keyCodeWeaponSecondaryUse = KeyCode.Mouse2;
    [SerializeField]
    private KeyCode keyCodeDash1 = KeyCode.LeftShift;
    [SerializeField]
    private KeyCode keyCodeDash2 = KeyCode.RightShift;
    [SerializeField]
    private KeyCode keyCodePause = KeyCode.Escape;

    private PlayerMovementControl playerMovementControl;
    private InteractControl interactControl;

    void Start()
    {
        playerMovementControl = GetComponent<PlayerMovementControl>();
        interactControl = GetComponent<InteractControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyCodeGoLeft))
        {
            playerMovementControl.MoveLeft(PlayerState.playerMoveSpeed);
            Debug.Log("left");
        }

        if (Input.GetKeyDown(keyCodeGoRight))
        {
            playerMovementControl.MoveRight(PlayerState.playerMoveSpeed);
            Debug.Log("right");
        }

        if (Input.GetKeyDown(keyCodeInteraction))
        {
            interactControl.Interact();
        }

        if (Input.GetKeyDown(keyCodeUnarm))
        {

        }

        // TODO: Unclear defs
        if (Input.GetKey(keyCodeSelectArm))
        {

        }

        if (Input.GetKeyDown(keyCodeFlameThrowerAlpha) || Input.GetKeyDown(keyCodeFlameThrowerNumpad))
        {

        }

        if (Input.GetKeyDown(keyCodeGrabAlpha) || Input.GetKeyDown(keyCodeGrabNumpad))
        {

        }

        if (Input.GetKeyDown(keyCodeHammerAlpha) || Input.GetKeyDown(keyCodeHammerNumpad))
        {

        }

    }
}
