using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEATInputTaker : AbstractInputTaker
{
    GameInstanceNEATUnit sourceOfTruth;

    protected override float GetHorizInput()
    {
        float input =  (sourceOfTruth.currentHorizInput-.5f)*2;
        return input;
    }

    protected override bool GetShootInput()
    {
        return sourceOfTruth.currentShootInput;
    }

    public void SetSourceOfTruth(GameInstanceNEATUnit controller)
    {
        sourceOfTruth = controller;
    }
}
