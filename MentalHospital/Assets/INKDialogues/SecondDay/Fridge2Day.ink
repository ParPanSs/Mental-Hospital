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
{
    - pillsWasTaken == false:
        ~ blockChoice(0)
}
Не чувствую голода.
    *[Громко хлопнуть]
        Зачем ты это делаешь? #portrait:Mother
        ->DONE
    *[Отойти]
        ...
        ->DONE
-> END

= EN
You are starving.

You are trying to open the fridge, but developers didn't add this interaction.

Trash, not a game design.
->END

= CS
Máte velký hlad. 

Snážíte se otevřít ledničku, ale vyvojáří nepřidali takovou možnost.

Hrůza, není herní design.
-> END
