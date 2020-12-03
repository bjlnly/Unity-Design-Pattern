# Prototype Pattern 原型模式
## Definition

Specify the kind of objects to create using a prototypical instance, and create new objects by copying this prototype.
<br>用原型实例指定创建对象的种类，并且通过拷贝这些原型创建新的对象。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/prototype.gif)


## Participants

The classes and objects participating in this pattern are:

### Prototype  (ColorPrototype) 原型
* declares an interface for cloning itself 
<br>声明用于克隆自身的接口

### ConcretePrototype  (Color) 具体的原型
* implements an operation for cloning itself
<br>实现克隆自身的操作
### Client  (ColorManager) 委托人
* creates a new object by asking a prototype to clone itself
<br>通过要求原型克隆自身来创建新对象 
