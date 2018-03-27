using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new LightsConfiguration", menuName = "LightsConfiguration")]
public class LightsConfiguration : ScriptableObject
{
    public Color ambientColor;

    public Color rimLightColor;
    public Color fillLightColor;

    public Sprite lightObject;
    public Material currentSkyBox;
}

