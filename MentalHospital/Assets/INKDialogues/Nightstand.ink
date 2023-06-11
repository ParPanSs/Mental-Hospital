INCLUDE globals.ink

{
    - currentLanguage == "ru": 
       -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

=RU

~firstCharacteristic = checkCharacteristic(0)
{
    - firstCharacteristic == "Introvert":
        -> INTROVERSION_RU
    - firstCharacteristic == "Extravert":
        -> EXTRAVERSION_RU
}

-> END

=INTROVERSION_RU
~blockChoice(2)
Вдруг понадобится.
    *[Взять]
        ...
        -> DONE
    
    *[Не брать]
        ...
        -> DONE
    
    *[Разбить]
        ...
        -> DONE
->END

=EXTRAVERSION_RU
~blockChoice(2)
Вдруг позвонят.
    *[Взять]
        ...
        -> DONE
    
    *[Не брать]
        ...
        -> DONE
    
    *[Разбить]
        ...
        -> DONE
->END



-> END

== EN
This is nightstand.
-> END

== CS
Tohle je noční stolek.
-> END