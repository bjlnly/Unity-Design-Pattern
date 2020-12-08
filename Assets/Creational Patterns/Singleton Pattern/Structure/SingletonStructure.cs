//-------------------------------------------------------------------------------------
//	SingletonStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SingletonStructure : MonoBehaviour
{

    void Start()
    {
        // Constructor is protected -- cannot use new
        // 单例不能使用new 构造需要私有
        Singleton s1 = Singleton.Instance();
        Singleton s2 = Singleton.Instance();

        // Test for same instance
        if (s1 == s2)
        {
            Debug.Log("Objects are the same instance");
        }
    }
}

/// <summary>
/// The 'Singleton' class
/// </summary>
class Singleton
{
    private static Singleton _instance;

    // Constructor is 'protected'
    protected Singleton()
    {
    }

    public static Singleton Instance()
    {
        // Uses lazy initialization.
        // Note: this is not thread safe.
        // 懒汉模式  线程不安全,但是unity是单线程的,未使用多线程代码操作的话,足够了
        if (_instance == null)
        {
            _instance = new Singleton();
        }

        return _instance;
    }
}