﻿namespace GeometryAreaCalculator.Utils
{
    public class Constants
    {
        /// <summary>
        /// Round accuracy.
        /// </summary>
        /// <remarks>
        /// !NB: В задании не была указана точность округления. Предположил, что т.к. библиотека нужна
        /// не для отчетности (где округление до 1-2 цифр), а для вычислений, то и цифр можно взять побольше.
        /// </remarks>
        public const int decimalPlaces = 5;

        /// <summary>
        /// Calculation accuracy.
        /// </summary>
        public const double delta = 1e-10;
    }
}
