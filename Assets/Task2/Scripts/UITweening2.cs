using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class UITweening2 : MonoBehaviour
{
    [SerializeField] GameObject restartbutton , bgimage;
    CanvasGroup BG;

    // Start is called before the first frame update
    void Start()
    {
        BG = bgimage.GetComponent<CanvasGroup>();

    }

    public void startTween()
    {
        DOTween.To(x => BG.alpha = x, 0, 1, 0.8f);

        restartbutton.transform.DOScaleX(1, 1f).SetEase(Ease.OutBounce).SetDelay(0.2f);
        restartbutton.transform.DOScaleY(1, 1f).SetEase(Ease.OutBounce).SetDelay(0.2f);
    }
}
