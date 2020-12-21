### Chain of Responsibility Pattern 责任链模式  -- sender 和 receiver 解耦
#### Handler: Request接口,private Handler
#### ConcreteHandler : 实现Request,不能操作就传给下一个Handler

### Command Pattern 命令模式 -- request as object -- invoker 和 receiver解耦 
#### Command: operation接口
#### ConcreteCommand: bind receiver&&request --> Receiver Do
#### Invoker: Ask --> Command
#### Receiver: DoSomething
#### Client: 创建ConcreteCommand,设置Receiver

### Interpreter Pattern 解释器模式 -- 构建Expression树,解析Context 
#### AbstractExpression: Interpret接口,抽象语法
#### TerminalExpression: 实现终端的Interpreter,终端符号
#### NonTerminalExpression: 非终端的Interpreter,实现具体每行的解释
#### Context: 被解释的上下文
#### Client: 创建抽象语法树--Terminal&&NonTerminal;;Call Interpreter

### Iterator Pattern 迭代器模式 -- 顺序访问任何内容--隐藏底层结构
#### Iterator: 定义操作elements的接口 
#### ConcreteIterator: 实现Iterator接口,track当前位置 -->具体访问
#### Aggregate: 定义创建Iterator对象的接口
#### ConcreteAggregate: 实现Create Iterator,返回ConcreteIterator -->隐藏elements

### Mediator Pattern 中介者模式 -- 聊天室 -- 降低大量相互通讯对象之间的耦合
#### Mediator: 与Colleague通讯的接口
#### ConcreteMediator: 协调Colleague,维护colleagues列表
#### Colleague: 了解Mediator,通过Mediator跟其他Colleague通讯

### Memento Pattern 备忘录模式 -- 备份/恢复数据
#### Memento: 存储Originator的内部状态  -- 两个访问接口分别提供给Originator,CareTaker
#### Originator: create -> Memento, copy to -> Memento, copy from -> Memento
#### CareTaker:keep Mementos,不访问具体内容

### NullObject Pattern 空值模式 -- 默认状态
#### AbstractCustomer: 抽象对象
#### RealCustomer: 真实状态
#### NullCustomer: 默认状态
#### CustomerFactory: 维护Customer的工厂

### Observer Pattern 观察者模式 -- 一对多的依赖
#### Subject: 被观察主体,提供增加和剔除Observer的接口
#### ConcreteSubject: 存储state,改变时候sends notification 给ConcreteObserver
#### Observer: Update接口,Subject改变时候,接收通知
#### ConcreteObserver: 引用ConcreteSubject,存储和ConcreteSubject一致的State,实现Update接口

### State Pattern 状态模式 -- Context -> ConcreteState -> Behavior
#### Context: 接口供Client使用,维护ConcreteState实例-->操作行为
#### State: 接口->封装Context行为
#### ConcreteState: 实现具体State的Behavior

### Strategy Pattern 策略模式 -- 选用不同的算法/可互换
#### Strategy: 接口->供 Context 调用
#### ConcreteStrategy: 实现算法
#### Context: 引用->Strategy, 接口->供Strategy访问

### Template Method Pattern 模板模式 -- 不同的二级类似算法
#### AbstractClass: base操作 && Template Method->调用base
#### ConcreteClass: 实现接口--不同的二级算法

### Visitor Pattern 访问者模式
#### ObjectStructure: elements列表/Accept Method->Visitor 访问 element
#### Element: Accept接口 -> Visitor
#### ConcreteElement: 实现 Accept
#### Visitor: Visit接口 -> All ConcreteElement
#### ConcreteVisitor: 实现 Visit,操作ConcreteElement 