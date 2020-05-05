using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -8.81f;
    private float tempGravity;
    public float jumpHeight = 3f;
    public GameObject floor1;
    public GameObject floor2;
    public Interactable focus;
    Camera cam;
    private Vector3 lastPosition;
    PlyrArmsAnimatorController arms;
    AudioSource AudioSource;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask ladderMask;
    public float ladderDistance = 2f;

    Vector3 velocity;
    bool isGrounded;
    public bool atLadder;
    public bool isMoving;
    public bool canSwap;

    void Start()
    {
        cam = Camera.main;
        lastPosition = transform.position;
        AudioSource = GetComponent<AudioSource>();
        tempGravity = gravity;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y = 0;
        atLadder = Physics.CheckSphere(groundCheck.position, ladderDistance, ladderMask);
        if(atLadder)
        {
            y = Input.GetAxis("Upwards");
            gravity = 0;
        }
        else
        {
            gravity = tempGravity;
        }

        Vector3 move = transform.right * x + transform.up * y + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                //Debug.Log("We hit " + hit.collider.name + "" + hit.point);    //check what is being hit
                Interactable interactable =  hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    //we hit
                    interactable.Interact(transform);
                }
            }
        }

        if (Input.GetMouseButtonDown(1) && canSwap)
        {
            arms = GetComponentInChildren<PlyrArmsAnimatorController>();
            arms.RightClick();
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (lastPosition != transform.position)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        lastPosition = transform.position;


    }

    public IEnumerator dimSwap()
    {
        if (floor1.activeSelf == true)
        {
            AudioSource.Play();
            floor2.SetActive(true);
            yield return new WaitUntil(() => floor2.activeSelf == true);
            floor1.SetActive(false);
        }
        else
        {
            AudioSource.Play();
            floor1.SetActive(true);
            yield return new WaitUntil(() => floor2.activeSelf == true);
            floor2.SetActive(false);
        }
        yield return null;
    }

    
}
