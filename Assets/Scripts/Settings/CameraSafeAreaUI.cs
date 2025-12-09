using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class CameraSafeAreaUI : MonoBehaviour
{
    public Camera mainCamera;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        RectTransform rt = GetComponent<RectTransform>();
        Rect camRect = mainCamera.rect;

        rt.anchorMin = new Vector2(camRect.xMin, camRect.yMin);
        rt.anchorMax = new Vector2(camRect.xMax, camRect.yMax);
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;
    }
}

