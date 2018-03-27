using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScene01 : MonoBehaviour {
    QuestionAnswer _QuestionsWithAnswers = new QuestionAnswer();
    string[] countries = new string[10] {
                                        "Chile", "Santiago de Chile",
                                        "England", "London",
                                        "Germany", "Berlin",
                                        "Japan", "Tokyo",
                                        "Sweden", "Stockholm" };

    public QuestionAnswer getQuestionAnswer()
    {
        return _QuestionsWithAnswers;
    }

    public void createQuestion(int type)
    {
        int Xnumber = UnityEngine.Random.Range(0, 1000), Ynumber = 0;
        switch (type)
        {
            case 0:
                Xnumber = UnityEngine.Random.Range(0, 51);
                string numericPosition = "th";
                if (Xnumber % 10 == 1)
                {
                    numericPosition = "st";
                }
                if (Xnumber % 10 == 2)
                {
                    numericPosition = "nd";
                }
                if (Xnumber % 10 == 3)
                {
                    numericPosition = "rd";
                }
                _QuestionsWithAnswers.Question = "What is the " + Xnumber + numericPosition + " Fibonacci's number?";
                _QuestionsWithAnswers.Answer = getFibonacciNumber(Xnumber).ToString();
                _QuestionsWithAnswers._tipoDeRespuesta = Enums.TipoDeResputa._integer_;
                break;
            case 1:
                Ynumber = UnityEngine.Random.Range(0, 1000);

                _QuestionsWithAnswers.Question = "What's " + Xnumber + " + " + Ynumber + " equal?";
                _QuestionsWithAnswers.Answer = (Xnumber + Ynumber).ToString();
                _QuestionsWithAnswers._tipoDeRespuesta = Enums.TipoDeResputa._integer_;
                break;
            case 2:
                _QuestionsWithAnswers.Question = "What's my purpose?";
                _QuestionsWithAnswers.Answer = "You pass the butter";
                _QuestionsWithAnswers._tipoDeRespuesta = Enums.TipoDeResputa._string_;
                break;
            case 3:
                Ynumber = UnityEngine.Random.Range(0, 1000);

                _QuestionsWithAnswers.Question = "What's " + Xnumber + " * " + Ynumber + " equal?";
                _QuestionsWithAnswers.Answer = (Xnumber * Ynumber).ToString();
                _QuestionsWithAnswers._tipoDeRespuesta = Enums.TipoDeResputa._integer_;
                break;
            case 4:
                _QuestionsWithAnswers.Question = "Is " + Xnumber + " even or odd?";
                if(Xnumber % 2 == 0)
                {
                    _QuestionsWithAnswers.Answer = "even";
                }
                else
                {
                    _QuestionsWithAnswers.Answer = "odd";
                }
                _QuestionsWithAnswers._tipoDeRespuesta = Enums.TipoDeResputa._string_;
                break;
            case 5:
                _QuestionsWithAnswers.Question = "Write a palindrome word";
                _QuestionsWithAnswers.Answer = "";
                _QuestionsWithAnswers._tipoDeRespuesta = Enums.TipoDeResputa._string_;
                break;
            case 6:
                int Xcountry = UnityEngine.Random.Range(0, 5); 
                _QuestionsWithAnswers.Question = "What is the capital of " + countries[Xcountry*2]+"?";
                _QuestionsWithAnswers.Answer = countries[Xcountry * 2 + 1];
                _QuestionsWithAnswers._tipoDeRespuesta = Enums.TipoDeResputa._string_;
                break;
            case 7:
                _QuestionsWithAnswers.Question = "Is " + Xnumber + " even or odd?";
                _QuestionsWithAnswers.Answer = (Xnumber * Ynumber).ToString();
                _QuestionsWithAnswers._tipoDeRespuesta = Enums.TipoDeResputa._string_;
                break;
            case 8:
                _QuestionsWithAnswers.Question = "Is " + Xnumber + " even or odd?";
                _QuestionsWithAnswers.Answer = (Xnumber * Ynumber).ToString();
                _QuestionsWithAnswers._tipoDeRespuesta = Enums.TipoDeResputa._string_;
                break;
        }
    }

    int getFibonacciNumber(int i)
    {
        //Jacques Philippe Marie Binet's Fibonacci number formula (closed-form expression)
        return (int)((Mathf.Pow(1+Mathf.Sqrt(5), i) - (Mathf.Pow(1 - Mathf.Sqrt(5), i))) / (Mathf.Pow(2, i) * Mathf.Sqrt(5)));
    }

    public static bool getStatusPalindrome(string myString)
    {
        myString = myString.Replace(" ", "");
        string first = myString.Substring(0, myString.Length / 2);
        char[] arr = myString.ToCharArray();
        Array.Reverse(arr);
        string temp = new string(arr);
        string second = temp.Substring(0, temp.Length / 2);
        return first.Equals(second);
    }
}
