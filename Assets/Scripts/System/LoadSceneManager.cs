using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class LoadSceneManager : Singleton<LoadSceneManager>
{
    private Coroutine coroutine_;
    public void LoadSceneIndex(int index, Action callback)
    {
        if (coroutine_ != null)
            StopCoroutine(coroutine_);
        coroutine_ = StartCoroutine(LoadingSceneIndex(index, callback));
    }
    IEnumerator LoadingSceneIndex(int index, Action callback)
    {
        AsyncOperation progress_ = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
        WaitForSeconds wait = new WaitForSeconds(0.1f);
        while (!progress_.isDone)
            yield return wait;

        yield return new WaitForSeconds(1);
        callback?.Invoke();
    }
}
