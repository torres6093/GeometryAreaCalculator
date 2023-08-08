namespace GeometryAreaCalculator.Utils
{
    public class Constants
    {
        /// <summary>
        /// Round accuracy.
        /// </summary>
        /// <remarks>
        /// !NB: В задании не была указана точность округления, поэтому вынесено в константу.
        /// Предположил, что т.к. библиотека нужна не для отчетности (где округление до 1-2 цифр), а для вычислений,
        /// то и цифр можно взять побольше.
        /// </remarks>
        public const int decimalPlaces = 5;
    }
}
