using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {
    public Text txtCharacterName;
    public Text txtDialog;
    public ControllerScene01 _scene01Controller;
    public RobotController robotLight;
    public string NameRobot;

    public GameObject panelofDialog;
    public GameObject panelofQuestionAnswers;

    bool showingDialog;
    public int currentQuestionIndex = -1;
    int currentDialog = 0;

    string[] currentText = new string[2] { "Hello human...", "Since you're here, I will ask you about... Well, it doesn't really matter *sighs* [Bip ... bop]" };

    string[] congratulations = new string[5] { "Congratulations, human...", "Correct answer... Just like butter.",
                    "Not that I care, but that´s correct.", "Good job, human! Now... Can you give me another purpose?",
        "GOOD! ... *sighs* Not wanna pass the butter." };

    public void Start()
    {
        txtCharacterName.text = NameRobot;
        FirstText(currentText[0]);
    }

    public void FirstText(string crrntTxt)
    {
        panelofDialog.SetActive(true);
        panelofQuestionAnswers.SetActive(false);
        showingDialog = true;
        txtDialog.text = crrntTxt;
        currentDialog++;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && showingDialog)
        {
            if (currentDialog < currentText.Length)
            {
                nextDialog();
            }
            else
            {

                showingDialog = false;
                robotLight.changeColor(1);
                currentQuestionIndex = UnityEngine.Random.Range(0, 9);
                //currentQuestionIndex = 2;
                _scene01Controller.createQuestion(currentQuestionIndex);
                panelofDialog.SetActive(false);
                panelofQuestionAnswers.transform.GetChild(0).GetComponent<Text>().text = _scene01Controller.getQuestionAnswer().Question;
                StartCoroutine(robotQuestion());
            }
        }
    }

    IEnumerator robotQuestion()
    {
        yield return new WaitForSeconds(1.5f);
        panelofQuestionAnswers.SetActive(true);

    }

    public void sendAnswerAndVerify()
    {
        ApiAiModule apiai = GetComponent<ApiAiModule>();
        string response = apiai.SendText();
        APIAiClassModel.RootObject responseApi = JsonConvert.DeserializeObject<APIAiClassModel.RootObject>(response);
        if (currentQuestionIndex == 0 ||
            currentQuestionIndex == 1 ||
            currentQuestionIndex == 3 ||
            currentQuestionIndex == 6)
        {

            if (responseApi.result.parameters.number.ToLower() == _scene01Controller.getQuestionAnswer().Answer.ToLower() ||
                responseApi.result.parameters.even.ToLower() == _scene01Controller.getQuestionAnswer().Answer.ToLower() ||
                 responseApi.result.parameters.odd.ToLower() == _scene01Controller.getQuestionAnswer().Answer.ToLower() ||

                 responseApi.result.resolvedQuery.ToLower() == _scene01Controller.getQuestionAnswer().Answer.ToLower())
            {
                robotLight.changeColor(0);
                FirstText(congratulations[Random.Range(0, 5)]);
            }
            else
            {
                robotLight.changeColor(2);
                FirstText("...");
            }
        }
        else if (currentQuestionIndex == 4) {
            if (responseApi.result.parameters.number.ToLower() == apiai.txtAnswer().ToLower() ||
                   responseApi.result.parameters.even.ToLower() == apiai.txtAnswer().ToLower() ||
                    responseApi.result.parameters.odd.ToLower() == apiai.txtAnswer().ToLower() ||
                    responseApi.result.parameters.given_name.ToLower() == apiai.txtAnswer().ToLower() ||
                    responseApi.result.parameters.geo_city.ToLower() == apiai.txtAnswer().ToLower() ||
                    responseApi.result.resolvedQuery.ToLower() == apiai.txtAnswer().ToLower())
            {
                robotLight.changeColor(0);
                FirstText(congratulations[Random.Range(0, 5)]);
            }
            else
            {
                robotLight.changeColor(2);
                FirstText("...");
            }
        }
        else if (currentQuestionIndex == 5)
        {
            if (ControllerScene01.getStatusPalindrome(apiai.txtAnswer()))
            {
                robotLight.changeColor(0);
                FirstText(congratulations[Random.Range(0, 5)]);
            }
            else
            {
                robotLight.changeColor(2);
                FirstText("...");
            }
        }
        else if (currentQuestionIndex == 2)
        {
            string[] auxString = apiai.txtAnswer().ToLower().Split(' ');
            foreach (string s in auxString)
            {
                if (_scene01Controller.getQuestionAnswer().Answer.ToLower().Contains(s))
                {
                    robotLight.changeColor(0);
                    FirstText("Oh jezz... ");
                }
                else
                {
                    robotLight.changeColor(2);
                    FirstText("...");
                }
            }
        }
    }

    void nextDialog()
    {
        txtDialog.text = currentText[currentDialog];
        currentDialog++;
    }
}
