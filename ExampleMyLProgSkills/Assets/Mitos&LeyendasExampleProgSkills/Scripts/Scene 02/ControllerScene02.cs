using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerScene02 : MonoBehaviour {
    public Light fillLight, rimLight;
    public SpriteRenderer spriteOfLightSource;
    public GameObject vfxRain;

    public GameObject listVehicles;

    public Text txtBtnChangePrevWeather, txtBtnChangeNextWeather, txtCurrentWeather;

    public LightsConfiguration[] lightsConfigurationByWeather;

    GameObject[] Vehicles;
    
    string[] dictionaryStatusWeather = new string[4];

    int currentVehicle = 0;
    int currentWeather = 0;

    public void configurateLights(int currentNumberLightConfiguration)
    {
        LightsConfiguration currentLightConfiguration = lightsConfigurationByWeather[currentNumberLightConfiguration];
        RenderSettings.skybox = currentLightConfiguration.currentSkyBox;
        RenderSettings.ambientLight = currentLightConfiguration.ambientColor;
        fillLight.color = currentLightConfiguration.fillLightColor;
        rimLight.color = currentLightConfiguration.rimLightColor;
        if(currentNumberLightConfiguration == 1)
        {
            vfxRain.SetActive(true);
        }
        else
        {
            vfxRain.SetActive(false);
        }
        if(currentLightConfiguration.lightObject != null)
        {
            if (currentNumberLightConfiguration == 2)
                spriteOfLightSource.color = Color.white;
            else
                spriteOfLightSource.color = Color.red;
            spriteOfLightSource.sprite = currentLightConfiguration.lightObject;
        }
        else
        {
            spriteOfLightSource.sprite = null;
        }
    }

	// Use this for initialization
	void Start () {

        Vehicles = new GameObject[listVehicles.transform.childCount];
        for (int i = 0; i < Vehicles.Length; i++)
        {
            Vehicles[i] = listVehicles.transform.GetChild(i).gameObject;
        }

        dictionaryStatusWeather[0] = "Sunny day";
        dictionaryStatusWeather[1] = "Rainy day";
        dictionaryStatusWeather[2] = "Full moon night";
        dictionaryStatusWeather[3] = "Bloody Night";
        
        txtCurrentWeather.text = dictionaryStatusWeather[0];

        setTxtNextOrPrevWeather(false);
        setTxtNextOrPrevWeather(true);
    }
    
    void setTxtNextOrPrevWeather(bool nextOrPrevious)
    {
        if (nextOrPrevious)
        {
            if ((currentWeather + 1) >= dictionaryStatusWeather.Length)
            {
                txtBtnChangeNextWeather.text = dictionaryStatusWeather[0] + "\nv";
            }
            else
            {
                txtBtnChangeNextWeather.text = dictionaryStatusWeather[currentWeather + 1] + "\nv";
            }
        }
        else
        {
            if ((currentWeather - 1) < 0)
            {
                txtBtnChangePrevWeather.text = "^\n" + dictionaryStatusWeather[dictionaryStatusWeather.Length - 1];
            }
            else
            {
                txtBtnChangePrevWeather.text = "^\n" + dictionaryStatusWeather[currentWeather - 1];
            }
        }
    }

    public void showPreviousWeather()
    {
        changeWeather(-1);
    }

    public void showNextWeather()
    {
        changeWeather(1);
    }

    public void changeWeather(int dir)
    {
        currentWeather += dir;
        if (currentWeather >= dictionaryStatusWeather.Length)
        {
            currentWeather = 0;
        }
        if (currentWeather < 0)
        {
            currentWeather = dictionaryStatusWeather.Length - 1;
        }
        setTxtNextOrPrevWeather(false);
        setTxtNextOrPrevWeather(true);
        txtCurrentWeather.text = dictionaryStatusWeather[currentWeather];
        configurateLights(currentWeather);
    }

    public void showPreviousVehicle()
    {
        changeVehicle(-1);
    }

    public void showNextVehicle()
    {
        changeVehicle(1);
    }

    public void changeVehicle(int dir)
    {
        Vehicles[currentVehicle].SetActive(false);
        currentVehicle += dir;
        if (currentVehicle >= Vehicles.Length)
        {
            currentVehicle = 0;
        }
        if (currentVehicle < 0)
        {
            currentVehicle = Vehicles.Length - 1;
        }

        Vehicles[currentVehicle].SetActive(true);
    }
}
