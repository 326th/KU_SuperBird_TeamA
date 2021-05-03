using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoader : MonoBehaviour
{
    // assume that the order of an object is similar to BirdSelectionScene
    public GameObject[] characters;
    public int index = 0;

    void Awake()
    {
        index = PlayerPrefs.GetInt("CharacterIndex");
        
        var bird = Instantiate(characters[index]);
        bird.transform.parent = gameObject.transform;
        bird.transform.position = gameObject.transform.position;
    }
}
