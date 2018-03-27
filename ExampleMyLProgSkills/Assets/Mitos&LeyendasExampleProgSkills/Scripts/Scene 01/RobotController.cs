using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour {
    public GameObject[] spheresColors;
    int currentIndexColor = 0;
    public void changeColor(int colorIndex)
    {
        spheresColors[currentIndexColor].SetActive(false);
        spheresColors[colorIndex].SetActive(true);
        currentIndexColor = colorIndex;
    }
}
