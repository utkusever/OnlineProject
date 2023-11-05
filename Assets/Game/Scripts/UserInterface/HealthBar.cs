using System;
using DG.Tweening;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : NetworkBehaviour
{
    [SerializeField] float max;
    [SerializeField] Image healthBarFill;
    [SerializeField] RectTransform healthBarRect;
    [SerializeField] private Health health;

    private readonly Vector3 punchScale = new Vector3(0.3f, 0.3f, 0.3f);
    private readonly Vector3 stockScale = Vector3.one;

    private void OnEnable()
    {
        health.healthPoint.OnValueChanged += UpdateBar;
    }


    private void OnDisable()
    {
        health.healthPoint.OnValueChanged += UpdateBar;
    }

    public void UpdateBar(int previousvalue, int newvalue)
    {
        DOTween.Sequence()
            .Append(healthBarRect.transform.DOPunchScale(punchScale, 0.1f, 2)).SetEase(Ease.InFlash)
            .Append(healthBarRect.transform.DOScale(stockScale, 0.1f));
        healthBarFill.DOFillAmount((newvalue/ max), 0.3f);
    }
}