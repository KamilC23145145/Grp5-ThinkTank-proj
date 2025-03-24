using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TooltipText : MonoBehaviour
{
    private RectTransform TooltipBGRectTransform;
    private UnityEngine.UI.Image TooltipBGImage;
    private TextMeshProUGUI TooltipTextBox;
    private RectTransform TooltipRectTransform;
    [SerializeField] string InputText;
    [SerializeField] float rotation;
    private float offset;
    private CameraSystem PivotRef;
    private void Awake()
    {
        TooltipBGRectTransform = transform.Find("Background").GetComponent<RectTransform>();
        TooltipBGImage = transform.Find("Background").GetComponent<UnityEngine.UI.Image>();
        TooltipTextBox = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        TooltipRectTransform = transform.GetComponent<RectTransform>();
        PivotRef = GameObject.Find("Pivot").GetComponent<CameraSystem>();
        offset = rotation * 2 * Mathf.PI;
        SetText();
    }

    private void SetText()
    {
        TooltipTextBox.SetText(InputText);
        TooltipTextBox.ForceMeshUpdate();
        TooltipRectTransform.sizeDelta = new Vector2(
            TooltipTextBox.GetRenderedValues(false).x + 20.0f,
            TooltipTextBox.GetRenderedValues(false).y + 20.0f
            );
        TooltipBGRectTransform.sizeDelta = TooltipRectTransform.sizeDelta;
    }

    private void Update()
    {
        TooltipRectTransform.anchoredPosition = new Vector2(
            Mathf.Sin(PivotRef.mouse_rotation.x / 180 * Mathf.PI + offset) * 200,
            Mathf.Cos(PivotRef.mouse_rotation.x / 180 * Mathf.PI + Mathf.PI + offset) * 200
            );
        print(((PivotRef.mouse_rotation.x % 360) + 360) % 360);
        if (50 > ((PivotRef.mouse_rotation.x % 360) + 360) % 360 || ((PivotRef.mouse_rotation.x % 360) + 360) % 360 > 310) 
        {
            TooltipBGImage.color = new Color(0, 0, 0, Mathf.Clamp(Mathf.Cos(PivotRef.mouse_rotation.x / 90 * Mathf.PI), 0, .6f));
            TooltipTextBox.color = new Color(1, 1, 1, Mathf.Clamp(Mathf.Cos(PivotRef.mouse_rotation.x / 90 * Mathf.PI), 0, .6f));
        }
        else
        {
            TooltipBGImage.color = new Color(0, 0, 0, 0);
            TooltipTextBox.color = new Color(1, 1, 1, 0);
        }
    }
}
