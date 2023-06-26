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
Удобный шкаф.
    *[Сменить одежду]
        Ничего не изменилось. Вся одежда для меня одинаковая.
        -> DONE
    *[Уйти]
        ...
        -> DONE
-> END

= EN
There should be an eye, however, it is absolutely another game.
-> END

= CS
Tady musí být oko, ale tohle je absolutně jiná hrá.
-> END