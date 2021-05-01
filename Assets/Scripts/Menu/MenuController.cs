using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            print(Time.timeScale);
            DisplayMenu();
        }
    }

    public void DisplayMenu()
    {
        Time.timeScale = Mathf.Abs(Time.timeScale - 1);
        menu.SetActive(!menu.activeSelf);
    }
}
