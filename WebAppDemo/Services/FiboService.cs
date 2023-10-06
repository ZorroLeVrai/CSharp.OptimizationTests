namespace WebAppDemo.Services
{
    public class FiboService
    {
        public int Compute(int index)
        {
            if (index < 2)
                return index;

            return Compute(index - 1) + Compute(index - 2);
        }
    }
}
