using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class VIdQues : MonoBehaviour
{
    public VideoClip[] videoClips;
    public GameObject[] questions;
    public VideoPlayer vp;
    public RenderTexture rt;
    Keyboard keyboard = Keyboard.current;
    int currState = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (keyboard.digit1Key.wasPressedThisFrame && (currState == 0 || currState == 1))
        {
            if(currState == 1)
            {
                currState = 0;
                vp.Play();
                questions[0].SetActive(false);                
            }
            else
            {
                currState = 1;
                vp.Pause();
                questions[0].SetActive(true);
            }
        }
        if (keyboard.digit2Key.wasPressedThisFrame && (currState == 0 || currState == 2))
        {
            if (currState == 2)
            {
                currState = 0;
                vp.Play();
                questions[1].SetActive(false);
            }
            else
            {
                currState = 2;
                vp.Pause();
                questions[1].SetActive(true);
            }
        }
        if (keyboard.digit3Key.wasPressedThisFrame && (currState == 0 || currState == 3))
        {
            if (currState == 3)
            {
                currState = 0;
                vp.Play();
                questions[2].SetActive(false);
            }
            else
            {
                currState = 3;
                vp.Pause();
                questions[2].SetActive(true);
            }
        }

        if (keyboard.zKey.wasPressedThisFrame)
        {
            //vp.Stop();
            //rt.Release();
            vp.clip = videoClips[0];
            questions[0].SetActive(false);
            questions[1].SetActive(false);
            questions[2].SetActive(false);
            currState = 0;
            vp.isLooping = true;
            vp.Play();
        }
        if (keyboard.xKey.wasPressedThisFrame)
        {
            //vp.Stop();
            //rt.Release();
            questions[0].SetActive(false);
            currState = 0;
            vp.clip = videoClips[1];
            vp.isLooping = false;
            vp.Play();
        }
        if(keyboard.cKey.wasPressedThisFrame)
        {
            //vp.Stop();
            //rt.Release();
            questions[1].SetActive(false);
            currState = 0;
            vp.clip = videoClips[2];
            vp.isLooping = false;
            vp.Play();
        }
        if (keyboard.vKey.wasPressedThisFrame)
        {
            //vp.Stop();
            //rt.Release();
            questions[2].SetActive(false);
            currState = 0;
            vp.clip = videoClips[3];
            vp.isLooping = false;
            vp.Play();
        }

    }
}
