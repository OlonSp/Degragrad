using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[ExecuteAlways]
public class SliderUI : MonoBehaviour, IDragHandler
{
    public RectTransform fillArea;
    public RectTransform handle;
    public Image fillImg;
    public float startDelta;

    [Range(0, 1)]
    public float percent;

    public Vector2 xBorders;

    private RectTransform _rect;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        float screenCenter = ControllerUI.inst.screen.width * _rect.pivot.x;
        float clickLocalPosition = Mathf.Clamp(eventData.position.x - screenCenter + startDelta, 0, _rect.rect.width);
        percent = (clickLocalPosition / _rect.rect.width);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (fillArea is null || handle is null || fillImg is null || fillImg.type != Image.Type.Filled) return;
        float startX = fillArea.rect.xMin + xBorders.x;
        float deltaX = (fillArea.rect.width - xBorders.y) * percent;
        handle.anchoredPosition = new Vector2(startX + deltaX, handle.anchoredPosition.y);
        fillImg.fillAmount = percent;
    }
}
