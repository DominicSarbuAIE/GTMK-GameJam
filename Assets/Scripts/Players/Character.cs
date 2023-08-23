using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Character : MonoBehaviour
{

    public GameObject[] _characters;
    public int _selectedCharacter = 0;
    // Start is called before the first frame update

    private void Start()
    {
        for(int i = 0; i < _characters.Length; i++)
        {
            _characters[i].SetActive(false);
        }

        if (_characters[0])
        {
            _characters[0].SetActive(true);
        }
    }

    public void NextCharacter()
    {
        _characters[_selectedCharacter].SetActive(false);
        _selectedCharacter = (_selectedCharacter + 1) % _characters.Length;
        _characters[_selectedCharacter].SetActive(true);

    }
    
    public void PreviousCharacter()
    {
        _characters[_selectedCharacter].SetActive(false);
        _selectedCharacter = (_selectedCharacter - 1 + _characters.Length) % _characters.Length;
        _characters[_selectedCharacter].SetActive(true);
    }

    public void StartGame()
    { 
        PlayerPrefs.SetInt("selectedCharacter", _selectedCharacter);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
