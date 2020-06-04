using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Student : MonoBehaviour {

    public float      m_speed = 1.0f;
    public float      m_jumpForce = 2.0f;
    public float normalSpeed = 1.0f;
    public float scoreCounter;

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    public bool                m_grounded;
    public bool isFirstJump;

    public float speedMultiplier;
    private float speedCount;
    public float speedIncrease;
    public bool safeMode=false;
    public bool isHigh = false;

  //  private Collider2D m_Collider;
  //  public GameManager theGameManager;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;
    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
      //  m_Collider = GetComponent<Collider2D>();

    }
     
    private void OnTriggerEnter2D(Collider2D m_collider)
    {
        if (m_collider.gameObject.tag == "killbox")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        if (m_collider.gameObject.tag == "gate")
        {
            try{
                FindObjectOfType<ScoreManager>().isScoring = true;
            }
            catch (NullReferenceException ex)
            {
                Debug.Log("ScoreMenager was not set in the inspector");
            }
        }
        if(m_collider.gameObject.tag == "lastPlatform")
        {
            FindObjectOfType<GameManager>().NextLevel();
        }
    }
    
    // Update is called once per frame
    void Update () {
        // Find Ground
        if (!safeMode)
        {
            m_grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
            if (m_grounded)
                this.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }
        else m_grounded = true;

        if (transform.position.x > speedCount)
        {
            speedCount += speedIncrease;

            m_speed = m_speed * speedMultiplier;
            normalSpeed = normalSpeed * speedMultiplier;
        }

        // Speed
        m_body2d.velocity = new Vector2(m_speed, m_body2d.velocity.y);


        //mymove
        float moveDistance = 1.0f;
        GetComponent<SpriteRenderer>().flipX = true;
        m_body2d.velocity = new Vector2(moveDistance * m_speed, m_body2d.velocity.y);
        m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);
        m_animator.SetBool("Grounded", m_grounded);
        m_animator.SetBool("Jump", false);
        if (m_body2d.position.y < -2f)
        {
            FindObjectOfType<GameManager>().GameOver();
        }

        //Jump

        //if (safeMode && Input.GetKeyDown("space")) Debug.Log("in");
       
        if (Input.GetKeyDown("space") && (m_grounded || isFirstJump ))
        {
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            if (isFirstJump == false) { 
                isFirstJump = true;            
            } 

            else isFirstJump = false;
            
        }

        /* //Jump on touch
        if(Input.GetTouch(0).phase == TouchPhase.Began && (m_grounded || isFirstJump))
            {
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            if (isFirstJump == false) isFirstJump = true;
            else isFirstJump = false;
        }
        */



    }

    public void safeModeSwitch(bool safe)
    {
        if (safe)
        {
           m_animator.SetTrigger("Jump");
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            this.safeMode = true;
        }
        else
        {
            this.safeMode = false;
            this.isFirstJump = true;
        }
    }

    public void Unicorn(bool high)
    {
        if (high == true)
        {

            m_animator.SetBool("IsHigh", true);

        }
        else
 
        m_animator.SetBool("IsHigh", false);
    }





    // KillBox
    /*  private void OnCollisionEnter2D(Collision collisionInfo)
      {
          if (collisionInfo.collider.tag == "killbox")
          {
              FindObjectOfType<GameManager>().GameOver();
          }
      }
      */

}

