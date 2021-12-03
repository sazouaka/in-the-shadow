using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this means this script will be attached to only object with light component

[RequireComponent(typeof(Light))]

public class LightControl : MonoBehaviour
{
    private Light _light;
    void Start()
    {
        // we catch the light component of spotlight object
        _light = GetComponent<Light>();
    }

    void Update()
    {
        _light.color = globalVar.lightColor;
    }
}
