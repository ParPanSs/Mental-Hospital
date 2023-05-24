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
Это конфеты.
    * [Взять]
        ~ pickUpItem()
        ~ candyWasTaken = true
        Вы взяли конфеты.
        -> DONE
    * [Не брать]
        Вы не взяли конфеты.
        -> DONE
-> END

= EN
Colleague is busy, do not disturb him.
-> END

= CS
Kolega má práci. Nerušít, prosím. 
-> END