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
        commandActions.Add("Start Game", startG);
        commandActions.Add("Quit Game", quitG);

        commandRecognizer = new KeywordRecognizer(commandActions.Keys.ToArray());
        commandRecognizer.OnPhraseRecognized += OnKeywordsRecognised;
        commandRecognizer.Start();
    }

    private void startG()
    {
        SceneManager.LoadScene(sceneBuildIndex:1);
    }

    private void quitG()
    {
        Application.Quit();
    }
    private void OnKeywordsRecognised(PhraseRecognizedEventArgs args)
    {
        commandActions[args.text].Invoke();
    }
}
