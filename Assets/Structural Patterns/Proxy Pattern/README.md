# Proxy Pattern 代理模式
## Definition

Provide a surrogate or placeholder for another object to control access to it.
<br>为其他对象提供一种代理以控制对这个对象的访问。

![](https://github.com/QianMo/Unity-Design-Pattern/blob/master/UML_Picture/proxy.gif)


## Participants

The classes and objects participating in this pattern are:

### Proxy   (MathProxy)
* maintains a reference that lets the proxy access the real subject. Proxy may refer to a Subject if the RealSubject and Subject interfaces are the same.
* provides an interface identical to Subject's so that a proxy can be substituted for for the real subject.
* controls access to the real subject and may be responsible for creating and deleting it.
* other responsibilites depend on the kind of proxy:
	* `remote proxies` are responsible for encoding a request and its arguments and for sending the encoded request to the real subject in a different address space.
	* `virtual proxies` may cache additional information about the real subject so that they can postpone accessing it. For example, the ImageProxy from the Motivation caches the real images's extent.
	* `protection proxies` check that the caller has the access permissions required to perform a request.
* 维护一个让代理访问真实主体的引用。如果RealSubject和Subject接口相同，Proxy可以引用Subject。
* 提供与Subject相同的接口，以便代理可以代替真实主体。
* 控制对真实主体的访问，并可能负责创建和删除它。
* 其他责任取决于代理的种类。
	* `远程代理`负责对请求及其参数进行编码，并将编码后的请求发送到不同地址空间的真实主体。
	* `虚拟代理`可以缓存真实主体的附加信息，从而可以推迟访问它。例如，Motivation中的ImageProxy可以缓存真实图像的范围。
	* `保护代理`检查调用者是否有执行请求所需的访问权限。

### Subject   (IMath)
* defines the common interface for RealSubject and Proxy so that a Proxy can be used anywhere a RealSubject is expected.
* 定义了RealSubject和Proxy的通用接口，以便Proxy可以在任何需要RealSubject的地方使用。

### RealSubject   (Math)
* defines the real object that the proxy represents.
* 定义了代理所代表的真实对象。

