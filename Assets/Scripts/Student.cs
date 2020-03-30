using UnityEngine;
using System.Collections;

public class Student : MonoBehaviour {

    public float      m_speed = 1.0f;
    public float      m_jumpForce = 2.0f;

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    public bool                m_grounded;


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
	
	// Update is called once per frame
	void Update () {

        // m_grounded = Physics2D.IsTouchingLayers(m_Collider, whatIsGround);
        // Find Ground
        m_grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);


        // Speed
        m_body2d.velocity = new Vector2(m_speed, m_body2d.velocity.y);


        //mymove
        float moveDistance = 1.0f;
        GetComponent<SpriteRenderer>().flipX = true;
        m_body2d.velocity = new Vector2(moveDistance * m_speed, m_body2d.velocity.y);
        m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);

    
        //Jump
             if (Input.GetKeyDown("space") && m_grounded) {
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);

        }
        else if(moveDistance>0) m_animator.SetInteger("AnimState", 2);

        //Idle
        else
            m_animator.SetInteger("AnimState", 0);

        if (m_body2d.position.y < -2f)
        {
            FindObjectOfType<GameManager>().GameOver();
        }

    }
    // KillBox
  /*  private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "killbox")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
    */

}
