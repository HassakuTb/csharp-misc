namespace HassakuLab
{
    public static partial class Util
    {
        public struct IfContext<T>
        {
            public T Value { get; set; }
            public bool IsConfirmed { get; set; }
        }

        public static IfContext<T> If<T>(bool condition, Func<T> evaluate)
        {
            if (condition)
            {
                return new IfContext<T>
                {
                    Value = evaluate(),
                    IsConfirmed = true,
                };
            }
            else
            {
                return new IfContext<T>
                {
                    IsConfirmed = false,
                };
            }
        }

        public static IfContext<T> If<T>(bool condition, T evaluation)
        {
            if (condition)
            {
                return new IfContext<T>
                {
                    Value = evaluation,
                    IsConfirmed = true,
                };
            }
            else
            {
                return new IfContext<T>
                {
                    IsConfirmed = false,
                };
            }
        }

        public static IfContext<T> ElseIf<T>(this IfContext<T> context, bool condition, Func<T> evaluate)
        {
            if (context.IsConfirmed) return context;

            if (condition)
            {
                return new IfContext<T>
                {
                    Value = evaluate(),
                    IsConfirmed = true,
                };
            }
            else
            {
                return context;
            }
        }

        public static IfContext<T> ElseIf<T>(this IfContext<T> context, bool condition, T evaluation)
        {
            if (context.IsConfirmed) return context;

            if (condition)
            {
                return new IfContext<T>
                {
                    Value = evaluation,
                    IsConfirmed = true,
                };
            }
            else
            {
                return context;
            }
        }

        public static T Else<T>(this IfContext<T> context, Func<T> evaluate)
        {
            return context.IsConfirmed ? context.Value : evaluate();
        }

        public static T Else<T>(this IfContext<T> context, T evaluation)
        {
            return context.IsConfirmed ? context.Value : evaluation;
        }
    }


    class Usage
    {
        public void Use()
        {
            int value = 7;

            {

                string oddOrEvenOrZero =
                    Util.If(value == 0, "Zero")
                    .ElseIf(value % 2 == 0, "Even")
                    .Else("Odd");

            }
            //  or
            {

                string oddOrEvenOrZero =
                    Util.If(value == 0, () =>
                    {
                        return "Zero";
                    })
                    .ElseIf(value % 2 == 0, () =>
                    {
                        return "Even";
                    })
                    .Else(() =>
                    {
                        return "Odd";
                    });

            }

        }
    }
}
