using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// make movement with keys rather than auto-- or actually do two versions
public class HeroControl : MonoBehaviour
{
    [SerializeField] LayerMask groundLayers;
    [SerializeField] private float speed = 8;
    [SerializeField] private float jumpingHeight = 2.5f;
    private float gravity = -50f;
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;
    private float positiveMovement; // will later have to make public to add keys

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        positiveMovement = 1;
        transform.forward = new Vector3(positiveMovement, 0, Mathf.Abs(positiveMovement) - 1);

        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        } 
        else 
        {
            velocity.y += gravity * Time.deltaTime;
        }

        characterController.Move(new Vector3(positiveMovement * speed, 0, 0) * Time.deltaTime);

        // modify to up key button instead
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y += Mathf.Sqrt(jumpingHeight * -2 * gravity); 
        }

        characterController.Move(velocity * Time.deltaTime);
    }
}
