using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] _characters;
    public Transform _spawn;

    void Start()
    {
        int _selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject _prefab = _characters[_selectedCharacter];
        GameObject _clone = Instantiate(_prefab, _spawn.position, Quaternion.identity);
    }

}
