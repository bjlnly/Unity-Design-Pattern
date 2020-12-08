//-------------------------------------------------------------------------------------
//	BuilderPatternExample1.cs
//-------------------------------------------------------------------------------------

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This real-world code demonstates the Builder pattern in which different vehicles are assembled in a step-by-step fashion. 
//The Shop uses VehicleBuilders to construct a variety of Vehicles in a series of sequential steps.
//这段真实的代码演示了Builder模式，在该模式中，不同的车辆以循序渐进的方式进行组装。
//Shop使用VehicleBuilder以一系列顺序步骤制造各种车辆。
namespace BuilderPatternExample1
{
    public class BuilderPatternExample1 : MonoBehaviour
    {
        void Start()
        {
            // 抽象的车辆建造
            VehicleBuilder builder;

            // Create shop with vehicle builders
            // 创建shop来建造车辆
            Shop shop = new Shop();

            // Construct and display vehicles
            // 构造并展示车辆
            builder = new ScooterBuilder(); // 滑板车
            shop.Construct(builder); // shop发起组装车
            builder.Vehicle.Show(); // 建造者提供组装好的车  车子自行展示

            builder = new CarBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new MotorCycleBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

        }
    }

    /// <summary>
    /// The 'Director' class 导演类
    /// </summary>
    class Shop
    {
        // Builder uses a complex series of steps
        // 建造者通过一系列复杂步骤  构建车子  具体步骤是导演类控制的
        // 导演类操作的是抽象的车子  代码面向抽象建造类
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            // 车辆组装有很多抽象步骤
            // 组装框架
            // 组装引擎
            // 组装轮子
            // 组装门
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWheels();
            vehicleBuilder.BuildDoors();
        }
    }

    /// <summary>
    /// The 'Builder' abstract class 抽象的车辆建造类
    /// </summary>
    abstract class VehicleBuilder
    {
        // 提供建造后的产品
        // 由于产品本身就是复杂的,具体的,目标物
        // 产品本身并不需要抽象
        protected Vehicle vehicle;

        // Gets vehicle instance
        public Vehicle Vehicle
        {
            get { return vehicle; }
        }

        // Abstract build methods
        // 抽象的步奏
        public abstract void BuildFrame();
        public abstract void BuildEngine();
        public abstract void BuildWheels();
        public abstract void BuildDoors();
    }

    /// <summary>
    /// The 'ConcreteBuilder1' class 具体的组装类
    /// </summary>
    class MotorCycleBuilder : VehicleBuilder
    {
        // 构造的时候,声明本组装类服务的组装目标
        public MotorCycleBuilder()
        {
            vehicle = new Vehicle("MotorCycle");
        }

        public override void BuildFrame()
        {
            vehicle["frame"] = "MotorCycle Frame";
        }

        public override void BuildEngine()
        {
            vehicle["engine"] = "500 cc";
        }

        public override void BuildWheels()
        {
            vehicle["wheels"] = "2";
        }

        public override void BuildDoors()
        {
            vehicle["doors"] = "0";
        }
    }


    /// <summary>
    /// The 'ConcreteBuilder2' class 具体的组装类2
    /// </summary>
    class CarBuilder : VehicleBuilder
    {
        public CarBuilder()
        {
            vehicle = new Vehicle("Car");
        }

        public override void BuildFrame()
        {
            vehicle["frame"] = "Car Frame";
        }

        public override void BuildEngine()
        {
            vehicle["engine"] = "2500 cc";
        }

        public override void BuildWheels()
        {
            vehicle["wheels"] = "4";
        }

        public override void BuildDoors()
        {
            vehicle["doors"] = "4";
        }
    }

    /// <summary>
    /// The 'ConcreteBuilder3' class 具体建造类3
    /// </summary>
    class ScooterBuilder : VehicleBuilder
    {
        public ScooterBuilder()
        {
            vehicle = new Vehicle("Scooter");
        }

        public override void BuildFrame()
        {
            vehicle["frame"] = "Scooter Frame";
        }

        public override void BuildEngine()
        {
            vehicle["engine"] = "50 cc";
        }

        public override void BuildWheels()
        {
            vehicle["wheels"] = "2";
        }

        public override void BuildDoors()
        {
            vehicle["doors"] = "0";
        }
    }

    /// <summary>
    /// The 'Product' class 复杂的目标产品
    /// </summary>
    class Vehicle
    {
        // 产品名字
        private string _vehicleType;
        // 复杂的产品部分
        private Dictionary<string, string> _parts =
          new Dictionary<string, string>();

        // Constructor 构造函数
        public Vehicle(string vehicleType)
        {
            this._vehicleType = vehicleType;
        }

        // Indexer
        // 模块的索引
        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }
  
        // 产品的展示
        public void Show()
        {
            Debug.Log("\n---------------------------");
            Debug.Log("Vehicle Type: " + _vehicleType);
            Debug.Log(" Frame : " + _parts["frame"]);
            Debug.Log(" Engine : " + _parts["engine"]);
            Debug.Log(" #Wheels: " + _parts["wheels"]);
            Debug.Log(" #Doors : " + _parts["doors"]);
        }
    }
}
