using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed=15f;
    public float jumpForce = 300f;
    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Movement();
    }

    private void Movement(){
        //Cambiar de animacion
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)){
            gameObject.GetComponent<Animator>().SetBool("running", false);
        }else{
            //Cambiar la Mirada
            if (Input.GetKey(KeyCode.RightArrow)) gameObject.GetComponent<SpriteRenderer>().flipX = false;
            if (Input.GetKey(KeyCode.LeftArrow))  gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.GetComponent<Animator>().SetBool("running", true);
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            transform.position += move * Time.deltaTime * playerSpeed;
        }
    }

    private void Jump(){
        if(isGrounded){
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)){
                gameObject.GetComponent<Rigidbody2D>().
                    AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor")
        {
            isGrounded = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor")
        {
            isGrounded = false;
        }
    }

}
