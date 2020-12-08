# Builder Pattern 建造者模式
## Definition

Separate the construction of a complex object from its representation so that the same construction process can create different representations.
<br>将一个复杂对象的构造与它的表示分离，使同样的构建过程可以创建不同的表示，这样的设计模式被称为建造者模式。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/builder.gif)


## Participants

The classes and objects participating in this pattern are:

### Builder  (VehicleBuilder)
* specifies an abstract interface for creating parts of a Product object
<br>指定用于创建Product对象的各个部分的抽象接口
### ConcreteBuilder  (MotorCycleBuilder, CarBuilder, ScooterBuilder)
* constructs and assembles parts of the product by implementing the Builder interface
* defines and keeps track of the representation it creates
* provides an interface for retrieving the product
<br>通过实现Builder接口来构造和组装产品的各个部分。
<br>*定义并跟踪其创建的表示。
<br>*提供检索产品的接口
### Director  (Shop)
* constructs an object using the Builder interface
<br>使用Builder接口构造对象
### Product  (Vehicle)
* represents the complex object under construction. ConcreteBuilder builds the product's internal representation and defines the process by which it's assembled
* includes classes that define the constituent parts, including interfaces for assembling the parts into the final result
<br>*表示正在构造的复杂对象。ConcreteBuilder构建产品的内部表示并定义其组装过程。
<br>*包括定义组成部分的类，包括将组成部分组装成最终结果的接口
