using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 10f;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private Text countText;
    private Animator animator;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        count = 0;
        countText.text = "Count: " + count.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger entered!");
        if(other.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if(other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            count += 1;
            countText.text = "Count: " + count.ToString();
        } 
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        print("Trigger exit!");
        if(other.CompareTag("Ground"))
            isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Space))
        //     obj.SetActive(false);
        // if(Input.GetKeyUp(KeyCode.Space))
        //     obj.SetActive(true);
        
        //if(Input.GetKey(KeyCode.LeftArrow))
        //    transform.Translate(new Vector3(-2,0,0) * moveSpeed * Time.deltaTime);
        //if(Input.GetKey(KeyCode.RightArrow))
        //    transform.Translate(new Vector3(+2,0,0) * moveSpeed * Time.deltaTime);

        // ************ Moving
        float h = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(h, 0, 0);
        transform.position = transform.position + movement * moveSpeed * Time.deltaTime;

        // ************ Jumping
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            //print("Jump");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }

        // ************ Animate Run
        if(h != 0) 
        {
            animator.SetFloat("speed", 1);
        }
        if(h == 0) 
        {
            animator.SetFloat("speed", 0);
        }
        // ************ Animate Jump
        if(isGrounded == true)
        {
            animator.SetBool("grounded", true);
        }
        if(isGrounded == false)
        {
            animator.SetBool("grounded", false);
        }

    }
}
