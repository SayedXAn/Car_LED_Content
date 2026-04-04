using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class Manager : MonoBehaviour
{
    public Image[] cars;
    int currState = 0;
    Keyboard keyboard = Keyboard.current;
    void Start()
    {
        DOTween.Init();
    }

    // Update is called once per frame
    void Update()
    {
        if(keyboard.wKey.wasPressedThisFrame && currState != 1)
        {
            currState = 1;
            cars[0].gameObject.transform.DOMoveX(500f, 1f);
        }
    }
}
