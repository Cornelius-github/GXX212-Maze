using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //public Animator animator;

    public Text first;
    public Text second;
    public Text third;
    public Text final;

    public GameObject firstGO;
    public GameObject secondGO;
    public GameObject thirdGO;
    public GameObject finalGO;

    private Queue<string> sentences;

    public int steps;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        steps++;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        if (steps == 1)
        {
            firstGO.SetActive(true);
            secondGO.SetActive(false);
            thirdGO.SetActive(false);
            finalGO.SetActive(false);

            first.text = sentence;
        }
        if (steps == 2)
        {
            firstGO.SetActive(false);
            secondGO.SetActive(true);
            thirdGO.SetActive(false);
            finalGO.SetActive(false);

            second.text = sentence;
        }
        if (steps == 3)
        {
            firstGO.SetActive(false);
            secondGO.SetActive(false);
            thirdGO.SetActive(true);
            finalGO.SetActive(false);

            third.text = sentence;
        }
        if (steps == 4)
        {
            firstGO.SetActive(false);
            secondGO.SetActive(false);
            thirdGO.SetActive(false);
            finalGO.SetActive(true);
            steps++;

            final.text = sentence;
        }
        if (steps >= 5)
        {
            firstGO.SetActive(false);
            secondGO.SetActive(false);
            thirdGO.SetActive(false);
            finalGO.SetActive(false);
        }

    }

    void EndDialogue()
    {
        Debug.Log("End");
        //animator.SetBool("IsOpen", false);
    }
}
