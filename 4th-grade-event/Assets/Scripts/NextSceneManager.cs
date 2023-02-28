using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextSceneManager : MonoBehaviour
{
    public GameObject nextSceneButton;

    void Start()
    {
        nextSceneButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Draggable[] dragedobjt = FindObjectsOfType<Draggable>();
        if (dragedobjt.Length == Draggable._numberOfAnswers)
            nextSceneButton.SetActive(true);

    }
    public void NextSceneLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuýtGame()
    {
        Application.Quit();
    }
}
