using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClickJumpToScene : MonoBehaviour
{
    public string SceneName;

    Button localButton;

    private void JumpToScene()
    {
        SceneManager.LoadScene(SceneName);
    }

    private void Awake()
    {
        localButton = GetComponent<Button>();
        localButton.onClick.AddListener(JumpToScene);
    }

    void Start() { }

    void Update() { }
}
