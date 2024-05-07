using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputsIntoPlayerMovements))]
public abstract class AbstractInputTaker : MonoBehaviour
{
    InputsIntoPlayerMovements m_mover;

    protected abstract float GetHorizInput();
    protected abstract bool GetShootInput();

    private void Start()
    {
        m_mover = GetComponent<InputsIntoPlayerMovements>();
    }

    void FixedUpdate()
    {
        m_mover.Move(GetHorizInput(), GetShootInput());
    }
}
