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
Доброе утро, Ян. #portrait:Mother
    *... #portrait:default
        Тебе опять снились кошмары? #portrait:Mother
        ... #portrait:default
        Бедный мой мальчик... Надеюсь, что психотерапевт тебе все-таки поможет. #portrait:Mother
        Кстати, не забудь, что у тебя сегодня запись к нему после работы, он будет ждать.
        ~offCollider()
        -> END
    *[Доброе утро]
        Доброе утро.#portrait:default
        Тебе опять снились кошмары? #portrait:Mother
        ... #portrait:default
        Бедный мой мальчик... Надеюсь, что психотерапевт тебе все-таки поможет. #portrait:Mother
        Кстати, не забудь, что у тебя сегодня запись к нему после работы, он будет ждать.
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