//-------------------------------------------------------------------------------------
//	TVRemove.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

/// <summary>
/// 创造TV的创造者
/// </summary>
public class TVRemove
{
    // 创建一个新的电视墙
    public static IElectronicDevice GetDevice()
    {
        return new Television();
    }
}
