using UnityEngine;
using System.Collections;

public class ELFloorController : MonoBehaviour {

    public Transform m_TransBase;

    public Transform m_Part1;
    public Transform m_Part2;

    private float m_FloorLength;

    public static bool StartRoll { set; get; }

    private Vector3 m_EndPoint;

	void Start () 
    {
        m_FloorLength = m_Part1.FindChild("env_Bank").GetComponent<SpriteRenderer>().bounds.size.x;
        m_EndPoint = m_Part2.position;
        m_EndPoint.x -= 2 * m_FloorLength;
        StartRoll = true;
	}
	
	void Update () 
    {
        if(StartRoll)
        {
            m_Part1.Translate(ELConstant.FloorRollSpeed * Time.deltaTime, 0, 0);
            m_Part2.Translate(ELConstant.FloorRollSpeed * Time.deltaTime, 0, 0);
            //m_TransBase.Translate(-m_RollSpeed * Time.deltaTime, 0, 0);


            if (m_Part1.position.x < m_EndPoint.x)
            {
                Vector3 v = m_Part2.position;
                v.x += m_FloorLength;
                m_Part1.position = v;
            }
            if (m_Part2.position.x < m_EndPoint.x)
            {
                Vector3 v = m_Part1.position;
                v.x += m_FloorLength;
                m_Part2.position = v;
            }
        }
	}

    private void Roll(Transform t)
    {
        t.Translate(ELConstant.FloorRollSpeed, 0, 0);
        if(t.position.x < m_EndPoint.x)
        {
            Vector3 v = t.position;
            v.x += 2 * m_FloorLength;
            t.position = v;
        }
    }
}
