using DG.Tweening;
using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Hud : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timer = null;
    
    private float time = 0.0f;
    public bool isTimerRunning = true;
    public GameObject player;
    public GameObject timerStopCube;

    private static Hud instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RectTransform rectTransform = transform as RectTransform;
        rectTransform.anchoredPosition = new Vector2(0.0f, 300.0f);
        rectTransform.DOAnchorPos(Vector2.zero, 0.5f).SetEase(Ease.InOutQuad);
    }

    public void OnButtonClick()
    {
      
        GameController.Instance.PlayerDied(player);
    }

    // add function to stop timer
    // need a bool that is isRunning
    public void StopTimer()
    {
        isTimerRunning = false;
        Debug.Log("Timer stopped");

    }


    // Update is called once per frame
    void Update()
    {
        


            float flooredTime = Mathf.Floor(time);
            if (isTimerRunning)
            {
                time += Time.deltaTime;
                TimeSpan span = TimeSpan.FromSeconds(time);
                timer.text = span.ToString(@"mm\:ss\:ff");
            }

    }
}
