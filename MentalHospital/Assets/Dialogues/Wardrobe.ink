INCLUDE globals.ink
//EXTERNAL language(currentLang)

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
Здесь должен лежать глаз, однако, это совсем другая игра.
-> END

= EN
There should be an eye, however, it is absolutely another game.
-> END

= CS
Tady musí být oko, ale tohle je absolutně jiná hrá.
-> END