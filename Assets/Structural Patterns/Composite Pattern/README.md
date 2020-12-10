# Composite Pattern 组合模式
## Definition

Compose objects into tree structures to represent part-whole hierarchies. Composite lets clients treat individual objects and compositions of objects uniformly.
<br>将对象组合成树形结构以表示“部分-整体”的层次结构，使得用户对单个对象和组合对象的使用具有一致性。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/composite.gif)


## Participants

The classes and objects participating in this pattern are:

### Component   (DrawingElement)
* declares the interface for objects in the composition.
* implements default behavior for the interface common to all classes, as appropriate.
* declares an interface for accessing and managing its child components.
* (optional) defines an interface for accessing a component's parent in the recursive structure, and implements it if that's appropriate.
<br>*声明组合中对象的接口。
<br>*根据需要为所有类通用的接口实现默认行为。
<br>*声明用于访问和管理其子组件的接口。
<br>*(可选)定义用于访问递归结构中组件的父级的接口，并在适当的情况下实现该接口。
### Leaf   (PrimitiveElement)
* represents leaf objects in the composition. A leaf has no children.
* defines behavior for primitive objects in the composition.
* 代表构图中的叶子对象。一个叶子没有子对象。
* 定义组成中的原始对象的行为。

### Composite   (CompositeElement)
* defines behavior for components having children.
* stores child components.
* implements child-related operations in the Component interface.
* 定义有子组件的行为。
* 存储子组件。
* 在Component接口中实现与子组件相关的操作。
### Client  (CompositeApp)
* manipulates objects in the composition through the Component interface.
* 通过Component接口操作组成中的对象。
