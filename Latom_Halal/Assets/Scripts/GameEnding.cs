using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 4f;
    public MonsterHealth monsterHealth;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource caughtAudio;

    bool m_IsPlayerDead;
    bool m_IsMonsterDead;
    float m_Timer;
    bool m_HasAudioPlayed;



    void Update()
    {
        if (m_IsPlayerDead)
        {
            EndLevel(exitBackgroundImageCanvasGroup,false, exitAudio);
        }
        else if(m_IsMonsterDead)
        {
            EndLevel(caughtBackgroundImageCanvasGroup,true, caughtAudio);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;
        if(doRestart)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
          Application.Quit();
        }
    }
}
