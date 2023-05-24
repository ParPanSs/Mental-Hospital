INCLUDE globals.ink

{
    - currentLanguage == "ru": 
        -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

== RU
Это девочка. Вы наступили на ее рисунок. #portrait:Girl
{
    - candyWasTaken == true:
        -> iHaveCandy
    - candyWasTaken == false:
        -> NoCandy
}
    = iHaveCandy
        *[Дать конфету]
            Вы дали девочке конфету.
            -> END
        *[Уйти]
            Вы ушли.
            -> END
    -> END
    = NoCandy
        *[???]
            ???
            -> END
        *[Уйти]
            Вы ушли.
            -> END
    -> END
-> END

== EN
This is a girl. You've stepped on her drawing. #portrait:Girl
-> END

== CS
Tohle je holka. Nastoupil jste na jeji kresleni. #portrait:Girl
-> END