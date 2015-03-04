using UnityEngine;
using System.Collections;

public class ELMonster : MonoBehaviour {

    public float m_HP = 2000;

    private HUDText m_HudText;

    public float m_MoveSpeed = 2.5f;

	void Start () {
        Flip();
        Init();
	}
	
	void Update () 
    {
        //if(Input.GetMouseButtonDown(0))
        //{
        //    Hit(20);
        //}
	}

    void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(-m_MoveSpeed + ELConstant.FloorRollSpeed, 0);
        //rigidbody2D.AddForce(new Vector2(-m_MoveSpeed, 0));
    }

    public void Flip()
    {
        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }

    public void Hit(float value)
    {
        m_HudText.Add(value, Color.red, ELConstant.HUDTextStayDuration);
        m_HP -= value;
        if (m_HP < 0)
            Destroy(gameObject);
    }

    public void Init()
    {
        m_HudText = ELUIMain.MakeHudText(transform.FindChild("UIPoint"));
    }
}
