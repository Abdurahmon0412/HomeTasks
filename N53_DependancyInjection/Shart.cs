namespace N53_DependancyInjection;

public class Shart
{
    //    quyidagi model va ularning servicelarni yarating

    //- User
    //- Order
    //- Bonus

    //bunda User va Order one-to-many, User va Bonus one-to-one bog'lanadi

    //quyidagi eventlarni implment qiling
    //- OrderCreatedEvent
    //- BonusAchievedEvent

    //INotificationService interfeysini implement qilgan quyidagi servicelarni yozing
    //- EmailSenderService
    //- SmsSenderService
    //- TelegramSenderService

    //eventlar uchun OrderEventStore va BonusEventStore larni yarating
    //asosiy eventlarni handle qiladigan servicelar quyidagilar 

    //- UserBonusService - bu service OrderCreatedEvent ni handle qiladi va
    //umumiy orderlarni summasini user ga bog'langan Bonus modeliga qo'shib boradi, bunda agar qo'shgandan keyin bonus bitta o'n xonalikka oshsa(masalan 89 edi 150 bo'ldi, yoki 756 edi endi 1022 bo'ldi ) BonusAchievedEvent ni yaratadi, agar oshmagan bo'lsa keyingi bonusgacha qancha qolganini userga notification bilan jo'natadi(barcha INotificationService ni inject qilib, barchasidan jo'natadi )

    //- UserPromotionService - bu service BonusAchievedEvent ni handle qiladi va
    //userga bonus ga yetganini aytib, umumiy bonusni 10% userga jo'natadi ( bu qismi shartmas )
    //va notification orqali xabar qiladi
}
