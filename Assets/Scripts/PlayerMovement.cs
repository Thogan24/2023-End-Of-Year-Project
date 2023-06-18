using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Objects")]
    public CharacterController controller;


    [Header("PlayerMovement")]
    public float speed = 30f;
    public bool sprintApplied = false;
    public float gravity = -9.81f;
    public float sprintTime = 5f;
    Vector3 velocity;

    private void Start()
    {

    }
    void Update()
    {
        if (sprintTime <= 5f)
        {
            sprintTime += Time.deltaTime * 0.2f;
        }
        

        // Movement

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        

        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    public void applySprint()
    {
        if (!sprintApplied && sprintTime >= 0f)
        {
            speed = 50;
            sprintTime -= Time.deltaTime;
            sprintApplied = true;
        }
    }

    public void removeSprint()
    {
        sprintApplied = false;
        speed = 30;
        
    }

}