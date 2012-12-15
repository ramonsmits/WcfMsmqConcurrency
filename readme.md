# WCF Concurrency test

This solution contains a client and server console application that use WCF MSMQ to communicate. The client calls a one way mathod on the server.

## MSMQ and Throttling

You can view the config files on how to configure the netMsmqBinding and how to configure the service throttling

## Concurrency and instancing

I made this to specifically test the [InstanceContextMode][4] and the [ConcurrencyMode][3] arguments on the [ServiceBehavior][0] attribute.

The InstanceContextMode defines if the service behaves as singleton or not (Single, PerCall, PerSession) and that ConcurrencyMode defines in what kind of thread safe operation that instance may be called (Single, Multiple, Reentrant).

### Singleton / Concurrent

If you want to have a service that is only created once and accepts concurrent calls then you need to use : InstanceContextMode.Single and ConcurrencyMode.Multiple

### Singleton / Synchronous

If you need just one instance that can only be called synchronous then use : InstanceContextMode.Single and ConcurrencyMode.Single

### Transient / Concurrent

If you want to have concurrent calls each on a new instance then use: InstanceContextMode.PerCall where it does not matter which ConcurrencyMode value your use.

### Transient / Synchronous

If you want to have synchronous calls and a new instance on each call then you use InstanceContextMode.PerCall and set ServiceThrottling MaxConcurrentCalls to 1.


[0]: http://msdn.microsoft.com/en-us/library/ms554644.aspx
[1]: http://msdn.microsoft.com/en-us/library/system.servicemodel.servicebehaviorattribute.concurrencymode.aspx
[2]: http://msdn.microsoft.com/en-us/library/system.servicemodel.servicebehaviorattribute.instancecontextmode.aspx
[3]: http://msdn.microsoft.com/en-us/library/system.servicemodel.concurrencymode.aspx
[4]: http://msdn.microsoft.com/en-us/library/system.servicemodel.instancecontextmode.aspx