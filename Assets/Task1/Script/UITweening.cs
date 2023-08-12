using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UITweening : MonoBehaviour
{
    [SerializeField] GameObject dropdown;

    // Start is called before the first frame update
    void Start()
    {
        dropdown.transform.DOScaleX(1, 1f).SetEase(Ease.OutBounce).SetDelay(0.2f);
        dropdown.transform.DOScaleY(1, 1f).SetEase(Ease.OutBounce).SetDelay(0.2f);
    }
}
