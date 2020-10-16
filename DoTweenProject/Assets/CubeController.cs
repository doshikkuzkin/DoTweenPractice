using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 startRotation;

    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation.eulerAngles;
    }

    public void PlayAnimation()
    {
        var targetPosition = transform.up * 3;
        var duration = 1f;
        var eulerAnglesX = new Vector3(270f, 0f, 0f);
        var eulerAnglesZ = new Vector3(0f, 0f, 270f);
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(targetPosition, duration));
        sequence.Join(transform.DORotate(eulerAnglesX, duration, RotateMode.FastBeyond360));
        sequence.AppendInterval(0.5f);
        sequence.Append(transform.DOScale(Vector3.one * 0.75f, 0.3f));
        sequence.Append(transform.DOScale(Vector3.one * 2f, 1f));
        sequence.Join(transform.DORotate(eulerAnglesZ, duration, RotateMode.LocalAxisAdd));
        sequence.Append(transform.DOScale(Vector3.one, 0.2f));
        sequence.Append(transform.DOMove(startPosition, duration));
        sequence.Join(transform.DORotate(startRotation, duration));
        sequence.OnComplete(OnComplete);
    }

    private void OnComplete()
    {
        Debug.Log("Complete");
    }
}
