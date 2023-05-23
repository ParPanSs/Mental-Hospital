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
Доброе утро, сын. #portrait:Mother
    * [Поприветствовать]
        Не забудь, что сегодня вечером ты записан к доктору.
        -> DONE
    * [Отмена]
        -> DONE
-> END
= EN
Morning, son. #portrait:Mother
    * [Greeting]
        Don't forget about your evening doctor appointment.
        -> DONE
    * [Cancel]
        -> DONE
-> END
= CS
Dobré ráno, syne. #portrait:Mother
    * [Uvítat]
        Nezapomeň na večerní zápis k doktorovi. #portrait:Mother
        -> DONE
    * [Zrušení]
        -> DONE
->END