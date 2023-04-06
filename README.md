# StringMaskingOptimization

BenchmarkDotNet=v0.13.5, OS=macOS Ventura 13.1 (22C65) [Darwin 22.2.0]
Apple M1 Pro, 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 7.0.4 (7.0.423.11508), Arm64 RyuJIT AdvSIMD [AttachedDebugger]
  DefaultJob : .NET 7.0.4 (7.0.423.11508), Arm64 RyuJIT AdvSIMD


|            Method |       Mean |     Error |    StdDev |     Median |   Gen0 | Allocated |
|------------------ |-----------:|----------:|----------:|-----------:|-------:|----------:|
| MaskStringConcate | 122.027 ns | 2.3873 ns | 2.3446 ns | 120.924 ns | 0.0892 |     560 B |
| MaskStringBuilder |  29.100 ns | 0.7314 ns | 1.0253 ns |  28.840 ns | 0.0305 |     192 B |
|     MaskNewString |  22.590 ns | 0.6930 ns | 1.9883 ns |  21.702 ns | 0.0217 |     136 B |
|     MaskCharArray |  16.436 ns | 0.2766 ns | 0.2452 ns |  16.351 ns | 0.0179 |     112 B |
|  MaskStringCreate |   9.184 ns | 0.1618 ns | 0.1351 ns |   9.141 ns | 0.0089 |      56 B |
|          MaskSpan |  10.969 ns | 0.2619 ns | 0.3016 ns |  10.811 ns | 0.0089 |      56 B |
