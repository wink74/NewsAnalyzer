using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAnalyzerExecutor.StockMarket
{
    /// <summary>
    ///     Модель для получения инфы из БД запланированных к покупке/продаже акций
    /// </summary>
    public class PlannedStocks
    {
        /// <summary>
        ///     Наименование компании
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        ///     Число акций (или что-то другое, как-то надо определить, сколько покупать, мб вообще не надо и определяться будет на ходу)
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        ///     Действие (покупка/продажа)
        /// </summary>
        public StockAction Action { get; set; }
    }

    /// <summary>
    ///     Действие с акциями
    /// </summary>
    public enum StockAction
    {
        /// <summary>
        ///     Покупка
        /// </summary>
        Buy = 0,

        /// <summary>
        ///     Продажа
        /// </summary>
        Sell = 1
    }
}
