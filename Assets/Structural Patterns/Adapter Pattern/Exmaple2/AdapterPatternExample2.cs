//-------------------------------------------------------------------------------------
//	AdapterPatternExample2.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

namespace AdapterPatternExample2
{
    // 模拟了敌方攻击者  在初期只有坦克  未来增加了机器人后  操作不改变
    public class AdapterPatternExample2 : MonoBehaviour
    {
        void Start()
        {
            // 坦克
            IEnemyAttacker tank = new EnemyTank();
            // 机器人
            EnemyRobot fredTheRobot = new EnemyRobot();
            // 机器人适配器
            IEnemyAttacker adapter = new EnemyRobotAdaper(fredTheRobot);
            // 直接调用的话,Main需要掌握新的类,新的函数
            fredTheRobot.ReactToHuman("Hans");
            fredTheRobot.WalkForward();
        
            // 适配器适配后  可以用旧的函数操作机器人的类似代码
            tank.AssignDriver("Frank");
            tank.DriveForward();
            tank.FireWeapon();

            adapter.AssignDriver("Mark");
            adapter.DriveForward();
            adapter.FireWeapon();
        }
    }



    // 敌人抽象接口
    public interface IEnemyAttacker
    {
        void FireWeapon();
        void DriveForward();
        void AssignDriver(string driver);
    }


    // 敌人坦克
    public class EnemyTank : IEnemyAttacker
    {
        public void FireWeapon()
        {
            int attackDamage = Random.Range(1, 10);
            Debug.Log("Enemy Tank does " + attackDamage + " damage");
        }

        public void DriveForward()
        {
            int movement = Random.Range(1, 5);
            Debug.Log("Enemy Tank moves " + movement + " spaces");
        }

        public void AssignDriver(string driver)
        {
            Debug.Log(driver + " is driving the tank");
        }
    }




    // Adaptee: // 需要适配的新类  机器人
    public class EnemyRobot
    {
        // 机器人由新的属性
        public void SmashWithHands()
        {
            int attackDamage = Random.Range(1, 10);
            Debug.Log("Robot causes " + attackDamage + " damage with it hands");
        }

        public void WalkForward()
        {
            int movement = Random.Range(1, 3);
            Debug.Log("Robot walks " + movement + " spaces");
        }

        public void ReactToHuman(string driverName)
        {
            Debug.Log("Robot tramps on " + driverName);
        }
    }


    // 适配器继承了旧的敌人接口
    public class EnemyRobotAdaper : IEnemyAttacker
    {
        // 依赖了新的机器人
        EnemyRobot robot;

        public EnemyRobotAdaper(EnemyRobot robot)
        {
            this.robot = robot;
        }

        // 旧的函数下  操作机器人的类似函数
        public void FireWeapon()
        {
            robot.SmashWithHands();
        }

        public void DriveForward()
        {
            robot.WalkForward();
        }

        public void AssignDriver(string driver)
        {
            robot.ReactToHuman(driver);
        }
    }
}
