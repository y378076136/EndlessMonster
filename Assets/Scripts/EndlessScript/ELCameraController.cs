using UnityEngine;
using System.Collections;

public class ELCameraController : MonoBehaviour {

    public GameObject m_FocusObject;
    private Transform m_Transform;

    private Vector3 m_TargetPosition;
    public float m_LerpFactor = .5f;

	void Start () {
	    if(!m_FocusObject)
        {
            Debug.LogError("focus object is null");
            return;
        }
        m_Transform = transform;
        m_TargetPosition = m_Transform.position;
        SetTargetPosition(m_FocusObject.transform.position);
	}
	

	void Update () 
    {
        m_Transform.position = Vector3.Lerp(m_Transform.position, m_TargetPosition, m_LerpFactor);

        if (m_FocusObject.transform.position.x > m_Transform.position.x)
        {
            //SetTargetPosition(m_focusObject.transform.position);
            Vector3 v = m_FocusObject.transform.position;
            v.x = m_Transform.position.x;
            m_FocusObject.transform.position = v;
            ELFloorController.StartRoll = true;
        }
        else
        {
            ELFloorController.StartRoll = false;
        }
	}

    private void SetTargetPosition(Vector3 position)
    {
        m_TargetPosition.x = position.x;
        m_TargetPosition.y = position.y;
    }
}
