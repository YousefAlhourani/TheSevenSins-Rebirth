﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ScrollRect))]
public class DropDownAutoScroll : MonoBehaviour
{
    RectTransform scrollRectTransform;
    RectTransform contentPanel;
    RectTransform selectedRectTransform;
    GameObject lastSelected;
    Vector2 targetPos;
    
    void Start()
    {
        scrollRectTransform = GetComponent<RectTransform>();
        if (contentPanel == null)
        {
            contentPanel = GetComponent<ScrollRect>().content;
        }
        targetPos = contentPanel.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        AutoScroll();
    }
    public void AutoScroll()
    {
        if (contentPanel == null)
        {
            contentPanel = GetComponent<ScrollRect>().content;
        }
        GameObject selected = EventSystem.current.currentSelectedGameObject;
        if (selected == null)
        {
            return;
        }
        if (selected.transform.parent != contentPanel.transform)
        {
            return;
        }
        if (selected == lastSelected)
        {
            return;

        }
        selectedRectTransform = (RectTransform)selected.transform;
        targetPos.x = contentPanel.anchoredPosition.x;
        targetPos.y = -(selectedRectTransform.localPosition.y) - (selectedRectTransform.rect.height / 2);
        targetPos.y = Mathf.Clamp(targetPos.y, 0, contentPanel.sizeDelta.y - scrollRectTransform.sizeDelta.y);

        contentPanel.anchoredPosition = targetPos;
        lastSelected = selected;
    }
}

