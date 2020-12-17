# Observer Pattern 观察者模式
## Definition

Define a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.
<br>定义对象间一种一对多的依赖关系，使得每当一个对象改变状态，则所有依赖于它的对象都会得到通知并被自动更新。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/observer.gif)


## Participants

The classes and objects participating in this pattern are:

### Subject  (Stock)
* knows its observers. Any number of Observer objects may observe a subject
* provides an interface for attaching and detaching Observer objects.
* 了解其观察者。任何数量的观察者对象都可以观察一个主体。
* 提供了一个附加和分离观察者对象的接口。

### ConcreteSubject  (IBM)
* stores state of interest to ConcreteObserver
* sends a notification to its observers when its state changes
* 存储ConcreteObserver感兴趣的状态。
* 当其状态发生变化时，向其观察者发出通知。

### Observer  (IInvestor)
* defines an updating interface for objects that should be notified of changes in a subject.
* 定义了一个对象的更新接口，该接口应通知对象的变化。

* maintains a reference to a ConcreteSubject object
### ConcreteObserver  (Investor)
* stores state that should stay consistent with the subject's
* implements the Observer updating interface to keep its state consistent with the subject's
* 维护对ConcreteSubject对象的引用。
* 存储状态应与subject的状态保持一致。
* 实现Observer更新接口，使其状态与subject的状态保持一致。
