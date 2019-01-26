# pipesvshttp
This is a small solution to measure the performance difference between using named pipes versus using http for IPC. The performance was measured using [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet), with named pipes measured using .Net 4.7.2 and http measured using .Net core hosted in IIS.

Unsurprisingly named pipes are faster. In my home PC using named pipes is x3 times faster than using http. One number doesn't tell the whole story though. An IPC call using named pipes was completed in about 0.1ms while a similar call (HTTP POST) was completed in about 0.3ms.

It seems that, everything else being equal, the choice between named pipes and http is important only if the highest performance is absolutely required by an application. For most applications, the difference of 0.2ms per call will not make a difference and the choice between the two methods of communication should be made with criteria more relevant to other development considerations like maintenability, extensibility and familiarity of the developers with these technologies.
