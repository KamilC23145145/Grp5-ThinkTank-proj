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
    private RectTransform TooltipTextBoxRectTransform;
    private RectTransform TooltipRectTransform;
    private UnityEngine.UI.Image TooltipImage;
    private RectTransform TooltipImageRectTransform;
    [SerializeField] string InputText;
    [SerializeField] float rotation;
    [SerializeField] float rotationPos = 360;
    private float offset;
    private CameraSystem PivotRef;
    private void Awake()
    {
        TooltipBGRectTransform = transform.Find("Background").GetComponent<RectTransform>();
        TooltipBGImage = transform.Find("Background").GetComponent<UnityEngine.UI.Image>();
        TooltipTextBox = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        TooltipTextBoxRectTransform = transform.Find("Text").GetComponent<RectTransform>();
        TooltipRectTransform = transform.GetComponent<RectTransform>();
        PivotRef = GameObject.Find("Pivot").GetComponent<CameraSystem>();
        //TooltipImage = transform.Find("Image").GetComponent<UnityEngine.UI.Image>();
        //TooltipImageRectTransform = transform.Find("Image").GetComponent<RectTransform>();
        offset = rotation * 2 * Mathf.PI;
        SetText();
    }

    private void SetText()
    {
        TooltipRectTransform.sizeDelta = new Vector2(400, 200);
        TooltipBGRectTransform.sizeDelta = TooltipRectTransform.sizeDelta;
        TooltipTextBoxRectTransform.sizeDelta = new Vector2(400, 200);
        //TooltipImageRectTransform.sizeDelta = new Vector2(200, 200);
        TooltipTextBox.SetText(InputText);
        TooltipTextBox.ForceMeshUpdate();
    }

    private void Update()
    {
        TooltipRectTransform.anchoredPosition = new Vector2(
            Mathf.Sin(PivotRef.mouse_rotation.x / 180 * Mathf.PI + offset) * 600,
            Mathf.Cos(PivotRef.mouse_rotation.x / 180 * Mathf.PI + Mathf.PI + offset) * 300
            );
        float angle = (PivotRef.mouse_rotation.x - rotationPos) * Mathf.Deg2Rad;
        float alpha = Mathf.Clamp(Mathf.Cos(angle + Mathf.Sin(angle)), 0.0f, 0.8f); // normalize and scale to max alpha
        TooltipBGImage.color = new Color(0, 0, 0, alpha);
        TooltipTextBox.color = new Color(1, 1, 1, alpha);
        //TooltipImage.color = TooltipTextBox.color;
    }
}
