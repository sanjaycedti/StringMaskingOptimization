using BenchmarkDotNet.Running;
using Masking;

BenchmarkRunner.Run<MaskingBenchmark>();

return;

var benchmark = new MaskingBenchmark();

var str1 = benchmark.MaskStringConcate();

Console.WriteLine(str1);

var str2 = benchmark.MaskStringBuilder();

Console.WriteLine(str2);

var str3 = benchmark.MaskNewString();

Console.WriteLine(str3);

var str4 = benchmark.MaskCharArray();

Console.WriteLine(str4);

var str5 = benchmark.MaskStringCreate();

Console.WriteLine(str5);

var str6 = benchmark.MaskSpan();

Console.WriteLine(str6);
