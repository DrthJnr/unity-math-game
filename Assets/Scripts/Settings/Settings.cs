using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{    
    [SerializeField] GameObject Button1;
    [SerializeField] GameObject Button2;
    [SerializeField] GameObject Button3;
    public Button shoot;
    public Button upArrow;
    // Start is called before the first frame update
    void Start()
    {     

        Application.targetFrameRate = 60;        
    }
}
