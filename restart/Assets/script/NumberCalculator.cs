public class NumberCalculator
{
    public int Minus(int n1,
                     int n2)
    {
        int r = n1 - n2;
        return r;
    }

    public int Umnoj(int n1,
                     int n2)
    {
        int r = n1 * n2;
        return r;
    }

    public int Delenie(int n1,
                     int n2)
    {
        int r = n1 / n2;
        return r;
    }

    public static float FindPercentage(float number, float percent)
    {
        float r = number / 100;
        float Perc = r * percent;
        return Perc;
    }
}
