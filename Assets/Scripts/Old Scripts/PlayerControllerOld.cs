using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update

    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    [SerializeField] float speed = 1, jumpForce = 200;
    [SerializeField] Rigidbody rb;

    // Update is called once per frame
    void FixedUpdate()
    {
        /*Vector3 vel = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed;
        vel.y = rb.velocity.y;
        rb.velocity = vel;*/

        
    }

    void Update() {
        // jump check
        
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        if(dir.magnitude > 0.1f) { // player is walking
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f,targetAngle,0f);
            if(animator.runtimeAnimatorController)
            animator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Assets/Kevin Iglesias/Basic Motions/AnimationControllers/BasicMotions@Walk.controller");
        }
        else {
            animator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Assets/Kevin Iglesias/Basic Motions/AnimationControllers/BasicMotions@Idle.controller");
        }*/
    }
}
