using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Objects")]
    public CharacterController controller;


    [Header("PlayerMovement")]
    public float speed = 30f;
    public float gravity = -9.81f;
    Vector3 velocity;

    private void Start()
    {

    }
    void Update()
    {



        // Movement

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        

        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}