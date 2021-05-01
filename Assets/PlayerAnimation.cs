using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    [SerializeField] private Animator anim;
    [SerializeField] private PlayerMovement playerMovement;


    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovement.currentMovement != Vector3.zero)
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }
    }
}
