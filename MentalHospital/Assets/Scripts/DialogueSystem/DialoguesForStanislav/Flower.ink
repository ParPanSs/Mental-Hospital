EXTERNAL language(currentLang)

~ temp currentLanguage = language("")

{
    - currentLanguage == "ru": 
       -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

= RU
Это цветок. Кажется, ему не хватает воды.

...
    * [Полить]
        Вы полили цветок. Спасибо.
        -> DONE
    * [Уйти]
        -> DONE
-> END

= EN
This is a flower. It seems to need some water.

...
    *[To water]
        You watered the flower. Thank you.
        -> DONE
    *[To leave]
        ->DONE
-> END

= CS
Tohle je květina. Vypádá jakoby potřebuje vodu.

...
    *[Polít]
        Vý jste polili květinu. Děkuji.
    ->DONE
    *[Odejít]
    ->DONE

->END