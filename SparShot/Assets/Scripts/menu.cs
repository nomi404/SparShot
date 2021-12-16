using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public Animator transition;
    public void playVsMode()
    {
        
        SceneManager.LoadScene("vs mode");
    }


    public void playAiMode()
    {
        SceneManager.LoadScene("ai mode");
    }

    public void loadNextLevelVs()
    {
        StartCoroutine(load(SceneManager.GetActiveScene().buildIndex + 1));
    }
      public void loadNextLevelAi()
    {
        StartCoroutine(load(SceneManager.GetActiveScene().buildIndex + 2));
    }

    public void loadNextLevelHole()
    {
        StartCoroutine(load(SceneManager.GetActiveScene().buildIndex + 3));
    }


    public void loadNextLevelSpeed()
    {
        StartCoroutine(load(SceneManager.GetActiveScene().buildIndex + 4));
    }
    IEnumerator load(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelIndex);
    }


}
