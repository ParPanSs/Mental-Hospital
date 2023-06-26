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
~ blockChoice(2)
~ firstCharacteristic = checkCharacteristic(0)
{
- firstCharacteristic == "Introvert":
    Как ты сегодня, друг?
- firstCharacteristic == "Extravert":
    ...
}
    * [Полить]
        Всем нужна вода.
        ~ flowerIsWatered = true
        -> DONE
    * [Уйти]
        ... #portrait:default
        -> DONE
    * [Smash]
        ...
        -> DONE
= EN
This is a flower. It seems to need some water.
    * [Water]
        You watered the flower. Thank you.
        ~ flowerIsWatered = true
        -> DONE
    * [Leave]
        ... #portrait:default
        -> DONE

= CS
Tohle je květina. Vypádá jakoby potřebuje vodu.
    * [Polít]
        Vý jste polili květinu. Děkuji.
        ~ flowerIsWatered = true
        -> DONE
    * [Odejít]
    ... #portrait:default
        -> DONE