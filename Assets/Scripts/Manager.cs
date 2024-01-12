using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private Text checkPointText; 
    [SerializeField] private Text userPositionText;
    [SerializeField] private string checkPoint;
    [SerializeField] private Vector3 userPosition;
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    public void SaveData()
    {
        PlayerPrefs.SetString("checkPoint", checkPoint);
        PlayerPrefs.SetFloat("positionX", userPosition.x);
        PlayerPrefs.SetFloat("positionY", userPosition.y);
        PlayerPrefs.SetFloat("positionZ", userPosition.z);

        LoadData();
    }

    void LoadData()
    {
        checkPointText.text = "checkPoint: " + PlayerPrefs.GetString("CheckPoint", "No point found");
        userPositionText.text = "Player position: " + PlayerPrefs.GetFloat("positionX", 0).ToString() + "x" + PlayerPrefs.GetFloat("positionY", 0).ToString() + "y" + PlayerPrefs.GetFloat("positionZ", 0).ToString() + "z";
    }

}

