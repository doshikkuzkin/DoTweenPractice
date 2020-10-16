using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ScaleRotateLoad : MonoBehaviour
{
    [SerializeField] private Transform axis;
    [SerializeField] private Transform image1;
    [SerializeField] private Transform image2;
    
    private Vector3 rot1 = new Vector3(0,0,-360);

    private void Start()
    {
        transform.DORotate(rot1, 1f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(image1.DOScale(Vector3.one, 0.5f))
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart)
            .Append(image1.DOScale(Vector3.zero, 0.5f))
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);
        
        
        Sequence seq2 = DOTween.Sequence();
        seq2.Append(axis.DORotate(rot1, 0.9f, RotateMode.FastBeyond360)).SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart)
            .AppendInterval(0.1f);
        
        Sequence seq3 = DOTween.Sequence();
        seq3.Append(image2.DOScale(Vector3.one, 0.45f))
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart)
            .Append(image2.DOScale(Vector3.zero, 0.45f))
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart)
            .AppendInterval(0.1f);
    }
}
