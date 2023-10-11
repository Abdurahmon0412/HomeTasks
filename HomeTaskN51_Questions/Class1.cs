namespace HomeTaskN51_Questions;

public class Class1
{
    // savollar bilan bog'liq muammo bo'lsa telegramdan [@AS042003] bilan bog'lanishingiz mumkin 
    #region Question1
    //buyurtmalar(Order ) va bitta order ichidagi sotib olingan tovarlar(Product ) uchun endpoint qanday bo'lishligi kerak ?
        //[GET] api/orders/:id/products
    #endregion

    #region Question2
    //- web api konfiguratsiyasi uchun yaratilgan fayllar qaysi layerda turishligi kerak ?
    // Presentation Layerida turishi kerak - chunki API ga doir barcha narsa presentation layerida bo'ladi
    #endregion

    #region Question3
    //- controller ichida nechta service inject qilish mumkin?
    // Istalganicha serviceni controllerni ichiga inject qilishimiz mumkin
    // faqat usha inject qilgan servicemiz controllerni ichida ishlatilinsa bo'ldi .
    #endregion

    #region Question4
    //- controller ichida foundations service larini ishlatish mumkinmi?
    // o'zi imkoni boricha ishlatilmagani maqul chunki foundation servicelarni controllerga ochib qo'yish yaxshi emas chunki 
    // o'rtada verification yo'qoladi keyin foundation servicelarni Precessing ni ichida inject qilib hamma amallarni bajarib 
    // controllerga esa o'sha processing management serviceni inject qilsak maqsadga muvofiq bo'ladi.
    // misol uchun bizda bitta model bor u modelga esa boshqa modellar bog'langan biz o'sha modellni o'chirmoqchi
    // bo'lsak mu unga bog'liq modellar bilan muammo chiqarishi mumkin shuning uchun uni tekshiruvini management serviceda
    // qilib ketganimiz yaxshi
    // lekin hech qanday tekshiruvlari
    // bo'lishi shart bo'lmagan foundation servicelarni esa controllerga ochib qo'ysak muammo bo'lmaydi 
    #endregion
}