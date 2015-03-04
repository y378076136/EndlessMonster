using UnityEngine;
using System.Collections;

public class ELHeroController : MonoBehaviour {
    private Animator m_Animator;
    private Rigidbody2D m_Rigidbody;
    public float m_MoveSpeed;

    public System.Action<float> OnKillEnemy;

	void Start () 
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = rigidbody2D;
        m_Animator.SetFloat("Speed", 1);
        //m_Rigidbody.AddForce(new Vector2(Time.deltaTime, 0));
	}
	
    void FixedUpdate()
    {
        m_Rigidbody.velocity = new Vector2(m_MoveSpeed, 0);
    }

	void Update () 
    {
        //transform.Translate(Time.deltaTime, 0, 0);
        if(Input.GetMouseButtonDown(0))
        {
            m_Animator.SetTrigger("Shoot");
        }
	}
}
