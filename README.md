AcronymFactory
=======================

C# helper class for generating acronyms.

### Use cases
* Generate string IDs for a named entity

### How to use
```csharp
var acronymFactory = new AcronymFactory();

var acronym = acronymFactory.Create("Nyan cat");
var acronymByLength = acronymFactory.Create("Nyan cat", 3);
```
