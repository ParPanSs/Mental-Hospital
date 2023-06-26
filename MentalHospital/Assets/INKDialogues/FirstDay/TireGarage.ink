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
Мне нельзя управлять машиной, говорят, что это слишком опасно. Возможно.
~offCollider()
-> END

== EN
The bowl is full.
-> END

== CS
Mísa je plná.
-> END