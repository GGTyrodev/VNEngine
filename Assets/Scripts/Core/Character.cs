using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Character
{
    public string charaName;
    /// <summary>
    /// The root container is for all images related to the character in the scene
    /// </summary>
    [HideInInspector]public RectTransform root;

    public bool enabled {get {return root.gameObject.activeInHierarchy;} set {root.gameObject.SetActive(value);}}
    DialogueSystem dialogueSystem;
    public void Say(string speech, bool add = false)
    {   
        if (!enabled) {
            enabled = true;
        }
        if (!add)
            dialogueSystem.SayAdditive(speech, charaName);
        else
            dialogueSystem.Say(speech, charaName);
    }
    
    /// <summary>
    /// Create a new character
    /// </summary>
    /// <param name="_name">Name</param>
    public Character (string _name, bool enableOnStart = true)
    {
        CharacterManager cm = CharacterManager.instance;
        /// locate character prefab
        GameObject prefab = Resources.Load("Prefabs/Characters/Character["+ _name +"]") as GameObject;
        /// spawn it and assign directly on chara panel
        GameObject ob = GameObject.Instantiate(prefab, cm.characterPanel);

        root = ob.GetComponent<RectTransform>();
        charaName = _name;

        renderers.bodyRenderer = ob.transform.Find("bodyLayer").GetComponent<Image>();
        renderers.expressionRenderer = ob.transform.Find("expressionLayer").GetComponent<Image>();

        enabled = enableOnStart;

        dialogueSystem = DialogueSystem.instance;
    }

    [System.Serializable]
    public class Renderers
    {
        /// <summary>
        /// renderers for multi layer
        /// </summary>
        public Image bodyRenderer;
        public Image expressionRenderer;
    }

    public Renderers renderers = new Renderers();
}
