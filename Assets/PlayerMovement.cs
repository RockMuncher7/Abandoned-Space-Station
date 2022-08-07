using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveForceX = 5, moveForceZ = 5;
    public float jumpHeight = 5;

    private Rigidbody rb;

    public LayerMask ignoreLayers;

    private bool grounded = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovementFunctionality();
        JumpFunctionality();
    }

    void MovementFunctionality()
    {
        float moveX = Input.GetAxis("Horizontal") * moveForceX;
        float moveZ = Input.GetAxis("Vertical") * moveForceZ;

        transform.localPosition += transform.forward * moveZ * Time.deltaTime;
        transform.localPosition += transform.right * moveX * Time.deltaTime;
    }

    void JumpFunctionality()
    {
        grounded = Physics.CheckSphere(GameObject.Find("GroundCheck").transform.position, 0.4f, ~ignoreLayers);

        if (grounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector3(rb.velocity.x, Mathf.Sqrt(jumpHeight * -2 * Physics.gravity.y), rb.velocity.z);
            }
        }
    }
}
