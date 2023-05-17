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
Доброе утро, сын.
    *[Поприветствовать]
        Не забудь, что сегодня вечером ты записан к доктору.
        -> DONE
    *[Отмена]
        -> END
-> END
= EN
Morning, son.
    * [Greeting]
        Don't forget about your evening doctor appointment.
        -> DONE
    * [Cancel]
        -> END
-> END
= CS
Dobré ráno, syne.
    * [Uvítat]
        Nezapomeň na večerní zápis k doktorovi.
        -> DONE
    * [Zrušení]
        -> END
->END