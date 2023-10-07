
using FileBaseContext.Abstractions.Models.Entity;

namespace HometaskN48_API.Models
{
    public class User : IFileSetEntity<Guid>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }


//- modellarini qo'shing
//- DataAccess ni qo'shing ( IDataContext, AppFileContext )
//- shu modellar uchun servicelarni qo'shing
//- UserOrders nomli composition service qo'shing

//Controller 

//-  UsersController va endpointlar 

//- api/users - get, post, put - barcha userlarni olish, user qo'shish va userni update qilish
//- api/users/:id - get - bitta userni Id bo'yicha olish
//- api/users/:id/orders - get - bitta userni barcha orderlarnini olish

//- OrdersController va endpointlar

//- api/orders - get, post, put - barcha orderlarni olish, order qo'shish va order ni update qilish
//- api/orders/:id - bitta orderni Id bo'yicha olish

//- swagger o'rnating

//PS : api configuratsiyasi va controllerlar, ular ichida servicelarni ishlatishni N48 darsidagi IntroB.Api project dan ko'rsangiz bo'ladi, barcha endpointlarni swagger orqali tekshiring
    }
}
