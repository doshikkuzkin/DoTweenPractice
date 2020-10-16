using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RotatingLoad : MonoBehaviour
{
    [SerializeField] private Transform image1;
    [SerializeField] private Transform image2;
    
    private Vector3 rot1 = new Vector3(0,0,360);
    private Vector3 rot2 = new Vector3(0,0,-360);

    private void Start()
    {
        image1.DORotate(rot1, 1f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        image2.DORotate(rot2, 1f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }
}
