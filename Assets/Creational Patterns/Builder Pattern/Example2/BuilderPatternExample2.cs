//-------------------------------------------------------------------------------------
//	BuilderPatternExample2.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

namespace BuilderPatternExample2
{
    // 机器人由多个复杂步骤组成  抽象
    // 工程师设置步骤,组装机器人 抽象
    // 建造者执行具体的组装,并且分多个步骤,每个步骤相互独立  步骤--抽象  具体的机器人
    // 组装后,建造者提供具体的机器人
    public class BuilderPatternExample2 : MonoBehaviour
    {
        void Start()
        {
            // 机器人建造者
            IRobotBuilder oldRobot = new OldRobotBuilder();
            // 机器人工程师 -- 负责配置机器人
            RobotEngineer engineer = new RobotEngineer(oldRobot);
            // 工程师开始设置步骤来建造机器人
            engineer.MakeRobot();

            // 机器人建造后  打印机器人信息
            Robot firstRobot = engineer.GetRobot();
            Debug.Log("First Robot built");
            Debug.Log(firstRobot.ToStringEX());
        }
    }

    // 机器人设计
    public interface IRobotPlan
    {
        // 设计头
        void SetRobotHead(string head);
        // 设计躯干
        void SetRobotTorso(string torso);
        // 设计手
        void SetRobotArms(string arms);
        // 设计腿
        void SetRobotLegs(string legs);
    }

    // 符合设计机器人的具体机器人
    public class Robot : IRobotPlan
    {
        public string head { get; protected set; }
        public string torso { get; protected set; }
        public string arms { get; protected set; }
        public string legs { get; protected set; }

        public void SetRobotHead(string head)
        {
            this.head = head;
        }

        public void SetRobotTorso(string torso)
        {
            this.torso = torso;
        }

        public void SetRobotArms(string arms)
        {
            this.arms = arms;
        }

        public void SetRobotLegs(string legs)
        {
            this.legs = legs;
        }

        public string ToStringEX()
        {
            return "Head: " + this.head + ", torso: " + this.torso + ", Arms: " + arms + ", legs: " + legs;
        }
    }




    // they're kinda like a blueprint these RobotBuilder classes:
    // 机器人建造的蓝图  建造者抽象接口
    public interface IRobotBuilder
    {
        Robot GetRobot();
        void BuildRobotHead();
        void BuildRobotTorso();
        void BuildRobotArms();
        void BuildRobotLegs();
    }

    // for each new robot that you might want to have just create a new RobotBuilder Object
    // 具体的建造类
    public class OldRobotBuilder : IRobotBuilder
    {
        protected Robot robot { get; set; }

        public OldRobotBuilder()
        {
            this.robot = new Robot();
        }
        
        // 返回建造好的机器人
        public Robot GetRobot()
        {
            return robot;
        }

        // 具体的组装步骤
        public void BuildRobotHead()
        {
            this.robot.SetRobotHead("Old Head");
        }

        public void BuildRobotTorso()
        {
            this.robot.SetRobotTorso("Old Torso");
        }

        public void BuildRobotArms()
        {
            this.robot.SetRobotArms("Old Arms");
        }

        public void BuildRobotLegs()
        {
            this.robot.SetRobotLegs("Roller Skates");
        }
    }



    // he just calls the method in the Robot Objects (which are defined by the interface, just think of blueprints)
    // 机器人工程师  导演的角色  如何组装  面向的都是抽象的
    public class RobotEngineer
    {
        // 抽象的机器人
        public IRobotBuilder robotBuilder { get; protected set; }

        public RobotEngineer(IRobotBuilder builder)
        {
            this.robotBuilder = builder;
        }

        // 导演提供的产品,实际是建造者建好后,导演从建造者那里拿到的
        public Robot GetRobot()
        {
            return this.robotBuilder.GetRobot();
        }

        // 抽象的组装步骤
        public void MakeRobot()
        {
            this.robotBuilder.BuildRobotHead();
            this.robotBuilder.BuildRobotTorso();
            this.robotBuilder.BuildRobotArms();
            this.robotBuilder.BuildRobotLegs();
        }
    }


}
