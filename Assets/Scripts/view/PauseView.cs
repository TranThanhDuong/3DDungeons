using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class PauseView : BaseView
{
    public override void OnSetup(ViewParam param)
    {
        base.OnSetup(param);
        Time.timeScale = 0;
    }

    public void OnRetry()
    {
        DOTween.Clear(true);
        LoadSceneManager.instance.LoadSceneIndex(0, () =>
        {
        });
    }    

    public void QuitGame()
    {
        Application.Quit();
    }

    public override void OnHideView()
    {
        base.OnHideView();
        Time.timeScale = 1;
    }
}
