//-------------------------------------------------------------------------------------
//	HeroineBaseState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
/// <summary>
/// 状态接口  每个状态都聚合一个女主角  其实完全可以用抽象类了
/// </summary>
public interface HeroineBaseState
{
    void Update();
    void HandleInput();

}
