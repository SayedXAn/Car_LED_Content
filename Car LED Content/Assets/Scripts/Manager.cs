using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Manager : MonoBehaviour
{
    public Image[] cars;
    public Image jeep;
    int currState = -1;
    Keyboard keyboard = Keyboard.current;

    [Header("UI")]
    public GameObject answerTextBox;
    public GameObject questionTextBox;
    public TMP_Text correctAnswer;
    public TMP_Text question;

    [Header("Questions")]
    public string[] questions;
    [Header("Answers")]
    public string[] answers;
    [Header("Variables")]

    public float textBoxHeight = 100f;
    public float startDis = 100f;
    public float firstDis = 400f;
    public float secondDis = 400f;
    public float thirdDis = 400f;
    public float fourthDis = 400f;
    public float fifthDis = 400f;
    public float fusionDis = 400f;

    public AudioSource AS;
    
    void Start()
    {
        DOTween.Init();
        firstDis += startDis;
        secondDis += firstDis;
        thirdDis += secondDis;
        fourthDis += thirdDis;
        fifthDis += fourthDis;
    }

    // Update is called once per frame
    void Update()
    {
        if (keyboard.backspaceKey.wasPressedThisFrame && currState != 0)
        {
            currState = 0;
            ResetSeq();
        }
        if (keyboard.qKey.wasPressedThisFrame && currState != 1)
        {
            currState = 1;
            StartingSeq();
        }
        if (keyboard.wKey.wasPressedThisFrame && currState != 2)
        {
            currState = 2;
            SecondSeq();
        }
        if (keyboard.eKey.wasPressedThisFrame && currState != 3)
        {
            currState = 3;
            ThirdSeq();
        }
        if (keyboard.rKey.wasPressedThisFrame && currState != 4)
        {
            currState = 4;
            FourthSeq();
        }
        if (keyboard.tKey.wasPressedThisFrame && currState != 5)
        {
            currState = 5;
            FifthSeq();
        }
        if (keyboard.yKey.wasPressedThisFrame && currState != 6)
        {
            currState = 6;
            FusionSeq();
        }
        if (keyboard.f12Key.wasPressedThisFrame && currState != 7)
        {
            SceneManager.LoadScene("LED");
        }
    }
    public void ResetSeq()
    {        
        for (int i = 0; i < 8; i++)
        {
            cars[i].transform.DOMoveY(startDis, 1f);
        }
    }

    public void StartingSeq()
    {
        //ShowQuestion(0);
        //ShowAnswer(0);
        AS.Play();
        for (int i = 0; i < 8; i++)
        {
            cars[i].transform.DOMoveY(firstDis, 1f);
        }
    }

    public void SecondSeq()
    {
        ShowQuestion(0);
        ShowAnswer(0);
        for (int i = 0; i < 8; i++)
        {
            cars[i].transform.DOMoveY(Random.Range(secondDis, secondDis+20), 1f);
            cars[i].transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void ThirdSeq()
    {
        ShowQuestion(1);
        ShowAnswer(1);
        for (int i = 0; i < 8; i++)
        {
            cars[i].transform.DOMoveY(Random.Range(thirdDis, thirdDis+20), 1f);
            cars[i].transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public void FourthSeq()
    {
        ShowQuestion(2);
        ShowAnswer(2);
        for (int i = 0; i < 8; i++)
        {
            cars[i].transform.DOMoveY(Random.Range(fourthDis, fourthDis + 20), 1f);
            cars[i].transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public void FifthSeq()
    {
        ShowQuestion(3);
        ShowAnswer(3);
        for (int i = 0; i < 8; i++)
        {
            cars[i].transform.DOMoveY(Random.Range(fifthDis, fifthDis  + 20), 1f);
            cars[i].transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void FusionSeq()
    {
        for (int i = 0; i < 8; i++)
        {
            cars[i].transform.GetChild(0).gameObject.SetActive(false);
        }
        //ShowAnswer();
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(cars[0].transform.DOMove(new Vector3(1600f, 320f, 0), 0.5f));
        mySequence.Join(cars[0].DOFade(0.5f, 0.25f));
        mySequence.Append(cars[1].transform.DOMove(new Vector3(1600f, 320f, 0), 0.5f));
        mySequence.Join(cars[1].DOFade(0.5f, 0.25f));
        mySequence.Append(cars[2].transform.DOMove(new Vector3(1600f, 320f, 0), 0.5f));
        mySequence.Join(cars[2].DOFade(0.5f, 0.25f));
        mySequence.Append(cars[3].transform.DOMove(new Vector3(1600f, 320f, 0), 0.5f));
        mySequence.Join(cars[3].DOFade(0.5f, 0.25f));
        mySequence.Append(cars[4].transform.DOMove(new Vector3(1600f, 320f, 0), 0.5f));
        mySequence.Join(cars[4].DOFade(0.5f, 0.25f));
        mySequence.Append(cars[5].transform.DOMove(new Vector3(1600f, 320f, 0), 0.5f));
        mySequence.Join(cars[5].DOFade(0.5f, 0.25f));
        mySequence.Append(cars[6].transform.DOMove(new Vector3(1600f, 320f, 0), 0.5f));
        mySequence.Join(cars[6].DOFade(0.5f, 0.25f));
        mySequence.Append(cars[7].transform.DOMove(new Vector3(1600f, 320f, 0), 0.5f));
        mySequence.Join(cars[7].DOFade(0.5f, 0.25f));
        mySequence.Append(jeep.DOFade(1f, 0.5f));
        mySequence.Join(jeep.transform.DOScale(1f, 0.5f));
    }

    public void ShowAnswer(int ind)
    {
        answerTextBox.SetActive(true);
        correctAnswer.text = answers[ind];
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(answerTextBox.transform.DOMoveY(textBoxHeight, 0.5f));
        mySequence.Append(answerTextBox.transform.DOMoveY(-1000f, 0.5f).SetDelay(2f));

    }
    public void ShowQuestion(int ind)
    {
        questionTextBox.SetActive(true);
        question.text = questions[ind];
        //Sequence mySequence = DOTween.Sequence();
        //mySequence.Append(questionTextBox.transform.DOMoveY(textBoxHeight, 0.5f));
        //mySequence.Append(questionTextBox.transform.DOMoveY(-1000f, 0.5f).SetDelay(2f));

    }
}
