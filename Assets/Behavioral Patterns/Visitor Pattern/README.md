# Visitor Pattern 访问者模式
## Definition

Represent an operation to be performed on the elements of an object structure. Visitor lets you define a new operation without changing the classes of the elements on which it operates.
<br>封装一些作用于某种数据结构中的各元素的操作，它可以在不改变数据结构的前提下定义作用于这些元素的新的操作。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/visitor.gif)


## Participants

The classes and objects participating in this pattern are:

### Visitor  (Visitor)
* declares a Visit operation for each class of ConcreteElement in the object structure. The operation's name and signature identifies the class that sends the Visit request to the visitor. That lets the visitor determine the concrete class of the element being visited. Then the visitor can access the elements directly through its particular interface
* 为对象结构中的每个ConcreteElement类声明一个Visit操作。该操作的名称和签名标识了向访问者发送访问请求的类。这让访问者确定被访问元素的具体类。然后访问者可以直接通过它的特定接口访问元素
### ConcreteVisitor  (IncomeVisitor, VacationVisitor)
* implements each operation declared by Visitor. Each operation implements a fragment of the algorithm defined for the corresponding class or object in the structure. ConcreteVisitor provides the context for the algorithm and stores its local state. This state often accumulates results during the traversal of the structure.
* 实现Visitor声明的每个操作。每个操作都实现了为结构中相应的类或对象定义的算法的一个片段。ConcreteVisitor为算法提供上下文，并存储其本地状态。这个状态经常在结构的遍历过程中积累结果。
### Element  (Element)
* defines an Accept operation that takes a visitor as an argument.
* 定义了一个以访问者为参数的Accept操作。
### ConcreteElement  (Employee)
* implements an Accept operation that takes a visitor as an argument
* 实现以访问者为参数的Accept操作。
### ObjectStructure  (Employees)
* can enumerate its elements
* may provide a high-level interface to allow the visitor to visit its elements
* may either be a Composite (pattern) or a collection such as a list or a set
* 可以列举其要素
* 可提供一个高级接口，使访问者能够访问其要素；
* 可以是一个复合体（模式），也可以是一个集合，如列表或集合。
