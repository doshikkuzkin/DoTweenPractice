using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Transform centerPoint;
    [SerializeField] private Transform pausePanel;
    [SerializeField] private Transform playButton;
    
    private float pausePanelStartY;
    private bool isPause;
    
    void Start()
    {
        pausePanelStartY = pausePanel.position.y;
        pausePanel.localScale = Vector3.zero;
    }

    public void ShowPauseMenu()
    {
        var positionY = isPause ? pausePanelStartY : centerPoint.position.y;
        pausePanel.DOMoveY(positionY, 1f);
        
        var scale = isPause ? Vector3.zero : Vector3.one;
        pausePanel.DOScale(scale, 1f);

        if (isPause)
        {
            var sequence = DOTween.Sequence();
            sequence.Append(playButton.DOScale(Vector3.one, 0.5f).SetEase(Ease.InBack));
            sequence.Append(playButton.DOShakeRotation(0.5f, new Vector3(0,0,120f), 10, 30, true));
        }
        else
        {
            playButton.DOScale(Vector3.zero, 0.5f);
        }
        
        isPause = !isPause;
    }
}
