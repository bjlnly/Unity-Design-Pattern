//-------------------------------------------------------------------------------------
//	AbstractFactoryPatternExample2.cs
//-------------------------------------------------------------------------------------

// allows a family of related objects without specifying the concrete class
// when there are many objects that can be added or changed dynamically
// you can model everything you can image and have those objects interact through common interfaces

// negative: can get very complicated
//允许使用一系列相关对象，而不指定具体的类。
//当存在多个可以动态添加或更改的对象时。
//您可以对您能想象到的一切进行建模，并让这些对象通过公共接口进行交互。

//负面：可能会变得非常复杂

using UnityEngine;
using System.Collections;

namespace AbstractFactoryPatternExample2
{

    public class AbstractFactoryPatternExample2 : MonoBehaviour
    {
	    void Start ( )
	    {
            EnemyShipBuilding ufoBuilder = new UFOEnemyShipBuilding();
            ufoBuilder.orderShip(ShipType.UFO);
        }
    }

    public enum ShipType
    {
        UFO
    }

    // 抽象类  敌舰建造  抽象订单
    public abstract class EnemyShipBuilding
    {
        // abstract order form:
        protected abstract EnemyShip MakeEnemyShip(ShipType type);

        // 飞船订单
        public EnemyShip orderShip(ShipType type)
        {
            EnemyShip ship = MakeEnemyShip(type);

            ship.MakeShip();
            ship.DisplayShip();
            ship.FollowHeroShip();
            ship.Shoot();

            return ship;
        }
    }

    // 船只建造具体类
    public class UFOEnemyShipBuilding : EnemyShipBuilding
    {
        // Make Ship varies per ship type...
        protected override EnemyShip MakeEnemyShip(ShipType type)
        {
            EnemyShip ship = null;

            if (type == ShipType.UFO)
            {
                IEnemyShipFactory factory = new UFOEnemyShipFactory();
                ship = new UFOEnemyShip(factory);
                ship.name = "UFO";
            }

            return ship;
        }
    }




    // 抽象工厂  敌船工厂
    public interface IEnemyShipFactory
    {
        IESWeapon AddESGun();
        IESEngine AddESEngine();
    }
    
    // 具体工厂  UFO工厂
    public class UFOEnemyShipFactory : IEnemyShipFactory
    {
        // each factory can add different weapons and stuff
        public IESWeapon AddESGun()
        {
            return new ESUFOGun();
        }

        public IESEngine AddESEngine()
        {
            return new ESUFOEngine();
        }
    }




    // 敌人船只  抽象产品组
    public abstract class EnemyShip
    {
        public string name;
        // 引擎接口
        protected IESEngine engine;
        // 武器接口
        protected IESWeapon weapon;

        // 制作船  抽象接口
        public abstract void MakeShip();

        public void DisplayShip()
        {
            Debug.Log(name + " is on the screen.");
        }

        public void FollowHeroShip()
        {
            Debug.Log(name + " follows hero ship with " + engine.ToStringEX());
        }

        public void Shoot()
        {
            Debug.Log(name + " shoots and does " + weapon.ToStringEX());
        }

        public string ToStringEX()
        {
            return "The " + name + " has a speed of " + engine.ToStringEX() + " a firepower of " + weapon.ToStringEX();
        }
    }

    // 具体产品组  UFO
    public class UFOEnemyShip : EnemyShip
    {
        IEnemyShipFactory factory;

        public UFOEnemyShip(IEnemyShipFactory factory)
        {
            this.factory = factory;
        }

        public override void MakeShip()
        {
            Debug.Log("Making enemy ship " + name);
            weapon = factory.AddESGun();
            engine = factory.AddESEngine();
        }
    }


    // 武器接口
    // possible Weapons to swap in and out
    public interface IESWeapon
    {
        string ToStringEX();
    }
    // 引擎接口
    public interface IESEngine
    {
        string ToStringEX();
    }

    // 武器接口的具体实现
    public class ESUFOGun : IESWeapon
    {
        public string ToStringEX()
        {
            return "20 damage";
        }
    }
    // 引擎接口的具体实现
    public class ESUFOEngine : IESEngine
    {
        public string ToStringEX()
        {
            return "1000 mph";
        }
    }


}

