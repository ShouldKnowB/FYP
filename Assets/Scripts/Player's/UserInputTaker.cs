using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputTaker : AbstractInputTaker
{
    protected override float GetHorizInput()
    {
        return Input.GetAxis("Horizontal");
    }

    protected override bool GetShootInput()
    {
        return Input.GetButtonUp("Shoot");
    }
}
