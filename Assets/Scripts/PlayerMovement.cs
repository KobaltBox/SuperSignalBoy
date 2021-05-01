using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private FixedJoystick LeftThumbJoystick;
    private CharacterController characterController;

    public Vector3 currentMovement;

    //Parameters
    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        LeftThumbJoystick = GameObject.Find("LeftThumbJoystick").GetComponent<FixedJoystick>();
        LeftThumbJoystick.DeadZone = 0.1f;
        characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        currentMovement = new Vector3(LeftThumbJoystick.Horizontal,0f, LeftThumbJoystick.Vertical).normalized;
        if(currentMovement != Vector3.zero)
        {
            gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(currentMovement), 5 * Time.deltaTime);
            characterController.Move(currentMovement * movementSpeed * Time.deltaTime);
        }

    }
}
