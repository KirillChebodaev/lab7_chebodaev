using System;

namespace Lab7
{
    /// <summary>
    /// Класс для расчёта скидок в системе заказов компании «Оптика-Вижн».
    /// </summary>
    public class DiscountCalculator
    {
        /// <summary>
        /// Размер скидки (20%).
        /// </summary>
        public const decimal DiscountRate = 0.20m;

        /// <summary>
        /// Рассчитывает цену со скидкой 20%, если по товару
        /// не было заказов в прошлом месяце.
        /// </summary>
        /// <param name="basePrice">Базовая цена товара.</param>
        /// <param name="hasOrdersLastMonth">Были ли заказы в прошлом месяце.</param>
        /// <returns>Цена со скидкой или базовая цена.</returns>
        public decimal GetDiscountedPrice(decimal basePrice, bool hasOrdersLastMonth)
        {
            if (hasOrdersLastMonth)
                return basePrice;

            return basePrice * (1m - DiscountRate);
        }

        /// <summary>
        /// Формирует строку-описание скидки для вывода в консоль.
        /// </summary>
        /// <param name="basePrice">Базовая цена товара.</param>
        /// <param name="finalPrice">Итоговая цена.</param>
        /// <returns>Текстовая строка с информацией о скидке.</returns>
        public string GetDiscountInfo(decimal basePrice, decimal finalPrice)
        {
            decimal saved = basePrice - finalPrice;
            return $"Экономия: {saved} руб. (скидка {DiscountRate * 100}%)";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new DiscountCalculator();
            decimal price = 5000m;
            decimal discounted = calculator.GetDiscountedPrice(price, false);

            Console.WriteLine($"Базовая цена: {price}");
            Console.WriteLine($"Цена со скидкой: {discounted}");
            Console.WriteLine(calculator.GetDiscountInfo(price, discounted));

            Console.WriteLine();
            Console.WriteLine("Автор: Чебодаев Кирилл, группа И-43");

            Console.ReadKey();
        }
    }
}
