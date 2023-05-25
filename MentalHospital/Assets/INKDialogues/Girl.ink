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
~offCollider()
Не-е-е-т!!! Мой рисунок... Ты все испортил, испортил! #portrait:Girl
Я не хотел. #portrait:default
Я не прощу тебя за то, что ты сделал! #portrait:Girl

-> END

== EN
This is a girl. You've stepped on her drawing. #portrait:Girl
-> END

== CS
Tohle je holka. Nastoupil jste na jeji kresleni. #portrait:Girl
-> END