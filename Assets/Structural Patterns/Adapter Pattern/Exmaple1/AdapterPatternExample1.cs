//-------------------------------------------------------------------------------------
//	AdapterPatternExample1.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;


//Convert the interface of a class into another interface clients expect. Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.
//This real-world code demonstrates the use of a legacy chemical databank. Chemical compound objects access the databank through an Adapter interface.
//将一个类的接口转换为客户端期望的另一个接口。适配器允许类协同工作，否则由于接口不兼容而无法协同工作。
//这段真实的代码演示了遗留化学数据库的使用。化合物对象通过Adapter接口访问数据库。
namespace AdapterPatternExample1
{
    public class AdapterPatternExample1 : MonoBehaviour
    {
        void Start()
        {
            // Non-adapted chemical compound
            Compound unknown = new Compound("Unknown");
            unknown.Display();

            // Adapted chemical compounds
            Compound water = new RichCompound("Water");
            water.Display();

            Compound benzene = new RichCompound("Benzene");
            benzene.Display();

            Compound ethanol = new RichCompound("Ethanol");
            ethanol.Display();
        }
    }

    /// <summary>
    /// The 'Target' class 目标类  复合物
    /// </summary>
    class Compound
    {
        protected string _chemical;// 化学品
        protected float _boilingPoint;// 沸点
        protected float _meltingPoint;// 熔点
        protected double _molecularWeight; //分子量
        protected string _molecularFormula;// 分子式

        // Constructor //构造函数
        public Compound(string chemical)
        {
            this._chemical = chemical;
        }

        public virtual void Display()
        {
            Debug.Log("\nCompound:  " + _chemical + "------");
        }
    }

    /// <summary>
    /// The 'Adapter' class 适配器类 富化合物
    /// </summary>
    class RichCompound : Compound
    {
        private ChemicalDatabank _bank;

        // Constructor
        public RichCompound(string name)
          : base(name)
        {
        }

        public override void Display()
        {
            // The Adaptee
            _bank = new ChemicalDatabank();

            _boilingPoint = _bank.GetCriticalPoint(_chemical, "B");
            _meltingPoint = _bank.GetCriticalPoint(_chemical, "M");
            _molecularWeight = _bank.GetMolecularWeight(_chemical);
            _molecularFormula = _bank.GetMolecularStructure(_chemical);

            base.Display();
            Debug.Log(" Formula: " + _molecularFormula);
            Debug.Log(" Weight : " + _molecularWeight);
            Debug.Log(" Melting Pt: " + _meltingPoint);
            Debug.Log(" Boiling Pt: " + _boilingPoint);
        }
    }

    /// <summary>
    /// The 'Adaptee' class 需要新增的适配品  化学数据银行....
    /// </summary>
    class ChemicalDatabank
    {
        // The databank 'legacy API'
        // 旧的API  获取临界点
        public float GetCriticalPoint(string compound, string point)
        {
            // Melting Point 熔点
            if (point == "M")
            {
                switch (compound.ToLower())
                {
                    case "water": return 0.0f;
                    case "benzene": return 5.5f;
                    case "ethanol": return -114.1f;
                    default: return 0f;
                }
            }
            // Boiling Point 沸点 
            else
            {
                switch (compound.ToLower())
                {
                    case "water": return 100.0f;
                    case "benzene": return 80.1f;
                    case "ethanol": return 78.3f;
                    default: return 0f;
                }
            }
        }

        // 获取分子结构
        public string GetMolecularStructure(string compound)
        {
            switch (compound.ToLower())
            {
                case "water": return "H20";
                case "benzene": return "C6H6";
                case "ethanol": return "C2H5OH";
                default: return "";
            }
        }

        
        // 获取分子量
        public double GetMolecularWeight(string compound)
        {
            switch (compound.ToLower())
            {
                case "water": return 18.015;
                case "benzene": return 78.1134;
                case "ethanol": return 46.0688;
                default: return 0d;
            }
        }
    }
}