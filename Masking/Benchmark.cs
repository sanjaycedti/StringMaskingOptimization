using System.Runtime.InteropServices;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace Masking;

[MemoryDiagnoser]
public class MaskingBenchmark
{
	private const string ClearValue = "Secret Password";

	[Benchmark]
	public string MaskStringConcate()
	{
		var value = ClearValue.Substring(0, 3);
		var length = ClearValue.Length - value.Length;

		for(var i = 0; i < length; i++)
		{
			value += "*";
		}

		return value;
	}

    [Benchmark]
    public string MaskStringBuilder()
    {
        var text = ClearValue.Substring(0, 3);
        var sb = new StringBuilder(text);
        var length = ClearValue.Length - text.Length;

        for (var i = 0; i < length; i++)
        {
			sb.Append('*');
        }

        return sb.ToString();
    }

    [Benchmark]
    public string MaskNewString()
    {
        var text = ClearValue.Substring(0, 3);
        var length = ClearValue.Length - text.Length;

        var str = new string('*', length);

        return text + str;
    }

    [Benchmark]
    public string MaskCharArray()
    {
        var chars = ClearValue.ToCharArray();

        for (var i = 3; i < ClearValue.Length; i++)
        {
            chars[i] = '*';
        }

        return new string(chars);
    }

    [Benchmark]
    public string MaskStringCreate()
    {
        return string.Create(ClearValue.Length, ClearValue, (span, value) =>
        {
            value.AsSpan().CopyTo(span);

            span[3..].Fill('*');
        });
    }

    [Benchmark]
    public string MaskSpan()
    {
        Span<char> span = stackalloc char[ClearValue.Length];

        for(var i = 0; i < 3; i++)
        {
            span[i] = ClearValue[i];
        }

        span[3..].Fill('*');

        return span.ToString();
    }
}

