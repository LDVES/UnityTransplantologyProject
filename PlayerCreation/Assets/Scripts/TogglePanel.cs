using System.Collections;
using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    public GameObject InfoPanel;
    public GameObject QuizPanel;
    public Animator InfoPanelAnimator;
    public Animator QuizPanelAnimator;
    public AnimationClip HideInfoAnimation;
    public AnimationClip HideQuizAnimation;

    #region InfoPanel
    public void ShowInfoPanel()
    {
        InfoPanel.SetActive(true);
        InfoPanelAnimator.Play("InfoPanelFadeIn");
    }

    public void HideInfoPanel()
    {
        StartCoroutine(PlayHideInfoAnimation());
    }

    IEnumerator PlayHideInfoAnimation()
    {
        InfoPanelAnimator.Play("InfoPanelFadeOut");
        yield return new WaitForSeconds(HideInfoAnimation.length);
        InfoPanel.SetActive(false);
        StopCoroutine("PlayHideInfoAnimation");
    }
    #endregion


    #region QuizPanel
    public void ShowQuizPanel()
    {
        QuizPanel.SetActive(true);
        QuizPanelAnimator.Play("QuizPanelFadeIn");
    }

    public void HideQuizPanel()
    {
        StartCoroutine(PlayHideQuizAnimation());
    }

    IEnumerator PlayHideQuizAnimation()
    {
        QuizPanelAnimator.Play("QuizPanelFadeOut");
        yield return new WaitForSeconds(HideQuizAnimation.length);
        QuizPanel.SetActive(false);
        StopCoroutine("PlayHideQuizAnimation");
    }
    #endregion
}
