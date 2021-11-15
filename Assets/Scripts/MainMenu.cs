using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Dictionary<string, Action> commandActions = new Dictionary<string, Action>();
    private KeywordRecognizer commandRecognizer;

    // Start is called before the first frame update
    void Start()
    {
        commandActions.Add("Open the Game", playGame);
        commandActions.Add("I am Done", quitGame);

        commandRecognizer = new KeywordRecognizer(commandActions.Keys.ToArray());
        commandRecognizer.OnPhraseRecognized += OnKeywordsRecognised;
        commandRecognizer.Start();
    }

    void playGame()
    {
        SceneManager.LoadScene(sceneBuildIndex:1);
        Debug.Log("Played");
    }

    void quitGame()
    {
        Application.Quit();
        Debug.Log("Raged");
    }

    private void OnKeywordsRecognised(PhraseRecognizedEventArgs args)
    {
        commandActions[args.text].Invoke();
    }
}
