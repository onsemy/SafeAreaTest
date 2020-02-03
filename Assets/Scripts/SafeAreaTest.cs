using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeAreaTest : MonoBehaviour
{
    private Rect _lastSafeArea;

    private Rect[] _lastCutOuts;

    [SerializeField] private RectTransform _rtSafeArea;
    [SerializeField] private RectTransform[] _rtCutOuts;
    
    // Start is called before the first frame update
    private void Start()
    {
        if (_lastSafeArea != Screen.safeArea)
        {
            _lastSafeArea = Screen.safeArea;
            _rtSafeArea.anchoredPosition = _lastSafeArea.position;
            _rtSafeArea.sizeDelta = _lastSafeArea.size;
        }

        if (_lastCutOuts != Screen.cutouts)
        {
            _lastCutOuts = Screen.cutouts;
            for (int i = 0; i < _rtCutOuts.Length; ++i)
            {
                if (i >= _lastCutOuts.Length)
                {
                    break;
                }

                _rtCutOuts[i].anchoredPosition = _lastCutOuts[i].position;
                _rtCutOuts[i].sizeDelta = _lastCutOuts[i].size;
            }
        }
    }

    private void Update()
    {
        if (_lastSafeArea != Screen.safeArea)
        {
            _lastSafeArea = Screen.safeArea;
            _rtSafeArea.anchoredPosition = _lastSafeArea.position;
            _rtSafeArea.sizeDelta = _lastSafeArea.size;
            Debug.Log($"Changed SafeArea: {_lastSafeArea.position}/{_lastSafeArea.size}");
        }

        if (_lastCutOuts != Screen.cutouts)
        {
            _lastCutOuts = Screen.cutouts;
            for (int i = 0; i < _rtCutOuts.Length; ++i)
            {
                if (i >= _lastCutOuts.Length)
                {
                    break;
                }

                _rtCutOuts[i].anchoredPosition = _lastCutOuts[i].position;
                _rtCutOuts[i].sizeDelta = _lastCutOuts[i].size;
                Debug.Log($"Changed CutOuts{i}: {_lastCutOuts[i].position}/{_lastCutOuts[i].size}");
            }
        }
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
