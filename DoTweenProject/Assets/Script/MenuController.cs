using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button menuButton;
    [SerializeField] private Button trophyButton;
    [SerializeField] private Button gcButton;

    private Vector3 trophyBStartPos;
    private Vector3 gcBStartPos;

    [SerializeField]private Transform trophyBEndPos;
    [SerializeField]private Transform gcBEndPos;

    private bool menuOpened;
    private float duration = 0.5f;
    
    private void Start()
    {
        trophyBStartPos = trophyButton.transform.position;
        gcBStartPos = gcButton.transform.position;
        
        menuButton.onClick.AddListener(OpenMenu);
        trophyButton.onClick.AddListener(() => PressItem(trophyButton.transform));
        gcButton.onClick.AddListener(() => PressItem(gcButton.transform));
    }

    private void OpenMenu()
    {
        var trophyPos = menuOpened ? trophyBStartPos : trophyBEndPos.position;
        var gcPos = menuOpened ? gcBStartPos : gcBEndPos.position;

        var trophyScale = menuOpened ? Vector3.zero : Vector3.one;
        var gcScale = menuOpened ? Vector3.zero : Vector3.one;

        var secuence = DOTween.Sequence();
        secuence.Append(menuButton.transform.DOShakeRotation(duration, new Vector3(0,0,30f), 30, 90));

        secuence.Join(trophyButton.transform.DOMove(trophyPos, duration));
        secuence.Join(gcButton.transform.DOMove(gcPos, duration));
        secuence.Join(trophyButton.transform.DOScale(trophyScale, duration));
        secuence.Join(gcButton.transform.DOScale(gcScale, duration));
        secuence.Join(transform.DOShakeRotation(duration, new Vector3(0,0,30f), 30, 90));

        menuOpened = !menuOpened;
    }

    private void PressItem(Transform _transform)
    {
        var secuece = DOTween.Sequence();
        secuece.Append(_transform.DOScale(Vector3.one * 0.5f, 0.3f));
        secuece.Append(_transform.DOScale(Vector3.one, 0.3f));
    }
}
