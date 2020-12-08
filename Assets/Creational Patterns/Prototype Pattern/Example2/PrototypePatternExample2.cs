//-------------------------------------------------------------------------------------
//	PrototypePatternExample2.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;

namespace PrototypePatternExample2
{
    public class PrototypePatternExample2 : MonoBehaviour
    {
        void Start()
        {
            // 创建克隆工厂
            CloneFactory factory = new CloneFactory();
            
            // 创建多利羊
            Sheep sally = new Sheep();

            // 克隆工厂克隆多利 获得新的羊
            Sheep clonedSheep = (Sheep)factory.GetClone(sally);

            // 两只羊的设置属性一致  HashCode不同
            Debug.Log("Sally: " + sally.ToStringEX());
            Debug.Log("Clone of Sally: " + clonedSheep.ToStringEX());
            Debug.Log("Sally Hash: " + sally.GetHashCode() + " - Cloned Sheep Hash: " + clonedSheep.GetHashCode());
        }

    }

    // 克隆工厂  用工厂的方案获取克隆(工厂只操作抽象,具体由目标子类实现)  克隆的结果是接口
    public class CloneFactory
    {
        public IAnimal GetClone(IAnimal animalSample)
        {
            return (IAnimal)animalSample.Clone();
        }
    }

    // 动物接口 继承克隆接口  但实际未进行克隆操作
    public interface IAnimal : ICloneable
    {
        object Clone();
    }

    // 羊类 具体类 具体原型要实现克隆方法
    public class Sheep : IAnimal
    {
        public Sheep()
        {
            Debug.Log("Made Sheep");
        }

        public object Clone()
        {
            Sheep sheep = null;

            try
            {
                sheep = (Sheep)base.MemberwiseClone();
            }
            catch (Exception e)
            {
                Debug.LogError("Error cloning Sheep");
            }

            return sheep;
        }

        public string ToStringEX()
        {
            return "Hello I'm a Sheep";
        }
    }

}

