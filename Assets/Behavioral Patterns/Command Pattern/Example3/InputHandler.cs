/// <summary>
/// The 'Invoker' class that makes calls to execute the commands
/// </summary>

using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// 输入处理 Client 操作角色移动的案例
/// </summary>
public class InputHandler : MonoBehaviour
{
    public float moveDistance = 10f;
    public GameObject objectToMove;

    private MoveCommandReceiver moveCommandReciever;
    private List<MoveCommand> commands = new List<MoveCommand>();
    private int currentCommandNum = 0;

    void Start()
    {
        // 创建一个接收者
        moveCommandReciever = new MoveCommandReceiver();

        if (objectToMove == null)
        {
            Debug.LogError("objectToMove must be assigned via inspector");
            this.enabled = false;
        }
    }

/// <summary>
/// 撤销
/// </summary>
    public void Undo()
    {
        if (currentCommandNum > 0)
        {
            currentCommandNum--;
            MoveCommand moveCommand = commands[currentCommandNum];
            moveCommand.UnExecute();
        }
    }
/// <summary>
/// 重做
/// </summary>
    public void Redo()
    {
        if (currentCommandNum < commands.Count)
        {
            MoveCommand moveCommand = commands[currentCommandNum];
            currentCommandNum++;
            moveCommand.Execute();
        }
    }

/// <summary>
/// 创建命令
/// </summary>
/// <param name="direction"></param>
    private void Move(MoveDirection direction)
    {
        MoveCommand moveCommand = new MoveCommand(moveCommandReciever, direction, moveDistance, objectToMove);
        moveCommand.Execute();
        commands.Add(moveCommand);
        currentCommandNum++;
    }


    //Simple move commands to attach to UI buttons
    // 几个命令 -- 方便和UI按钮绑定
    public void MoveUp() { Move(MoveDirection.up); }
    public void MoveDown() { Move(MoveDirection.down); }
    public void MoveLeft() { Move(MoveDirection.left); }
    public void MoveRight() { Move(MoveDirection.right); }

    //Shows what's going on in the command list
    // 打印命令列表
    void OnGUI()
    {
        string label = "   start";
        if (currentCommandNum == 0)
        {
            label = ">" + label;
        }
        label += "\n";

        for (int i = 0; i < commands.Count; i++)
        {
            if (i == currentCommandNum - 1)
                label += "> " + commands[i].ToString() + "\n";
            else
                label += "   " + commands[i].ToString() + "\n";

        }
        GUI.Label(new Rect(0, 0, 400, 800), label);
    }

    /// <summary>
    /// 触发命令执行
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Redo();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            Undo();
        }
    }
}
