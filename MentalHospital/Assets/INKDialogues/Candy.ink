INCLUDE globals.ink


~ currentLanguage = language("en")
{
    - currentLanguage == "ru": 
       -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

= RU
Сахар с водой, в целом, вкусно.
    * [Взять]
        ~ pickUpItem()
        ~ candyWasTaken = true
        Вдруг захочется.
        -> DONE
    *[Предложить маме]
        Хочешь? #portrait:default
        Я уже съела несколько штук, пока пила чай. #portrait:Mother
        Возьми лучше себе.
        -> DONE
    * [Не брать]
        Не думаю, что это нужно.
        -> DONE
-> END

= EN
Colleague is busy, do not disturb him.
-> END

= CS
Kolega má práci. Nerušít, prosím. 
-> END