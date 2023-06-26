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
Зачем людям вообще гараж, если у них нет машины? Откуда у них столько вещей, что это все не может поместиться в дом?
~offCollider()
-> END

== EN
The bowl is full.
-> END

== CS
Mísa je plná.
-> END