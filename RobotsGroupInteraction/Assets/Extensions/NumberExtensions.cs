using System;

public static class NumberExtensions {
    public static Int32 ToInt32(this Single number) => (int)number;

    public static Boolean IsEven(this Int32 number) => number % 2 == 0;
    public static Boolean IsUneven(this Int32 number) => !number.IsEven();
    public static Int32 Normalize(this Int32 number) => number == 0 ? 0 : Math.Sign(number);

    public static Boolean IsEven(this Single number) => ((Int32)Math.Round(number)).IsEven();
    public static Boolean IsUneven(this Single number) => !number.IsEven();
}
