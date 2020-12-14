//-------------------------------------------------------------------------------------
//	ChainOfResponsibilityExample2.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class ChainOfResponsibilityExample2 : MonoBehaviour
{


	void Start ( )
	{
		// create calculation objects that get chained to each other in a sec
		// 创建一堆责任链对象
		Chain calc1 = new AddNumbers();
		Chain calc2 = new SubstractNumbers();
		Chain calc3 = new DivideNumbers();
		Chain calc4 = new MultiplyNumbers();

		// now chain them to each other
		// 设置责任关系
		calc1.SetNextChain(calc2);
		calc2.SetNextChain(calc3);
		calc3.SetNextChain(calc4);

		// this is the request that will be passed to a chain object to let them figure out which calculation objects it the right for the request
		// the request is here the CalculationType enum we add. so we want this pair of numbers to be added
		// 这是将传递给链对象的请求，让他们弄清楚哪些计算对象是正确的请求。
		//请求在这里是我们添加的CalculationType枚举.所以我们要添加这对数字。
		Numbers myNumbers = new Numbers(3, 5, CalculationType.Add);
		calc1.Calculate(myNumbers);

		// another example:
		Numbers myOtherNumbers = new Numbers(6, 2, CalculationType.Multiply);
		calc1.Calculate(myOtherNumbers);

		// or pass it to some chain object inbetween which will not work in this case:
		// 或者将其传递给中间的某个链对象，在这种情况下是行不通的。
		Numbers myLastNumbers = new Numbers(12, 3, CalculationType.Substract);
		calc3.Calculate(myLastNumbers);		
	}


	// just defining some types of calculation we want to implement
	// it is better than passing string values as requests because you don't risk any typos that way :)
	//只是定义了一些我们想要实现的计算类型。
	// 这比用请求的方式传递字符串值要好，因为这样你不会有任何错别字的风险:)
	public enum CalculationType
	{
		Add,
		Substract,
		Divide,
		Multiply
	};




	// We use this object as an example object to be passed to the calculation chain ;-)
	// to figure out what we want to do with it (which is stored in CalculationType/calculationWanted)
	// 我们把这个对象作为一个例子对象，传递给计算链 ;-)
	// 弄清楚我们要对它做什么（它存储在CalculationType/calculationWanted中）。

	public class Numbers
	{
		// some numbers:
		public int number1 { get; protected set; }
		public int number2 { get; protected set; }

		// here we store in this object what we want to do with it to let the chain figure out who is responsible for it ;-)
		// 在这里，我们在这个对象中存储了我们想对它做的事情，让责任链找出谁对它负责;-)
		public CalculationType calculationWanted { get; protected set; }

		// constructor:
		public Numbers(int num1, int num2, CalculationType calcWanted)
		{
			this.number1 = num1;
			this.number2 = num2;
			this.calculationWanted = calcWanted;
		}
	}

	
	// doesn't need to be called chain of course ;-)
	// 命名chain 是为了方便理解
	public interface Chain
	{
		// 设置下一个责任人
		void SetNextChain(Chain nextChain); // to be called when calulcation fails
		// 尝试执行操作
		void Calculate(Numbers numbers); // try to calculate
	}


	// 具体的责任人 加法
	public class AddNumbers : Chain
	{
		// each chain object stored a private nextInChain object, that gets called when the method calculate fails
		// 私有的chain内聚 是为了处理失败的时候,可以继续传递下去
		protected Chain nextInChain;

		public void SetNextChain(Chain nextChain)
		{
			this.nextInChain = nextChain;
		}

		public void Calculate(Numbers request)
		{
			if(request.calculationWanted == CalculationType.Add)
			{
				Debug.Log("Adding: " + request.number1 + " + " + request.number2 + " = " + (request.number1 + request.number2).ToString());
			}
			else if(nextInChain != null)
				nextInChain.Calculate(request);
			else
				Debug.Log ("Handling of request failed: " + request.calculationWanted);
		}
	}

	// 减法
	public class SubstractNumbers : Chain
	{
		protected Chain nextInChain;

		public void SetNextChain(Chain nextChain)
		{
			this.nextInChain = nextChain;
		}

		public void Calculate(Numbers request)
		{
			if(request.calculationWanted == CalculationType.Substract)
			{
				Debug.Log("Substracting: " + request.number1 + " - " + request.number2 + " = " + (request.number1 - request.number2).ToString());
			}
			else if(nextInChain != null)
				nextInChain.Calculate(request);
			else
				Debug.Log ("Handling of request failed: " + request.calculationWanted);
		}
	}
	// 除法
	public class DivideNumbers : Chain
	{
		protected Chain nextInChain;
		
		public void SetNextChain(Chain nextChain)
		{
			this.nextInChain = nextChain;
		}
		
		public void Calculate(Numbers request)
		{
			if(request.calculationWanted == CalculationType.Divide)
			{
				Debug.Log("Dividing: " + request.number1 + " / " + request.number2 + " = " + (request.number1 / request.number2).ToString());
			}
			else if(nextInChain != null)
				nextInChain.Calculate(request);
			else
				Debug.Log ("Handling of request failed: " + request.calculationWanted);
		}
	}
	
	// 乘法
	public class MultiplyNumbers : Chain
	{
		protected Chain nextInChain;
		
		public void SetNextChain(Chain nextChain)
		{
			this.nextInChain = nextChain;
		}
		
		public void Calculate(Numbers request)
		{
			if(request.calculationWanted == CalculationType.Multiply)
			{
				Debug.Log("Multiplying: " + request.number1 + " * " + request.number2 + " = " + (request.number1 * request.number2).ToString());
			}
			else if(nextInChain != null)
				nextInChain.Calculate(request);
			else
				Debug.Log ("Handling of request failed: " + request.calculationWanted);
		}
	}

}
