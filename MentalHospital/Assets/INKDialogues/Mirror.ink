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
Это я.
    *[Разбить]
        Не хочу это видеть.
        -> DONE
    *[Успокоиться] 
        Всего лишь еще один день...
        -> DONE
    *[Отойти]
        ...
        ->DONE
-> END

= EN
It's me.
-> END

= CS
To jsem.
-> END