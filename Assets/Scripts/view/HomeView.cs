using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HomeView : BaseView
{
    public override void OnSetup(ViewParam param)
    {
        base.OnSetup(param);
    }

    public void OnStartGame()
    {
        LoadSceneManager.instance.LoadSceneIndex(1, () =>
        {
            ViewManager.instance.OnSwitchView(ViewIndex.EmptyView);
        });
    }

    public void OnLeaveGame()
    {
        Application.Quit();
    }
    public void OnSound()
    {

    }
   
    public void OnRank()
    {

    }
}
