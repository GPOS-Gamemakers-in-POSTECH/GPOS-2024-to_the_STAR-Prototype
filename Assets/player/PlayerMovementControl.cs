using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControl : MonoBehaviour
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
    private KeyCode keyCodeFlameThrowerKeypad = KeyCode.Keypad1;
    [SerializeField]
    private KeyCode keyCodeGrabAlpha = KeyCode.Alpha2;
    [SerializeField]
    private KeyCode keyCodeGrabKeypad = KeyCode.Keypad2;
    [SerializeField]
    private KeyCode keyCodeHammerAlpha = KeyCode.Alpha3;
    [SerializeField]
    private KeyCode keyCodeHammerKeypad = KeyCode.Keypad3;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
