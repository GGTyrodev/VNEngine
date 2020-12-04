using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Responsible for adding and maintaining characters in the scene
/// </summary>

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;

    /// <summary>
    /// All characters must be attached to the character panel
    /// </summary>
    public RectTransform characterPanel;

    /// <summary>
    /// A list of all characters currently in our scene
    /// </summary>
    public List<Character> characters = new List<Character>();

    /// <summary>
    /// Easy lookup for our characters
    /// </summary>
    public Dictionary<string, int> characterDictionary = new Dictionary<string, int>();

    void Awake() 
    {
        instance = this;
    }

    /// <summary>
    /// Try to get a character by the name provided from the character list
    /// </summary>
    /// <param name="characterName">Character name</param>
    public Character GetCharacter(string characterName, bool createIfNotExist = true, bool enableCharacter = true) 
    {
        int index = -1;
        if (characterDictionary.TryGetValue(characterName, out index)) 
        {
            return characters[index];
        } else {
            return CreateCharacter(characterName, enableCharacter);
        }
    }

    public Character CreateCharacter(string characterName, bool enableCharacter = true) {
        Character newCharacter = new Character(characterName, enableCharacter);
        characterDictionary.Add(characterName, characters.Count);
        characters.Add(newCharacter);

        return newCharacter;
    }
}
