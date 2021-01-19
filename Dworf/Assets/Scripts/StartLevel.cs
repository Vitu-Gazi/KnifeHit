using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartLevel : MonoBehaviour
{
    //Скрипт для загрузки уровня. При загрузке уровня после проигрыша начинаются какие-то странные баги - ранее с таким не сталкивался
    //Решение пока что не попадалось
    public int Scene;
    [SerializeField]
    Text appleText;

    public int AppleNumber;
    private void Start()
    {
        AppleNumber = PlayerPrefs.GetInt("Apple");
        appleText.text = System.Convert.ToString(PlayerPrefs.GetInt("Apple"));
    }
    private void OnMouseDown()
    {
        SceneManager.LoadScene(Scene);
    }
}
