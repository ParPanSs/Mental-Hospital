INCLUDE ../globals.ink

{
    - currentLanguage == "ru": 
        -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

== RU
Извини.
{
    - candyWasTaken == true:
        -> iHaveCandy
    - candyWasTaken == false:
        -> NoCandy
}
    = iHaveCandy
        ~blockChoice(2)
        ~offCollider()
        ... #portrait:Girl
        
        *[Уйти]
            Это на твоей совести. #portrait:Girl
            -> DONE
        *[Дать конфету]
            ~ apologizeWasTaken = true
            Ладно, ты прощен. #portrait:Girl
            -> DONE
        *[Treat]
            Я позову маму! #portrait:girl
            -> DONE
    -> END
    = NoCandy
        ~blockChoice(2)
        ~blockChoice(0)
        ~offCollider()
        ... #portrait:Girl
        *[Give a candy]
            Ладно, ты прощен. #portrait:Girl
            -> DONE
        *[Уйти]
            Это на твоей совести. #portrait:Girl
            -> DONE
        *[Treat]
            Я позову маму! #portrait:girl
            -> DONE
    -> END
-> END

== EN
This is a girl. You've stepped on her drawing. #portrait:Girl
-> END

== CS
Tohle je holka. Nastoupil jste na jeji kresleni. #portrait:Girl
-> END