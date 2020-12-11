//-------------------------------------------------------------------------------------
//	ProxyStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

namespace ProxyStructure
{

    public class ProxyStructure : MonoBehaviour
    {
        // 对用户而言  只知道代理而不知道主体...
        // 这样就隐藏了主体  主体被代理所控制
        // 摄政王....
	    void Start ( )
        {
            // Create proxy and request a service
            // 创建一个代理, 并请求服务
            Proxy proxy = new Proxy();
            proxy.Request();
        }
    }

    /// <summary>
    /// The 'Subject' abstract class 被代理的抽象主体
    /// </summary>
    abstract class Subject
    {
        public abstract void Request();
    }

    /// <summary>
    /// The 'RealSubject' class 被代理的真实主体
    /// </summary>
    class RealSubject : Subject
    {
        public override void Request()
        {
            Debug.Log("Called RealSubject.Request()");
        }
    }

    /// <summary>
    /// The 'Proxy' class 代理类
    /// </summary>
    class Proxy : Subject // 继承抽象主体
    {
        // 里面有真实主体
        private RealSubject _realSubject;

        // 实现抽象接口 -- 通过真实主体
        public override void Request()
        {
            // Use 'lazy initialization'
            if (_realSubject == null)
            {
                _realSubject = new RealSubject();
            }

            _realSubject.Request();
        }
    }
}