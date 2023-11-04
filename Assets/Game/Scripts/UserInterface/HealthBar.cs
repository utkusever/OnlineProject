using DG.Tweening;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : NetworkBehaviour
{
    [SerializeField] float max;
    [SerializeField] Image healthBarFill;
    [SerializeField] RectTransform healthBarRect;
    private readonly Vector3 punchScale = new Vector3(0.3f, 0.3f, 0.3f);
    private readonly Vector3 stockScale = Vector3.one;

    public void UpdateBar(NetworkVariable<float> currentHealth)
    {
        DOTween.Sequence()
                        .Append(healthBarRect.transform.DOPunchScale(punchScale, 0.1f, 2)).SetEase(Ease.InFlash)
                        .Append(healthBarRect.transform.DOScale(stockScale, 0.1f));
        healthBarFill.DOFillAmount((currentHealth.Value / max), 0.3f);
    }
}
