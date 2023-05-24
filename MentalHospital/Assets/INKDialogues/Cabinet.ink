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
Когда-то мне выписали эти таблетки, уже не помню, когда я их пил в последний раз.
    *[Взять]
        Плацебо ли это...
        -> DONE
    *[Не брать]
        Воздержусь.
        -> DONE
-> END

= EN
Colleague is busy, do not disturb him. #portrait:Colleague
-> END

= CS
Kolega má práci. Nerušít, prosím. #portrait:Colleague
-> END