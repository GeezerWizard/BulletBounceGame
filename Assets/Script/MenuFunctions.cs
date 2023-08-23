using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    public static void RestartGame()
    {
        GameEvents.current.GameStart();
    }
}