using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInstanceManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] ParticleSystem enemyHitParticles, playerHitParticles;
    [SerializeField] AudioSource sfxSOurce;
    [SerializeField] AudioClip playerShootClip, enemyKillClip, lossClip;
    [SerializeField] GameObject player, playerInitPosition;
    [SerializeField] EnemySpawnCoordiator enemySpawnCoordiator; 
    [SerializeField] public bool neatAiMode = false;
    int m_score  = 0;
   int score
    {
        get { return m_score; }
        set
        {
            m_score = value;
            scoreText.text = string.Format("Score: {0}", value);
        }
    }

    public void IncreaseScore( int amount)
    {
        score += amount; 
    }

    public int  GetCurrScore()
    {
        return score;
    }
    
    public static GameInstanceManager GetObjectGameInstance(Transform obj)
    {
        while(obj.GetComponent<GameInstanceManager>() == null)
        {
            obj = obj.parent;
        }
        return obj.GetComponent<GameInstanceManager>();
    }

    public void PlayEnemyHitSystem( Transform location)
    {
        StartCoroutine(PlaySystem(enemyHitParticles, location));
    }

    public void PlayPlayerHitSystem(Transform location)
    {
        StartCoroutine(PlaySystem(playerHitParticles, location));
    }

    IEnumerator PlaySystem(ParticleSystem particle, Transform location) 
    {
        particle.transform.position = location.position;
        particle.gameObject.SetActive(true);
        particle.Play();
        yield return new WaitForSeconds(particle.main.duration);
        particle.gameObject.SetActive(false);
    }

    void PlayClip(AudioClip clip)
    {
        if (!neatAiMode)
            sfxSOurce.PlayOneShot(clip, 1f);
    }

    public void PlayPlayerShootSound() { PlayClip(playerShootClip); }
    public void PlayKillEnemyClip() { PlayClip(enemyKillClip); }
    public void PlayLossClip() {PlayClip(lossClip); }

    public void StopGame()
    {
        enemySpawnCoordiator.StopSpawning();
    }

    public void StartGame()
    {
        score = 0;
        player.transform.position = playerInitPosition.transform.position;
        player.SetActive(true);
        player.GetComponent<AliveManager>().Revive();
        enemySpawnCoordiator.StartSpawning();
    }
}
