using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveManager : AbstractLifeManager
{
    [SerializeField] int scoreToAddEachCycle = 5;
    [SerializeField] float scoreCycleDuration = 1f;
    [SerializeField] GameObject lossUI;
    bool isAlive = true;
    GameInstanceManager gameInstance;
    // Start is called before the first frame update
    void Start()
    {
        gameInstance = GameInstanceManager.GetObjectGameInstance(transform);
        StartCoroutine(IncreaseScoreIfAlive());
    }

    IEnumerator IncreaseScoreIfAlive() 
    { 
        while(isAlive)
        {
            yield return new WaitForSeconds(scoreCycleDuration);
            gameInstance.IncreaseScore(scoreToAddEachCycle);
        }
    }

    public override void Die()
    {
        if (!isAlive) return;

        isAlive = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<InputsIntoPlayerMovements>().DisableInputs();
        gameInstance.PlayPlayerHitSystem(transform);
        gameInstance.PlayLossClip();
        StartCoroutine(Clean());
    }

    IEnumerator Clean()
    {
        yield return new WaitForSeconds(1f);
        lossUI.SetActive(true);
    }
}
