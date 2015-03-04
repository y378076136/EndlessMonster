using UnityEngine;
using System.Collections;

public class ELUIMain : MonoBehaviour {

    private static ELUIMain m_Instance = null;

    public GameObject m_TextPrefab;

    void Awake()
    {
        m_Instance = this;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void AddDamageText(float value, GameObject target)
    { 

    }

    public static HUDText MakeHudText(Transform target)
    {
        GameObject go = NGUITools.AddChild(HUDRoot.go, m_Instance.m_TextPrefab);
        go.AddComponent<UIFollowTarget>().target = target;
        return go.GetComponent<HUDText>();
    }
}
