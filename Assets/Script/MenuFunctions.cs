using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    private void Start() {
        GameEvents.current.GameStart();
    }
    public static void RestartGame()
    {
        GameEvents.current.GameStart();
    }
}