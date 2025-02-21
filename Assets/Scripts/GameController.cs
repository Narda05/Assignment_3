using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class GameController : MonoBehaviour
{
    private static GameController instance = null;
    public static GameController Instance { get { return instance; } }

    // [SerializedField] is used to make a variable visible in the inspector
    // private Hud hud = null;
    [SerializeField]
    public Hud hud = null;

    public Transform startPoint = null;
    public Transform checkPointsContainer = null;
    private int lastCheckPointIndex = -1;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            instance.Initialize();
        }
    }
    private void OnDestroy()
    {
        SaveManager.Instance.Save();
    }
    public void Initialize()
    {
        SaveManager.Instance.Load();
        GameState gameState = SaveManager.Instance.GetGameState();
        lastCheckPointIndex = gameState.LastCheckpoint;
    }

    public void SetPlayerStartPosition(GameObject player)
    {
        if (lastCheckPointIndex >= 0)
        {
            Transform checkPoint = checkPointsContainer.GetChild(lastCheckPointIndex);
            SetPlayerPosition(player, checkPoint.position);
        }
        else if (startPoint != null)
        {
            SetPlayerPosition(player, startPoint.position);
            Debug.Log("Setting player position to start point");
        }

    }

    // public void EndGame() { hud.StopTimer(); do an UI display that says "YOU WIN"}
    public void EndGame()
    {
        hud.StopTimer();
        Debug.Log("YOU WIN");
    }

    //Player Died
    public void PlayerDied(GameObject player)
    {
        Assert.IsNotNull(startPoint, "startPoint was not set in the game controller");
        if (lastCheckPointIndex >= 0)
        {
            Transform checkPoint = checkPointsContainer.GetChild(lastCheckPointIndex);
            SetPlayerPosition(player, checkPoint.position);
        }
        else if (startPoint != null)
        {
            SetPlayerPosition(player, startPoint.position);
        }
        else
        {
            SetPlayerPosition(player, Vector3.zero);
        }
    }

    public void PlayerHitCheckPoint(Transform checkpoint)
    {
        for (int i = 0; i < checkPointsContainer.childCount; ++i)
        {
            if (checkpoint == checkPointsContainer.GetChild(i))
            {
                if (lastCheckPointIndex < i)
                {
                    lastCheckPointIndex = i;
                    SaveManager.Instance.SetLastCheckpointReached(i);
                }
                break;
            }
        }
    }

    private void SetPlayerPosition(GameObject player, Vector3 position)
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.position = position;
        }
        else 
        {
            player.transform.position = position;
        }
    }
}
