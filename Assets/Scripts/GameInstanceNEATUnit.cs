using SharpNeat.Phenomes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySharpNEAT;

[RequireComponent(typeof(InfoGatherer))]
[RequireComponent(typeof(GameInstanceManager))]
public class GameInstanceNEATUnit : UnitController
{
    public bool currentShootInput;
    public float currentHorizInput;
    float lastScore = 0;

    [SerializeField]
    NEATInputTaker inputTaker;

    InfoGatherer infoMan;

    private void Start()
    {
        inputTaker.SetSourceOfTruth(this);
        infoMan = GetComponent<InfoGatherer>();
    }
    public override float GetFitness()
    {
        return infoMan.GetScore();

        float score = infoMan.GetScore();
        bool alive = infoMan.GetPlayerAlive();
        if (!alive) return 0;

        float result = score - lastScore ;
        lastScore = score;
        return result;
    }

    protected override void HandleIsActiveChanged(bool newIsActive)
    {
        lastScore = 0;
        if (newIsActive == false)
            GetComponent<GameInstanceManager>().StopGame();
        else
            GetComponent<GameInstanceManager>().StartGame();
    }

    protected override void UpdateBlackBoxInputs(ISignalArray inputSignalArray)
    {
        float[] data = infoMan.GetInstanceInfo();
        for(int  i = 0; i <inputSignalArray.Length; i++)
        {
            inputSignalArray[i] = data[i];
        }
    }

    protected override void UseBlackBoxOutpts(ISignalArray outputSignalArray)
    {
        currentHorizInput = (float)outputSignalArray[0] ;
        currentShootInput = outputSignalArray[1] > .5;
    }
}
