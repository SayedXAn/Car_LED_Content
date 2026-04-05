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

    public GameObject textBox;
    public TMP_Text correctAnswer;
    public float textBoxHeight = 100f;
    public float startDis = 100f;
    public float firstDis = 400f;
    public float secondDis = 400f;
    public float thirdDis = 400f;
    public float fourthDis = 400f;
    void Start()
    {
        DOTween.Init();
        firstDis += startDis;
        secondDis += firstDis;
        thirdDis += secondDis;
        fourthDis += thirdDis;
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
            FusionSeq();
        }
        if (keyboard.f12Key.wasPressedThisFrame && currState != 4)
        {
            SceneManager.LoadScene("LED");
        }
    }
    public void ResetSeq()
    {        
        for (int i = 0; i < 4; i++)
        {
            cars[i].transform.DOMoveX(startDis, 1f);
        }
        for (int i = 4; i < 8; i++)
        {
            cars[i].transform.DOMoveX(3200 - startDis, 1f);
        }
    }

    public void StartingSeq()
    {
        ShowAnswer();
        for (int i = 0; i < 4; i++)
        {
            cars[i].transform.DOMoveX(firstDis, 1f);
        }
        for (int i = 4; i < 8; i++)
        {
            cars[i].transform.DOMoveX(3200- firstDis, 1f);
        }
    }

    public void SecondSeq()
    {
        ShowAnswer();
        for (int i = 0; i < 4; i++)
        {
            cars[i].transform.DOMoveX(Random.Range(secondDis-100, secondDis+100), 1f);
        }
        for (int i = 4; i < 8; i++)
        {
            cars[i].transform.DOMoveX(3200 - Random.Range(secondDis - 100, secondDis + 100), 1f);
        }
    }

    public void ThirdSeq()
    {
        ShowAnswer();
        for (int i = 0; i < 4; i++)
        {
            cars[i].transform.DOMoveX(Random.Range(thirdDis - 100, thirdDis + 100), 1f);
        }
        for (int i = 4; i < 8; i++)
        {
            cars[i].transform.DOMoveX(3200 - Random.Range(thirdDis - 100, thirdDis + 100), 1f);
        }
    }

    public void FusionSeq()
    {
        ShowAnswer();
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

    public void ShowAnswer()
    {
        textBox.SetActive(true);
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(textBox.transform.DOMoveY(textBoxHeight, 0.5f));
        mySequence.Append(textBox.transform.DOMoveY(-1000f, 0.5f).SetDelay(2f));

    }
}
