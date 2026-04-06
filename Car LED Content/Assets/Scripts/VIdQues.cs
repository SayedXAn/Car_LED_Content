using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class VIdQues : MonoBehaviour
{
    public VideoClip[] videoClips;
    public GameObject[] questions;
    public VideoPlayer vp;
    public RenderTexture rt;
    //Keyboard keyboard = Keyboard.current;
    int currState = 0;

    public AudioSource rev;
    public AudioSource race;
    void Start()
    {
        StartCoroutine(CheckRev());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && (currState == 0 || currState == 1))
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
        if (Input.GetKeyDown(KeyCode.Alpha2) && (currState == 0 || currState == 2))
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
        if (Input.GetKeyDown(KeyCode.Alpha3) && (currState == 0 || currState == 3))
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

        if (Input.GetKeyDown(KeyCode.Z))
        {
            //vp.Stop();
            //rt.Release();
            vp.clip = videoClips[0];
            questions[0].SetActive(false);
            questions[1].SetActive(false);
            questions[2].SetActive(false);
            currState = 0;
            //vp.isLooping = false;
            vp.Play();
            rev.DOFade(0, 0.5f);
            rev.Play();
            StartCoroutine(CheckRev());
            
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            //vp.Stop();
            //rt.Release();
            questions[0].SetActive(false);
            currState = 0;
            vp.clip = videoClips[1];
            race.DOFade(1, 0.5f);
            race.loop = true;
            race.Play();
            StartCoroutine(CheckRace());
            //vp.isLooping = false;
            vp.Play();
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            //vp.Stop();
            //rt.Release();
            questions[1].SetActive(false);
            currState = 0;
            vp.clip = videoClips[2];
            vp.Play();
            race.DOFade(1, 0.5f);
            race.loop = true;
            race.Play();
            StartCoroutine(CheckRace());
            //vp.isLooping = false;
            
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            //vp.Stop();
            //rt.Release();
            questions[2].SetActive(false);
            currState = 0;
            vp.clip = videoClips[3];
            vp.Play();
            race.Play();
            //StartCoroutine(CheckRace());
            StartCoroutine(EndRace());
            //vp.isLooping = false;

        }        
    }
    IEnumerator CheckRev()
    {
        yield return new WaitForSeconds(0.25f);
        if (!vp.isPlaying)
        {
            rev.Stop();
        }
        else
        {
            StartCoroutine(CheckRev());
        }
    }

    IEnumerator CheckRace()
    {
        yield return new WaitForSeconds(0.5f);
        if (!vp.isPlaying)
        {
            race.Stop();
        }
        else
        {
            StartCoroutine(CheckRace());
        }
    }

    IEnumerator EndRace()
    {
        yield return new WaitForSeconds(2f);
        race.DOFade(0, 1f);
        race.loop = false;
        //race.Stop();
    }
}
