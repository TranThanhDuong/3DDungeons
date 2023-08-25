using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FSMSystem : MonoBehaviour
{
    public string folderName;
    private Dictionary<Actionkey, FSMState> dicAction = new Dictionary<Actionkey, FSMState>();
    public FSMState currentState;
    // Start is called before the first frame update

    public void SwitchAction(Actionkey actionkey,FSMData data,Action<object> callBack=null)
    {
        if (currentState != null)
        {
            currentState.ExitAction();
            currentState.gameObject.SetActive(false);
        }
        if(dicAction.ContainsKey(actionkey))
        {
            currentState = dicAction[actionkey];
        }
        else
        {
            // tao 
            GameObject stateObj = Instantiate(Resources.Load(folderName+"/Action/" + actionkey.ToString(), typeof(GameObject))) as GameObject;
            stateObj.transform.SetParent(transform);
            FSMState state = stateObj.GetComponent<FSMState>();
            currentState = state;
            dicAction.Add(actionkey, state);
        }
        currentState.gameObject.SetActive(true);
        currentState.EnterAction(data);
        callBack?.Invoke(null);
    }
}
