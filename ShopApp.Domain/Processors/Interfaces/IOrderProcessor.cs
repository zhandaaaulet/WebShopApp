using System.Threading.Tasks;
using ShopApp.Domain.Model.Ordering;

namespace ShopApp.Domain.Processors.Interfaces
{
    /// <summary>
    /// Процессор, который отвечает за работу с заказами.
    /// </summary>
    public interface IOrderProcessor
    {
        /// <summary>
        /// Получает заказ из внешней системы по его уникальному идентификатору.
        /// </summary>
        /// <param name="orderId"> Уникальный идентификатор заказа. </param>
        /// <returns> Заказ, который был найден. </returns>
        Task<Order> GetById(long orderId);

        /// <summary>
        /// Сохраняет заказ в внешней системе.
        /// </summary>
        /// <param name="order"> Заказ, который нужно сохранить. </param>
        Task SaveOrder(Order order);
    }
}
