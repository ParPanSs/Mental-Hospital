INCLUDE ../globals.ink

~ currentLanguage = language("en")
{
    - currentLanguage == "ru": 
       -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

== RU
Ты не опоздаешь на работу? #portrait:Mother
-> DONE

== EN
{ flowerIsWatered == false: You didn't water your flower yesterday, so it's died. | You don't need to water your flower two days in a row.}
-> DONE

== CS
{ flowerIsWatered == false: Nepolíl jste váše květinu včera, tak uvadla. | Nepotřebujete polívat květinu dva dny po řádě.}
-> DONE