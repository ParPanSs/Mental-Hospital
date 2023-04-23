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
Вас мучает голод.

Вы пытаетесь открыть холодильник, но разработчики не добавили такой возможности.

Халтура, а не геймдизайн.
-> END

= EN
You are starving.

You are trying to open the fridge, but developers didn't add this interaction.

Trash, not a game design.
->END

= CS
Máte velký hlad. 

Snážíte se otevřít ledničku, ale vyvojáří nepřidali takovou možnost.

Brak, není herní design.
-> END
