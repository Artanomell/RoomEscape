using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public Animator transitionAnimator;
    private bool isTransition;

    public void OpenScene(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    public void OpenSceneWithTransition(string name)
    {
        if (!isTransition)
            StartCoroutine(StartTransition(name));
    }

    IEnumerator StartTransition(string name)
    {
        isTransition = true;
        transitionAnimator.SetTrigger("end");

        AnimatorClipInfo[] m_CurrentClipInfo;
        float m_CurrentClipLength;

        //Fetch the current Animation clip information for the base layer
        m_CurrentClipInfo = this.transitionAnimator.GetCurrentAnimatorClipInfo(0);
        //Access the current length of the clip
        m_CurrentClipLength = m_CurrentClipInfo[0].clip.length;

        yield return new WaitForSeconds(m_CurrentClipLength);

        SceneManager.LoadScene(name, LoadSceneMode.Single);
        isTransition = false;
    }
}
