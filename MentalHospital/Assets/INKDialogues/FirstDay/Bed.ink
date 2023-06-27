INCLUDE ../globals.ink


{
    - currentLanguage == "ru": 
       -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

=RU
~blockChoice(1)
~blockChoice(2)
Жаль, что нельзя просто остаться здесь и никуда не идти. #portrait:default
    
    *[Отойти]
        Сейчас я снова буду здесь.
        -> DONE
    *[Tuck]
        Все должно быть правильно.
        -> DONE
    *[Kick]
        Одни кошмары, сколько можно...
        -> DONE
    
-> END

= EN
Colleague is busy, do not disturb him. #portrait:Colleague
-> END

= CS
Kolega má práci. Nerušít, prosím. #portrait:Colleague
-> END