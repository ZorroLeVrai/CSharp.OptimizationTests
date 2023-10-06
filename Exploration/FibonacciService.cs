namespace Exploration;

internal ref struct FibonacciService
{
    private Span<int> _fiboSpan;

    internal FibonacciService(Span<int> fiboSpan)
    {
        _fiboSpan = fiboSpan;
    }

    internal Span<int> Compute()
    {
        for (int i=0; i < _fiboSpan.Length; i++)
        {
            if (i < 2)
                _fiboSpan[i] = i;
            else
                _fiboSpan[i] = _fiboSpan[i-1] + _fiboSpan[i-2];
        }

        return _fiboSpan;
    }
}
