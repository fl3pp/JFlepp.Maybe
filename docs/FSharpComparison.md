# Maybe and FSharp option comparison

## Creation

In FSharp

~~~ fs
let getIntIf3 str =
  if str = "3" then Some (Int32.Parse str)
  else None
~~~

In CSharp

~~~ cs
using static JFlepp.Functional.Maybe;

Maybe<int> GetIntIf3(string str) => str == "3"
  ? Some(int.Parse(str))
  : None<int>();
~~~

## Matching

In FSharp

``` fs
let stopIfNeeded sign =
  match sign with
  | Some _ -> printfn "Stopping"
  | None -> printfn "Driving"

(Message "Stop") |> Some |> stopIfNeeded // Stopping
None |> stopIfNeeded                     // Driving
```

In CSharp

``` cs
void StopIfNeeded(Maybe<StopSign> sign) => sign.Match(
  s => Console.WriteLine("Stopping"),
  () => Console.WriteLine("Driving"));

  var sign = Some(new StopSign());
  StopIfNeeded(sign);                   // Stopping
	
  var noSign = None<StopSign>();
  StopIfNeeded(noSign);                 // Driving
```
