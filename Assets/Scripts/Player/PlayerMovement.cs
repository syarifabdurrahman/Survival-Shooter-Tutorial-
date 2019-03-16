using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    Vector3 movement;
    Animator anim;
    Rigidbody PlayerRigidbody;
    int floorMask;
    float CamRayLenght = 100f;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        PlayerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Move(h, v);
        turning();
        Animating(h, v);

    }

    private void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        PlayerRigidbody.MovePosition(transform.position + movement);

    }

    void turning()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if(Physics.Raycast(cameraRay,out floorHit, CamRayLenght, floorMask))
        {
            Vector3 PlayerToMouse = floorHit.point - transform.position;
            PlayerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(PlayerToMouse);
            PlayerRigidbody.MoveRotation(newRotation);
        }
    }

    void Animating(float h, float v)
    {
        bool Walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking",Walking);
    }


}
