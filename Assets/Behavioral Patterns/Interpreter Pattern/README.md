# Interpreter Pattern 解释器模式
## Definition

Given a language, define a representation for its grammar along with an interpreter that uses the representation to interpret sentences in the language.
<br>给定一门语言，定义它的文法的一种表示，并定义一个解释器，该解释器使用该表示来解释语言中的句子。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/interpreter.gif)


## Participants

The classes and objects participating in this pattern are:

### AbstractExpression  (Expression)
* declares an interface for executing an operation
* 声明一个执行业务的接口；
### TerminalExpression  ( ThousandExpression, HundredExpression, TenExpression, OneExpression )
* implements an Interpret operation associated with terminal symbols in the grammar.
* an instance is required for every terminal symbol in the sentence.
* 实现了与语法中终端符号相关联的 Interpret 操作； 
* 句子中的每个终端符号都需要一个实例。

### NonterminalExpression  ( not used )
* one such class is required for every rule R ::= R1R2...Rn in the grammar
* maintains instance variables of type AbstractExpression for each of the symbols R1 through Rn.
* implements an Interpret operation for nonterminal symbols in the grammar. Interpret typically calls itself recursively on the variables representing R1 through Rn.
* 语法中的每条规则R::=R1R2...Rn都需要一个这样的类。
* 为每个符号R1到Rn维护AbstractExpression类型的实例变量。
* 为语法中的非终端符号实现一个 Interpret 操作。Interpret通常对代表R1到Rn的变量进行递归调用。

### Context  (Context)
* contains information that is global to the interpreter
* 包含解释者的全局信息。
### Client  (InterpreterApp)
* 构建(或给定)表示语法定义的语言中特定句子的抽象语法树。抽象语法树由NonTeralExpression和TerminalExpression类的实例组装而成。
* 调用解释操作
