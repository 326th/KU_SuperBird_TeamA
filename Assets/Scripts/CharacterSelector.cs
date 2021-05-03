using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] characters;
    private int currentIndex = 0;
    private GameObject displayedCharacter;
    
    void Awake()
    {
        DisplayCharacter(currentIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShowNextCharacater();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ShowPreviousCharacater();
        }
    }

    public void ShowNextCharacater()
    {
        currentIndex++;
        if (currentIndex >= characters.Length)
        {
            currentIndex = 0;
        }
        
        DisplayCharacter(currentIndex);
    }

    public void ShowPreviousCharacater()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = characters.Length - 1;
        }
        
        DisplayCharacter(currentIndex);
    }

    public void SelectCharacter()
    {
        PlayerPrefs.SetInt("CharacterIndex", currentIndex);
    }

    private void DisplayCharacter(int charIndex)
    {
        if (displayedCharacter != null)
        {
            Destroy(displayedCharacter);
        }

        displayedCharacter = Instantiate(characters[charIndex]).gameObject;
        displayedCharacter.transform.parent = gameObject.transform;
        displayedCharacter.transform.position = gameObject.transform.position;
    }
    
}
