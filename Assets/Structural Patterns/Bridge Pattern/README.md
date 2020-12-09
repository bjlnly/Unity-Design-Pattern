
# Bridge Pattern 桥接模式
## Definition

Decouple an abstraction from its implementation so that the two can vary independently.
<br>将抽象和实现解耦，使得两者可以独立地变化。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/bridge.gif)


## Participants

The classes and objects participating in this pattern are:

### Abstraction   (BusinessObject)抽象
* defines the abstraction's interface.
* maintains a reference to an object of type Implementor.
<br>定义抽象的接口
<br>*维护对Implementor类型的对象的引用。
### RefinedAbstraction   (CustomersBusinessObject)
* extends the interface defined by Abstraction.
<br>拓展抽象定义的接口 
### Implementor   (DataObject) 实现
* defines the interface for implementation classes. This interface doesn't have to correspond exactly to Abstraction's interface; in fact the two interfaces can be quite different. Typically the Implementation interface provides only primitive operations, and Abstraction defines higher-level operations based on these primitives.
<br>定义实现类的接口。该接口不必完全对应于抽象的接口；事实上，这两个接口可以完全不同。通常，实现接口只提供原语操作，抽象基于这些原语定义更高级别的操作。
### ConcreteImplementor   (CustomersDataObject)
* implements the Implementor interface and defines its concrete implementation.
<br>*实现Implementor接口并定义其具体实现。
