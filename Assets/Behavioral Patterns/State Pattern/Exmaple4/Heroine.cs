//-------------------------------------------------------------------------------------
//	Heroine.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
/// <summary>
/// 女主角
/// </summary>
public class Heroine
{
    // 持有抽象状态
    HeroineBaseState _state;

    public Heroine()
    {
        _state = new StandingState(this);

    }

    public void SetHeroineState(HeroineBaseState newState)
    {
        _state = newState;
    }

    public void HandleInput()
    {

    }



    public void Update()
    {
        _state.HandleInput();
    }

}
