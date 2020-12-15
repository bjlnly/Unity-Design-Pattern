//-------------------------------------------------------------------------------------
//	InterpreterStructrue.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class InterpreterStructrue : MonoBehaviour
{
	void Start ( )
    {
        // 先定义一段上下文
        Context context = new Context();

        // Usually a tree 
        // 构建一段语法树
        ArrayList list = new ArrayList();

        // Populate 'abstract syntax tree'
        // 填充抽象语法树
        list.Add(new TerminalExpression());
        list.Add(new NonterminalExpression());
        list.Add(new TerminalExpression());
        list.Add(new TerminalExpression());

        // Interpret
        // 通过语法树解释上下文的内容
        foreach (AbstractExpression exp in list)
        {
            exp.Interpret(context);
        }

    }
}

/// <summary>
/// The 'Context' class 上下文类
/// </summary>
class Context
{
}

/// <summary>
/// The 'AbstractExpression' abstract class 抽象的解释器类
/// </summary>
abstract class AbstractExpression
{
    public abstract void Interpret(Context context);
}

/// <summary>
/// The 'TerminalExpression' class 终端解释器
/// </summary>
class TerminalExpression : AbstractExpression
{
    public override void Interpret(Context context)
    {
        Debug.Log("Called Terminal.Interpret()");
    }
}

/// <summary>
/// The 'NonterminalExpression' class 非终端解释器
/// </summary>
class NonterminalExpression : AbstractExpression
{
    public override void Interpret(Context context)
    {
        Debug.Log("Called Nonterminal.Interpret()");
    }
}