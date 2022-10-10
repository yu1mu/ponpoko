using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed = 1f;
    public float jumpPower = 1f;

    bool isJump;
    bool isLadder;
    public int carrotcount;

    Vector3 firstPosition;

    public Animator animator;

    public AudioClip jump;
    public AudioClip item;
    public AudioClip bug;
    public AudioSource audioSourse;
    void Awake()
    {
        isJump = false;
        isLadder = false;
        firstPosition = transform.position;
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        carrotcount = 9;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        Move();
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            audioSourse.clip = jump;
            audioSourse.Play();
            Jump();
        }

        if (isLadder)
        {
            MoveLadder();
        }
    }

    void Move()
    {
        Vector3 v = Vector2.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            animator.SetBool("isMove", true);
            v = Vector2.left;
            transform.eulerAngles = new Vector3(0, 0, 0);
            
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            animator.SetBool("isMove", true);
            v = Vector2.right;
            transform.eulerAngles = new Vector3(0, 180, 0);
           
        }

        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetBool("isMove", false);
        }
        
        transform.position += speed * Time.deltaTime * v;
    }

    void Jump()
    {
        isJump = true;
        rigid.velocity = Vector2.zero;

        animator.SetBool("isJump", true);
        Vector2 jumpVelocity = new Vector2(0, jumpPower);
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }

    void MoveLadder()
    {
        Vector3 v = Vector2.zero;
        rigid.gravityScale = 0;
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            v = Vector2.down;
            animator.SetBool("isClimb", true);
        }

        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            v = Vector2.up;
            animator.SetBool("isClimb", true);
        }

        
        transform.position += speed * Time.deltaTime * v;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "map")
        {
            isJump = false;
            animator.SetBool("isJump", false);
        }

        if (collision.gameObject.tag == "monster")
        {
            GameManager.instance.lifeDown();
        }

        if (collision.gameObject.tag == "potbug")
        {
            GameManager.instance.lifeDown();
        }

        if (collision.gameObject.tag == "trap")
        {
            GameManager.instance.lifeDown();
        }

        if (collision.gameObject.tag == "carrot")
        {
            carrotcount--;
            audioSourse.clip = item;
            audioSourse.Play();
            if (carrotcount == 0)
            {
                SceneManager.LoadScene("Clear");
            }
        }

        if (collision.gameObject.tag == "notCarrot")
        {
            audioSourse.clip = bug;
            audioSourse.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isLadder = true;
        }

        if (collision.gameObject.tag == "trigger")
        {
            GameManager.instance.lifeDown();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isLadder = false;
            rigid.gravityScale = 1f;
            animator.SetBool("isClimb", false);
        }
    }
}
