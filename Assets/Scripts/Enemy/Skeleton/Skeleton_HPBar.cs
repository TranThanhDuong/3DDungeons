using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skeleton_HPBar : MonoBehaviour
{
    public Image fgImage;
    public float updateSpeed = 0.5f;
    public void Awake()
    {
        GetComponentInParent<Skeleton>().OnHPChange += HPBar_OnHPChange;
    }

    private void HPBar_OnHPChange(float ptc)
    {
        StartCoroutine(ChangeToPercent(ptc));
    }

    public IEnumerator ChangeToPercent(float ptc)
    {
        float preChange = fgImage.fillAmount;
        float elapsed = 0f;
        while (elapsed<= updateSpeed)
        {
            elapsed += Time.deltaTime;
            fgImage.fillAmount = Mathf.Lerp(preChange, ptc, elapsed / updateSpeed);
            yield return null;
        }

        fgImage.fillAmount = ptc;
    }

    public void Update()
    {
        if(fgImage.fillAmount > 0)
            this.transform.LookAt(transform.position + Camera.main.transform.forward);
    }
}
