//-------------------------------------------------------------------------------------
//	ProxyPatternExample1.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

//This real-world code demonstrates the Proxy pattern for a Math object represented by a MathProxy object.
//这段现实世界的代码演示了由MathProxy对象代表的Math对象的Proxy模式。

namespace ProxyPatternExample1
{
    public class ProxyPatternExample1 : MonoBehaviour
    {
        void Start()
        {
            // Create math proxy 
            // 创建激励数学代理
            MathProxy proxy = new MathProxy();

            // Do the math
            // 代理可以做数学能做的所有操作
            Debug.Log("4 + 2 = " + proxy.Add(4, 2));
            Debug.Log("4 - 2 = " + proxy.Sub(4, 2));
            Debug.Log("4 * 2 = " + proxy.Mul(4, 2));
            Debug.Log("4 / 2 = " + proxy.Div(4, 2));
        }
    }

    /// <summary>
    /// The 'Subject interface 抽象主体 -- 数学
    /// </summary>
    public interface IMath
    {
        double Add(double x, double y);
        double Sub(double x, double y);
        double Mul(double x, double y);
        double Div(double x, double y);
    }

    /// <summary>
    /// The 'RealSubject' class 具体主体 具体数学计算
    /// </summary>
    class Math : IMath
    {
        public double Add(double x, double y) { return x + y; }
        public double Sub(double x, double y) { return x - y; }
        public double Mul(double x, double y) { return x * y; }
        public double Div(double x, double y) { return x / y; }
    }

    /// <summary>
    /// The 'Proxy Object' class 代理类
    /// </summary>
    class MathProxy : IMath // 看上去也是数学
    {
        // 控制了数学的
        private Math _math = new Math();

        public double Add(double x, double y)
        {
            return _math.Add(x, y);
        }
        public double Sub(double x, double y)
        {
            return _math.Sub(x, y);
        }
        public double Mul(double x, double y)
        {
            return _math.Mul(x, y);
        }
        public double Div(double x, double y)
        {
            return _math.Div(x, y);
        }
    }
}