using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject disclaimerPanel;

    private Dictionary<string, Action> commandActions = new Dictionary<string, Action>();
    private KeywordRecognizer commandRecognizer;

    // Start is called before the first frame update
    void Start()
    {
        commandActions.Add("Start Game", startG);
        commandActions.Add("Quit Game", quitG);
        commandActions.Add("Done", disclaim);

        commandRecognizer = new KeywordRecognizer(commandActions.Keys.ToArray());
        commandRecognizer.OnPhraseRecognized += OnKeywordsRecognised;
        commandRecognizer.Start();
    }

    public void startG()
    {
        SceneManager.LoadScene(sceneBuildIndex:1);
    }

    public void quitG()
    {
        Application.Quit();
    }

    private void disclaim()
    {
        disclaimerPanel.SetActive(false);
    }


    private void OnKeywordsRecognised(PhraseRecognizedEventArgs args)
    {
        commandActions[args.text].Invoke();
    }
}
