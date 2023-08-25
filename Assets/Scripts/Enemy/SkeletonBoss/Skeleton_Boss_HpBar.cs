using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skeleton_Boss_HpBar : MonoBehaviour
{
    public Image fgImage;
    public float updateSpeed = 0.5f;
    public void Awake()
    {
        GetComponentInParent<Skeleton_Boss>().OnHPBossChange += HpBar_OnHPBossChange;
    }

    private void HpBar_OnHPBossChange(float ptc)
    {
        StartCoroutine(ChangeToPercent(ptc));
    }

    public IEnumerator ChangeToPercent(float ptc)
    {
        float preChange = fgImage.fillAmount;
        float elapsed = 0f;
        while (elapsed <= updateSpeed)
        {
            elapsed += Time.deltaTime;
            fgImage.fillAmount = Mathf.Lerp(preChange, ptc, elapsed / updateSpeed);
            yield return null;
        }
        fgImage.fillAmount = ptc;
    }
}
