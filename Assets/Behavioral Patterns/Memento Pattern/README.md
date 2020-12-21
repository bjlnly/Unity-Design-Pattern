
# Memento Pattern 备忘录模式
## Definition

Without violating encapsulation, capture and externalize an object's internal state so that the object can be restored to this state later.
<br>在不破坏封装性的前提下，捕获一个对象的内部状态，并在该对象之外保存这个状态。这样以后就可将该对象恢复到原先保存的状态。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/memento.gif)


## Participants

The classes and objects participating in this pattern are:

### Memento  (Memento)
* stores internal state of the Originator object. The memento may store as much or as little of the originator's internal state as necessary at its originator's discretion.
* protect against access by objects of other than the originator. Mementos have effectively two interfaces. Caretaker sees a narrow interface to the Memento -- it can only pass the memento to the other objects. Originator, in contrast, sees a wide interface, one that lets it access all the data necessary to restore itself to its previous state. Ideally, only the originator that produces the memento would be permitted to access the memento's internal state.
* 存储发端人对象的内部状态。备份可根据需要由发起人自行决定存储发起人内部状态的多与少。
* 保护发起人以外的对象不被访问。备份实际上有两个接口。Caretaker对Memento看到的是一个狭窄的界面--它只能将Memento传递给其他对象。Originator则看到的是一个宽泛的接口，它可以访问所有必要的数据，将自己恢复到之前的状态。理想的情况是，只有产生纪念物的发起者才被允许访问纪念物的内部状态。

### Originator  (SalesProspect)
* creates a memento containing a snapshot of its current internal state.
* uses the memento to restore its internal state
* 创建一个包含当前内部状态快照的备忘录。
* 使用该备忘录来恢复其内部状态。

### Caretaker  (Caretaker)
* is responsible for the memento's safekeeping
* never operates on or examines the contents of a memento.
* 负责保管备份。
* 绝不对备份进行操作或检查其内容。
