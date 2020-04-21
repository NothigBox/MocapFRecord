using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    [SerializeField] public bool isMoving = false;
    [SerializeField] public bool canMove = true;
    [SerializeField] Rigidbody rb;
    [SerializeField, Range(0, 1000)] float playerSpeed;
    [SerializeField] public GameObject character;
    [SerializeField] public bool firstPersonCameraActive = true;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = character.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                isMoving = true;
                rb.velocity = character.transform.right * playerSpeed * -1;
            }
            else { isMoving = false; }

            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                isMoving = true;
                rb.velocity = character.transform.right * playerSpeed;
               
            }
            else { isMoving = false; }
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                isMoving = true;
                rb.velocity = character.transform.forward * playerSpeed;
               
            }
            else { isMoving = false; }
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                isMoving = true;
                rb.velocity = character.transform.forward * playerSpeed * -1;

            }
            else { isMoving = false; }




        }


    }

    public void ChangeDrag(float newDrag) 
    {
        rb.drag = newDrag;

    }
}
