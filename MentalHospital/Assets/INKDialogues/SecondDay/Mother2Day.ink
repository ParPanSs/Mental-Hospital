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
Доброе утро, Ян, все тут с ума посходили по этому маньяку-фермеру, спокойно за покупками не сходить даже. #portrait:Mother
Ой, кстати, представляешь, в нашем магазине снова повысили цены! Уже второй раз за неделю! Я так никогда себе гардероб не обновлю. #portrait:Mother
~offCollider()
-> END

= EN
Morning, son. #portrait:Mother
    * [Greeting]
        Don't forget about your evening doctor appointment.
        -> DONE
    * [Cancel]
        ... #portrait:default
        -> DONE
-> END

= CS
Dobré ráno, syne. #portrait:Mother
    * [Uvítat]
        Nezapomeň na večerní zápis k doktorovi. #portrait:Mother
        -> DONE
    * [Zrušení]
        ... #portrait:default
        -> DONE
->END