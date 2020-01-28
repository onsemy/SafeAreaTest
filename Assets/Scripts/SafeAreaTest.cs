using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeAreaTest : MonoBehaviour
{
    private Rect _lastSafeArea;
    // Start is called before the first frame update
    private void Start()
    {
        if (_lastSafeArea != Screen.safeArea)
        {
            _lastSafeArea = Screen.safeArea;
        }
    }

    private void OnGUI()
    {
        if (_lastSafeArea != Screen.safeArea)
        {
            _lastSafeArea = Screen.safeArea;
        }

        GUI.Box(_lastSafeArea, "Safe Area");
    }

    private void OnRectTransformDimensionsChange()
    {
        Debug.Log("[SafeAreaTest::OnRectTransformDimensionsChange] Event On!");
        var currentOrientation = Screen.orientation;
        if (_lastSafeArea != Screen.safeArea)
        {
            _lastSafeArea = Screen.safeArea;
            Debug.Log("[SafeAreaTest::OnRectTransformDimensionsChange] Changed Safe Area!");
        }
    }
}
