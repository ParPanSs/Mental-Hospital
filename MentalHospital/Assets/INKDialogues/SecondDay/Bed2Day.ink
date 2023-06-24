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
~ secondCharacteristic = checkCharacteristic(1)
{
    - secondCharacteristic == "Rational":
        -> Rationality_RU
    - secondCharacteristic == "Irrational":
        -> Irrationality_RU
    - fourthCharacteristic == "Choleric":
        -> Choleric_RU
}
-> END

=Irrationality_RU
~blockChoice(0)
~blockChoice(1)
Каждый день одно и то же. #portrait:default
    
    *[Tuck]
        Все должно быть правильно.
        -> DONE
    *[Kick]
        Одни кошмары, сколько можно...
        -> DONE
    *[Отойти]
        Сейчас я снова буду здесь.
        -> DONE
-> END

=Rationality_RU
~blockChoice(1)
Каждый день одно и то же. #portrait:default
    
    *[Заправить]
        Все должно быть правильно.
        -> DONE
    *[Kick]
        Одни кошмары, сколько можно...
        -> DONE
    *[Отойти]
        Сейчас я снова буду здесь.
        -> DONE
->END

=Choleric_RU
~blockChoice(0)
Жаль, что нельзя просто остаться здесь и никуда не идти. #portrait:default
    
    *[Tuck]
        Все должно быть правильно.
        -> DONE
    *[Пнуть]
        Одни кошмары, сколько можно...
        -> DONE
    *[Отойти]
        Сейчас я снова буду здесь.
        -> DONE
->END

= EN
Colleague is busy, do not disturb him. #portrait:Colleague
-> END

= CS
Kolega má práci. Nerušít, prosím. #portrait:Colleague
-> END