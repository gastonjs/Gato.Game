﻿using Cinemachine;
using UnityEngine;


public class CinemachineCoreGetInputTouchAxis : MonoBehaviour
{

    public float TouchSensitivity_x;
    public float TouchSensitivity_y;

    // Use this for initialization
    void Start()
    {
        CinemachineCore.GetInputAxis = HandleAxisInputDelegate;
    }

    float HandleAxisInputDelegate(string axisName)
    {
        switch (axisName)
        {

            case "Mouse X":

                if (Input.touchCount > 0)
                {
                    return Input.touches[0].deltaPosition.x / TouchSensitivity_x;
                }
                else
                {
                    return Input.GetAxis(axisName);
                }

            case "Mouse Y":
                if (Input.touchCount > 0)
                {
                    return Input.touches[0].deltaPosition.y / TouchSensitivity_y;
                }
                else
                {
                    return Input.GetAxis(axisName);
                }

            default:
                Debug.LogError("Input <" + axisName + "> not recognyzed.", this);
                break;
        }

        return 0f;
    }
}