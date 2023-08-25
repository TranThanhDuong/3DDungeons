using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : FSMSystem
{
    // Start is called before the first frame update
    void Start()
    {
        SwitchAction(Actionkey.IDLE, new FSMSampleData { parent=this}, null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
