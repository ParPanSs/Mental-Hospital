INCLUDE ../globals.ink


~ currentLanguage = language("en")
{
    - currentLanguage == "ru": 
       -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

=RU
~ firstCharacteristic = checkCharacteristic(0)
{
    - firstCharacteristic == "Extravert":
        -> EXTRAVERSION_RU
    - firstCharacteristic == "Introvert":
        -> INTROVERSION_RU
}
-> END

= EXTRAVERSION_RU
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

=INTROVERSION_RU
~blockChoice(1)
Сахар с водой, в целом, вкусно.
    * [Взять]
        ~ pickUpItem()
        ~ candyWasTaken = true
        Вдруг захочется.
        -> DONE
    *[Ask mom]
        Хочешь? #portrait:default
        Я уже съела несколько штук, пока пила чай. #portrait:Mother
        Возьми лучше себе.
        -> DONE
    * [Не брать]
        Не думаю, что это нужно.
        -> DONE
-> END

===EN===
Colleague is busy, do not disturb him.
-> END

===CS===
Kolega má práci. Nerušít, prosím. 
-> END