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
Это цветок. Кажется, ему не хватает воды.
    + [Полить]
        Вы полили цветок. Спасибо.
        ~ flowerIsWatered = true
        -> DONE
    + [Уйти] 
        -> DONE

= EN
This is a flower. It seems to need some water.
    + [Water]
        You watered the flower. Thank you.
        ~ flowerIsWatered = true
        -> DONE
    + [Leave]
        -> DONE

= CS
Tohle je květina. Vypádá jakoby potřebuje vodu.
    + [Polít]
        Vý jste polili květinu. Děkuji.
        ~ flowerIsWatered = true
        -> DONE
    + [Odejít]
    -> DONE
