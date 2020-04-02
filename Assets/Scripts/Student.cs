using UnityEngine;

public class Student : MonoBehaviour {

    public float      m_speed = 1.0f;
    public float      m_jumpForce = 2.0f;

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    public bool                m_grounded;
    public bool isFirstJump;

    public float speedMultiplier;
    private float speedCount;
    public float speedIncrease;

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
            FindObjectOfType<ScoreMenager>().isScoring = true;
        }
    }
    
    // Update is called once per frame
    void Update () {

        // m_grounded = Physics2D.IsTouchingLayers(m_Collider, whatIsGround);
        // Find Ground
        m_grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (transform.position.x > speedCount)
        {
            speedCount += speedIncrease;

            m_speed = m_speed * speedMultiplier;
        }

        // Speed
        m_body2d.velocity = new Vector2(m_speed, m_body2d.velocity.y);


        //mymove
        float moveDistance = 1.0f;
        GetComponent<SpriteRenderer>().flipX = true;
        m_body2d.velocity = new Vector2(moveDistance * m_speed, m_body2d.velocity.y);
        m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);

        if (m_body2d.position.y < -2f)
        {
            FindObjectOfType<GameManager>().GameOver();
        }

        //Jump
        ///*
             if (Input.GetKeyDown("space") && (m_grounded  || isFirstJump)) {
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            if (isFirstJump == false) isFirstJump = true;
            else isFirstJump = false;
        }
        else if(moveDistance>0) m_animator.SetInteger("AnimState", 2);
        //*/

        //Jump on touch
        /*
        if (Input.GetTouch(0).phase == TouchPhase.Began && (m_grounded || isFirstJump))
        {
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            if (isFirstJump == false) isFirstJump = true;
            else isFirstJump = false;
        }
        else if (moveDistance > 0) m_animator.SetInteger("AnimState", 2);
        */

        //Idle
        else
            m_animator.SetInteger("AnimState", 0);

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
