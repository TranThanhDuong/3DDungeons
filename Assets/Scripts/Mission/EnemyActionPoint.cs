using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public enum EAP_Type
{
    IDLE=1,
    WALK=2,
    RUN=3,
    SPAWN=4,
    JUMP=5,
    SWINGSWORD=6,
    DASH=7
}
public class EnemyActionPoint : MonoBehaviour
{
    public EAP_Type EAPtype;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, Vector3.one);
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.magenta;
        style.fontSize = 15;
        Handles.Label(transform.position + Vector3.up, EAPtype.ToString(), style);
    }
#endif


}
