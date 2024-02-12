using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class VignetteDamage : MonoBehaviour
{
    [SerializeField] private Image imageVignette;
    
    public void PlayVignette(float duration) =>
        imageVignette.DOFade(0.2f, duration)
            .SetLoops(2, LoopType.Yoyo)
            .SetEase(Ease.OutQuint)
            .OnStart(() => imageVignette.color = new Color(1f, 1f, 1f, 0f));
}
