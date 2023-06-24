INCLUDE ../globals.ink

{
    - currentLanguage == "ru": 
       -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

= RU
~firstCharacteristic = checkCharacteristic(0)
{
    - pillsWasTaken == false:
        ~ blockChoice(2)
    - firstCharacteristic == "Introvert":
        ~ blockChoice(1)
}
Ян, сегодня ты выглядишь гораздо лучше, что с тобой происходило всю неделю? #portrait:Colleague
*Не помню. #portrait:default
    Это странно. #portrait:Colleague
    ~offCollider()
    -> DONE
*Спасибо, ты тоже ничего, как твои дела? #portrait:default
    Все хорошо, не буду отвлекать. #portrait:Colleague
    ~offCollider()
    -> DONE
*Это не твое дело. #portrait:default
    Как грубо. #portrait:Colleague
    ~offCollider()
    -> DONE
-> END

= EN
Colleague is busy, do not disturb him. #portrait:Colleague
-> END

= CS
Kolega má práci. Nerušít, prosím. #portrait:Colleague
-> END