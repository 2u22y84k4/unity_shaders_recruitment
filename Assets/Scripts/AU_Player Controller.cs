using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AU_PlayerController : MonoBehaviour
{
    //Compnents
    Rigidbody myRB;
    Transform myAvatar;
    //Player movement 
    [SerializeField] InputAction WASD;
    Vector2 movementInput;
    [SerializeField] float movementSpeed;

    private void OnEnable()
    {
        WASD.Enable();
    }

    private void OnDisable()
    {
        WASD.Disable();
    }

    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        myAvatar = transform.GetChild(0);
    }

    void Update()
    {
        
        movementInput = WASD.ReadValue<Vector2>();
        if (movementInput.x == 0) return;
        var turn = Mathf.Sign(movementInput.x);
        myAvatar.localScale = new Vector2(
            Mathf.Approximately(Mathf.Sign(movementInput.x), Mathf.Sign(myAvatar.localScale.x)) ? myAvatar.localScale.x : -myAvatar.localScale.x, //approx tu supress warning
            myAvatar.transform.localScale.y
        );
        
        
    }
    private void FixedUpdate()
    {
        myRB.velocity = movementInput * movementSpeed;
    }
}
