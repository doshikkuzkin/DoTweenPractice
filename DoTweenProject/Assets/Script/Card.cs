using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Sprite backSprite;
    [SerializeField] private Sprite frontSprite;
    private Button button;
    private Image image;
    private bool inHand;
    private Transform _transform;
    private RectTransform _rectTransform;
    private float duration;
    private bool isScaled;
    private float yPos;

    private static float lastCardX = default;

    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        _rectTransform = GetComponent<RectTransform>();
        duration = 0.5f;
        
        button.onClick.AddListener(MoveToHand);
    }

    private void Start()
    {
        image.sprite = backSprite;
        _transform = transform;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isScaled)
        {
            ScaleCard(Vector3.one * 1.25f);
            _transform.SetAsLastSibling();
            if (inHand)
            {
                MoveCard(yPos + 100f);
            }
        }
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        if (isScaled)
        {
            ScaleCard(Vector3.one);
            if (inHand)
            {
                MoveCard(yPos);
            }
        }
    }

    private void ScaleCard(Vector3 _scale)
    {
        _transform.DOScale(_scale, duration);
        isScaled = !isScaled;
    }

    private void MoveCard(float posY)
    {
        _rectTransform.DOAnchorPos(new Vector2(_rectTransform.anchoredPosition.x, posY), 0.3f);
    }

    private void MoveToHand()
    {
        if (!inHand)
        {
            button.enabled = false;
            lastCardX += 200f;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(_rectTransform.DOAnchorPos(new Vector2(lastCardX, -435f), 0.5f)
                    .SetEase(Ease.Linear))
                .Join(_rectTransform.DORotate(new Vector3(0, 90, 0), 0.5f).SetEase(Ease.Linear).OnComplete(Flip))
                .Append(_rectTransform.DOAnchorPos(new Vector2(lastCardX, -870f), 0.5f)
                    .SetEase(Ease.Linear))
                .Join(_rectTransform.DORotate(new Vector3(0, 0, 0), 0.5f).SetEase(Ease.Linear))
                .OnComplete(() =>
                {
                    yPos = _rectTransform.anchoredPosition.y;
                    inHand = true;
                    button.enabled = true;
                });
        }
        else
        {
            button.enabled = false;
            _rectTransform.DOShakeRotation(0.5f, new Vector3(0, 0, 30f), 30, 90)
                .OnComplete(() => button.enabled = true);
        }
    }

    private void Flip()
    {
        image.sprite = frontSprite;
    }
}
