using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] Collider myCollider;
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpPow = 10f;
    [SerializeField] Vector3 direction;
    [SerializeField] Rigidbody rb;

    public float gravityScale = 1.0f;
    public static float globalGravity = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ignorePlayerCollision();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        rb.AddForce(gravity, ForceMode.Acceleration);

        direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0) * speed * Time.deltaTime;
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            direction += Vector3.up * jumpPow;
        }
        //rb.velocity = direction;
        rb.MovePosition(transform.position + direction);
    }

    public bool isGrounded()
    {
        return false;
        //Physics.BoxCast()
        //RaycastHit rc = Physics.BoxCast(myCollider.bounds.center, myCollider.bounds.size, Vector3.down, Quaternion.identity , 1f, groundLayerMask);
    }

    public void ignorePlayerCollision()
    {
        myCollider = GetComponent<Collider>();
        //hàm này ngăn va chạm giữa các player
        GameObject[] colliders = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject col in colliders)
        {
            Physics.IgnoreCollision(myCollider, col.GetComponent<Collider>());
        }
    }
}
