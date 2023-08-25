using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class EnemyScenceConfig : Singleton<EnemyScenceConfig>
{
    [SerializeField]
    public List<EnemyActionPoint> lsEAP = new List<EnemyActionPoint>();
    [SerializeField]
    private EnemyActionPoint prefab;
    public ConfigEnemyAction configEnemyAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnAddEnemyActionPoint()
    {
        EnemyActionPoint enemyActionPoint = Instantiate(prefab);
        lsEAP.Add(enemyActionPoint);
        enemyActionPoint.transform.SetParent(transform);
        enemyActionPoint.name = "EAP_" + lsEAP.Count.ToString();
    }
    public EnemyActionPoint GetPointById(int id)
    {
        return lsEAP[id - 1];
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
      
        for(int i=1;i<= lsEAP.Count;i++)
        {

            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.cyan;
            style.fontSize = 15;
            Handles.Label(lsEAP[i-1].transform.position + Vector3.up*4, i.ToString(), style);
        }
    }
#endif
}
