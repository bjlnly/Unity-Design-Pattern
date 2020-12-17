//-------------------------------------------------------------------------------------
//	TestHeroine.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
/// <summary>
/// 测试女主角
/// </summary>
public class TestHeroine : MonoBehaviour
{
    private Heroine _heroine;

    void Start ( )
	{
        _heroine = new Heroine();
    }

	void Update ( )
	{
	   _heroine.Update();
	}
}
