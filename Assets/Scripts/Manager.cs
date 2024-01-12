using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] private Text numberPointText; 
    [SerializeField] private Text userPositionText;
    [SerializeField] public int numberPoint;
    [SerializeField] private Vector3 userPosition;

    Transform playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.Find("Player").GetComponent<Transform>();
        LoadData();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("numberPoint", numberPoint);
        PlayerPrefs.SetFloat("positionX", playerPosition.position.x);
        PlayerPrefs.SetFloat("positionY", playerPosition.position.y);
        PlayerPrefs.SetFloat("positionZ", playerPosition.position.z);

        LoadData();
    }

    void LoadData()
    {
        numberPointText.text = "CheckPoint: " + PlayerPrefs.GetInt("numberPoint");
        userPositionText.text = "Player position: " + PlayerPrefs.GetFloat("positionX", 0).ToString() + "x" + PlayerPrefs.GetFloat("positionY", 0).ToString() + "y" + PlayerPrefs.GetFloat("positionZ", 0).ToString() + "z";
    }

}

