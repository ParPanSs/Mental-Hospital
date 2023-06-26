INCLUDE ../globals.ink
EXTERNAL bed()

{
    - currentLanguage == "ru": 
       -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

===RU===
{ secondCharacteristic: 
    - "Rational": -> Rationality_RU
    - "Irrational": -> Irrationality_RU
}

===Irrationality_RU===
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

===Rationality_RU===
~blockChoice(1)
Каждый день одно и то же. #portrait:default
    *[Заправить]
        Все должно быть правильно.
        ~bed()
        -> DONE
    *[Kick]
        Одни кошмары, сколько можно...
        -> DONE
    *[Отойти]
        Сейчас я вновь окажусь здесь.
        -> DONE
->END


===EN===
Colleague is busy, do not disturb him. #portrait:Colleague
-> END

===CS===
Kolega má práci. Nerušít, prosím. #portrait:Colleague
-> END