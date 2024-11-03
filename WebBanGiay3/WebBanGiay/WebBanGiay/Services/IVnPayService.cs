using WebBanGiay.Repository;
using WebBanGiay.ViewModels;

namespace WebBanGiay.Services
{
    public interface IVnPayService
    {
        string CreatePaymentUrl (HttpContext context, VnPaymentRequestModel model);
        VnPaymentResponseModel PaymentExecute(IQueryCollection collections);
    }
}
