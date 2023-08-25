using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleIdle : FSMState
{
    private FSMSampleData data;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void EnterAction(FSMData data)
    {
        this.data = (FSMSampleData)data;
        StartCoroutine("WaitSwitch");
    }
    IEnumerator WaitSwitch()
    {
        yield return new WaitForSeconds(2);
        data.parent.SwitchAction(Actionkey.MOVE,data);
    }
    public override void ExitAction()
    {
        StopAllCoroutines();
    }
}
