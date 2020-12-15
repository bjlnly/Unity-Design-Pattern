//-------------------------------------------------------------------------------------
//	InterpreterExample2.cs
//-------------------------------------------------------------------------------------

using System;
using UnityEngine;
using System.Collections;
using System.Globalization;
using System.Reflection;

public class InterpreterExample2 : MonoBehaviour
{
	void Start ( )
	{
        string question1 = "2 Gallons to pints";
        AskQuestion(question1);

        string question2 = "4 Gallons to tablespoons";
        AskQuestion(question2);
    }

    protected void AskQuestion(string question)
    {    
        // 问题转到解释器上
        ConversionContext context = new ConversionContext(question);
    
        // 固定语法
        string fromConversion = context.fromConversion; // in this example fromConversion is always the second word
        string toConversion = context.toConversion;
        double quantity = context.quantity;

        // Trying to get a matching class for the word "fromConversion"
        try
        {
            // Getting the type, we also have to define the namespace (in this case InterpreterPattern as defined above)
            // and fromConversion should hold the class name (in this case Gallons)
            // 获取类型，我们还必须定义命名空间（在本例中，是InterpreterPattern)
            // 和fromConversion应该持有类名（在本例中是Gallons）。
            Type type = Type.GetType("InterpreterPattern." + fromConversion);
            object instance = Activator.CreateInstance(type);
            Expression expression = instance as Expression;

            // Get the matching method: e.g. (toConversion = pints)
            MethodInfo method = type.GetMethod(toConversion);
            string result = (string)method.Invoke(instance, new object[] { quantity });

            Debug.Log("Output: " + quantity.ToString() + "  " + fromConversion + " are " + result + " " + toConversion);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}


// Context object that does try to make sense of an input string:
// 试图理解输入字符串的上下文对象。
public class ConversionContext
{
    // 转换问题
    public string conversionQues { get; protected set; }
    // from转换
    public string fromConversion { get; protected set; }
    // to转换
    public string toConversion { get; protected set; }
    // 数量
    public double quantity { get; protected set; }
    // 问题的几个部分
    protected string[] partsOfQues;



    // here happens the sensemaking
    // 初步拆解问题
    public ConversionContext(string input)
    {
        Debug.Log("Input: " + input);
        this.conversionQues = input;
        this.partsOfQues = input.Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries);

        if (partsOfQues.Length >= 4)
        {
            // 语法纠正 -- from + s
            fromConversion = GetCapitalized(partsOfQues[1]);
            // 1 gallon to pints
            // to 转为 lower
            toConversion = GetLowerCase(partsOfQues[3]);

            // get quantitiy:
            // 尝试获取数量
            double quant;
            double.TryParse(partsOfQues[0], out quant);
            this.quantity = quant;
        }
    }

    // Some helper methods:
    protected string GetCapitalized(string word)
    {
        word = word.ToLower();
        word = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word);

        // make sure a 's' is appended
        if (word.EndsWith("s") == false)
        {
            word += "s";
        }

        return word;
    }

    protected string GetLowerCase(string word)
    {
        return word.ToLower();
    }
}




// Definition of all the things the concrete expression
// shall be able to convert into
//对具体表达式中所有事物的定义。
//应能转换为目标  -- 抽象解释器
public abstract class Expression
{
    // 加仑
    public abstract string gallons(double quantity);

    // 夸脱
    public abstract string quarts(double quantity);
        
    // 品脱
    public abstract string pints(double quantity);

    // 杯
    public abstract string cups(double quantity);

    // 汤匙
    public abstract string tablespoons(double quantity);
}


// concrete class 具体解释类
// 加仑
public class Gallons : Expression
{
    #region implemented abstract members of Expression
    // 实现了解释器的抽象成员

    public override string gallons(double quantity)
    {
        return quantity.ToString();
    }

    public override string quarts(double quantity)
    {
        return (quantity * 4).ToString();
    }

    public override string pints(double quantity)
    {
        return (quantity * 8).ToString();
    }

    public override string cups(double quantity)
    {
        return (quantity * 16).ToString();
    }

    public override string tablespoons(double quantity)
    {
        return (quantity * 256).ToString();
    }

    #endregion
}
