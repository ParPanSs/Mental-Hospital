INCLUDE globals.ink


{
    - currentLanguage == "ru": 
       -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

= RU
~blockChoice(0)
~blockChoice(1)
Жаль, что нельзя просто остаться здесь и никуда не идти. #portrait:default
    
    *[Заправить кровать]
        Все должно быть правильно.
        -> DONE
    *[Пнуть]
        Одни кошмары, сколько можно...
        -> DONE
    *[Отойти]
        Сейчас я снова буду здесь.
        -> DONE
    
-> END

= EN
Colleague is busy, do not disturb him. #portrait:Colleague
-> END

= CS
Kolega má práci. Nerušít, prosím. #portrait:Colleague
-> END