using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{

    public int character;

    public void SelectCharacter(int id)
    {
        character = id;
        PlayerPrefs.SetInt("SelectedCharacter", character);
        SceneManager.LoadScene("Juego");
    }

}
