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
Вдруг понадобится.
    *[Взять]
        ...
    -> DONE
    
    *[Не брать]
        ...
    -> DONE
-> END

== EN
This is nightstand.
-> END

== CS
Tohle je noční stolek.
-> END