# Template Method Pattern 模板方法模式
## Definition

Define the skeleton of an algorithm in an operation, deferring some steps to subclasses. Template Method lets subclasses redefine certain steps of an algorithm without changing the algorithm's structure.
<br>定义一个操作中的算法的框架，而将一些步骤延迟到子类中。使得子类可以不改变一个算法的结构即可重定义该算法的某些特定步骤。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/template.gif)


## Participants

The classes and objects participating in this pattern are:

### AbstractClass  (DataObject)
* defines abstract primitive operations that concrete subclasses define to implement steps of an algorithm
* implements a template method defining the skeleton of an algorithm. The template method calls primitive operations as well as operations defined in AbstractClass or those of other objects.
* 定义了抽象的基元操作，具体的子类定义了这些操作以实现算法的步骤。
* 实现一个模板方法，定义算法的骨架。模板方法调用基本操作以及AbstractClass中定义的操作或其他对象的操作。

### ConcreteClass  (CustomerDataObject)
* implements the primitive operations ot carry out subclass-specific steps of the algorithm
* 实现基本操作，执行算法中特定子类的步骤。
