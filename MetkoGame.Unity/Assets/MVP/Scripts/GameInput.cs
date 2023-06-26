using System;
using System.Collections;
using System.Collections.Generic;
using TVP;
using UnityEngine;

public class GameInput : MonoSinglethon<GameInput>
{

    [SerializeField, Range(-1, 1)] private float _vertical1;
    [SerializeField, Range(-1, 1)] private float _horizontal1;
    [SerializeField, Range(-1, 1)] private float _vertical2;
    [SerializeField, Range(-1, 1)] private float _horizontal2;

    public float Vertical1 { get => _vertical1; set => _vertical1 = value; }
    public float Horizontal1 { get => _horizontal1; set => _horizontal1 = value; }
    public float Vertical2 { get => _vertical2; set => _vertical2 = value; }
    public float Horizontal2 { get => _horizontal2; set => _horizontal2 = value; }

    private void Update()
    {
        BindOldInputSystem();
    }

    private void BindOldInputSystem()
    {
        BindInput(ref _vertical1, Input.GetAxis("Vertical"));
        BindInput(ref _horizontal1, Input.GetAxis("Horizontal"));
    }

    private void BindInput(ref float A, float B)
    {
        A += B;
        if (B == 0)
            A = 0;
    }
    private void BindInput(ref float A, bool B)
    {
        A = B ? 1 : 0;
    }
}
